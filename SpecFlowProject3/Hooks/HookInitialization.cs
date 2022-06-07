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
using System.Diagnostics;
using SpecFlowProject3.email;

namespace SpecFlowProject2.Hooks
{
    [Binding]
    class HookInitialization
    {
        public static IWebDriver driver;
        public static ExtentTest featureName;
        public static ExtentTest scenario;
        public static ExtentReports extent;
        public static String etat;
        //public static KlovReporter klovReporter;
        private static ExtentKlovReporter klov;
        
        public static void execute_bash()
        {
            var p = new Process
            {
                StartInfo =
                 {
                     FileName = @"C:\Windows\System32\cmd.exe",
                     Arguments = "echo hello"
                 }
            }.Start();
        }
        public static async Task<String> GetMessageAsync()
        {
            //HttpClient client = new HttpClient();
            String message;
            //tring response = await client.GetStringAsync("http://127.0.0.1:5000/true_value" + pathSound);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync("http://127.0.0.1:5000/true_value"))
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
            execute_bash();
            Console.WriteLine("abc");
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\lenovo\AppData\Local\Programs\Python\Python310\report.html");
            extent = new ExtentReports();
            klov = new ExtentKlovReporter();
            klov.InitMongoDbConnection("localhost",27017);
            klov.ProjectName = "Execute Automation Test";
            klov.InitKlovServerConnection("http://localhost:8077/true_value");
            klov.ReportName = "this test is in time  = " + System.DateTime.Now.ToString();
            extent.AttachReporter(htmlReporter,klov);

        }

        [AfterTestRun]
        public async static void AfterTestRun()
        {
            String[] mails = { "kammunmohamed12@gmail.com" };
            MailHelper.SendMail(mails, "test email", "hello world");
            extent.Flush();
            //String message = await GetMessageAsync();
            //Console.WriteLine(message);
            Console.WriteLine("happend");
            Console.WriteLine(ScenarioContext.Current.ScenarioExecutionStatus);
            if (ScenarioContext.Current.TestError != null)
            {
               Console.WriteLine("what");
                Console.WriteLine(ScenarioContext.Current.TestError);
            }
            String message = await GetMessageAsync();
           
            
        }



        [BeforeScenario]
        public static void BeforeScenario()
        {
            //featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\Users\lenovo\Desktop\chromedriver_win32 (4)\chromedriver.exe");
            driver = new ChromeDriver(@"D:\");
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
            Console.WriteLine("output is");
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
        public static void AfterScenario()
        {
            Exception lastError = ScenarioContext.Current.TestError;

            if (lastError != null)
            {
                //var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                Console.WriteLine("this is is");
                Console.WriteLine(etat);


            }
            driver.Close();
            //String message = await GetMessageAsync();
            //Console.WriteLine(message);
            Console.WriteLine("______________________________________________");
            string workingDirectory = Environment.CurrentDirectory;
            Console.WriteLine(workingDirectory);
            Console.WriteLine(workingDirectory.Split("bin")[0]);
            //execute_bash();



        }
        [TearDown]
        public static void whenExveption()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            Console.WriteLine("what happend now is");
            Console.WriteLine(ScenarioContext.Current.TestError);
        }
        [OneTimeTearDown]
        public static void whenExveption1()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
           Console.WriteLine("what happend now is");
            Console.WriteLine(ScenarioContext.Current.TestError);
        }
        //public static IWebDriver driver;
        //[BeforeScenario]
        //public static void BeforeScenario()
        //{
        //    driver = new ChromeDriver(Environment.CurrentDirectory);
        //}
        //[AfterScenario]
        //public static void AfterScenario()
        //{
        //    Console.WriteLine("abc");
        //    driver.Close();
        //}
    }
}
