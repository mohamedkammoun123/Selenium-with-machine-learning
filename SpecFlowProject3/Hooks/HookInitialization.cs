using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using SpecFlowProject3.Hooks;

namespace SpecFlowProject2.Hooks
{
    [Binding]
    class HookInitialization
    {
        public static Config read_config()
        {
            String path = Environment.CurrentDirectory.Split("bin")[0]+"/config.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                
                Config items = JsonConvert.DeserializeObject<Config>(json);

                return items;

            }
            

        }
        public static IWebDriver driver;
        public static ExtentTest featureName;
        public static ExtentTest scenario;
        public static ExtentReports extent;
        public static String etat;
        //public static KlovReporter klovReporter;
        private static ExtentKlovReporter klov;

        
        public static async Task<String> GetMessageAsync()
        {
            //HttpClient client = new HttpClient();
            String message;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync(read_config().svm_model_ip))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        message = await content.ReadAsStringAsync();
                    }
                }
            }
            return message;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var htmlReporter = new ExtentHtmlReporter(read_config().report_html_path);
            extent = new ExtentReports();
            klov = new ExtentKlovReporter();
            klov.InitMongoDbConnection(read_config().mongodb_ip,read_config().mongodb_port);
            klov.ProjectName = "Execute Automation Test";
            klov.InitKlovServerConnection(read_config().klov_server_ip+":"+read_config().klov_server_port);
            klov.ReportName = "this test is in time  = " + System.DateTime.Now.ToString();
            extent.AttachReporter(htmlReporter,klov);
            Console.WriteLine("Before______________Test");
            

        }

        [AfterTestRun]
        public async static void AfterTestRun()
        {
            extent.Flush();
            String message = await GetMessageAsync();
            
        }

        

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\Users\lenovo\Desktop\chromedriver_win32 (4)\chromedriver.exe");
            driver = new ChromeDriver(read_config().chrome_driver_path);
            //driver.Manage().Window.Size = new Size(1280,1024);
            driver.Manage().Window.Maximize();
        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [AfterStep]
        public static void AfterStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            etat = stepType;
            //PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            //MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            //object TestResult = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            else
            {
                Console.WriteLine("hello world");
                Console.WriteLine(stepType);
                if (stepType == "Given")
                {
                    Console.WriteLine(stepType);
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    
                }
                else if (stepType == "When")
                {
                    Console.WriteLine(ScenarioContext.Current.TestError.InnerException);
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    
                }
                else if (stepType == "Then")
                {
                    Console.WriteLine(stepType);
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    
                }
            }
            
            
            Console.WriteLine(ScenarioContext.Current.ScenarioExecutionStatus);
            //if (TestResult.ToString() == "StepDefinitionPending")
            //{
            //    if (stepType == "Given")
            //    {
            //        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Defenition Pending");
            //    }
            //    else if (stepType == "When")
            //    {
            //        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Defenition Pending");
            //    }
            //    else if (stepType == "Then")
            //    {
            //        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Defenition Pending");
            //    }
            //}

        }

        [AfterScenario]
        public  static void AfterScenario()
        {
            Exception lastError = ScenarioContext.Current.TestError;

            if (lastError != null)
            {
                //var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                
                Console.WriteLine(etat);
               

            }
            driver.Close();
            
        }
        [TearDown]
        public static void whenExveption()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            
            Console.WriteLine(ScenarioContext.Current.TestError);
        }
        [OneTimeTearDown]
        public static void whenExveption1()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            
            Console.WriteLine(ScenarioContext.Current.TestError);
        }

    }
}
