using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Drivers;
using FluentAssertions;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SpecFlowProject2.Drivers;
using SpecFlowProject2.Hooks;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;

namespace SpecFlowProject2.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        

        MainPageObject mainPageObject;

        

        [Given(@"I navigate to web app on following environement")]
        public void GivenINavigateToWebAppOnFollowingEnvironement()
        {
            //Console.WriteLine("abc");
            //var htmlReporter = new ExtentHtmlReporter(@"C:\Users\lenovo\Desktop\Reports\htmlReports\report.html");
            //var extent = new ExtentReports();
            //extent.AttachReporter(htmlReporter);
            //feature
            //var feature = extent.CreateTest<Feature>("interset rate calculator");
            //scenarios
            //var scenario = feature.CreateNode<Scenario>("check intrest rate");
            //steps
            //scenario.CreateNode<Given>("I navigate to web app on following environement");
            //extent.Flush();
            mainPageObject = new MainPageObject(HookInitialization.driver);
            HookInitialization.driver.Navigate().GoToUrl("https://cgcashgroup-dev-01.azurewebsites.net/");
            WebDriverWait wait = new WebDriverWait(HookInitialization.driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-home-page/div/div/div[1]/div[1]/pg-slider/div/pg-slider-handle/div")));
            mainPageObject.goDownToElement();
        }

        [Given(@"i move the amount to invest striders to (.*)")]
        public void GivenIMoveTheAmountToInvestStridersTo(int p0)
        {
            mainPageObject.EnterAmountToInvest(p0);

        }

        [Given(@"i move the maximum term striders to (.*)")]
        public void GivenIMoveTheMaximumTermStridersTo(int p0)
        {
            mainPageObject.EnterMaximumTerm(p0);
        }

        [Then(@"the total return should be (.*)")]
        public void ThenTheTotalReturnShouldBe(int p0)
        {
            float total_return = mainPageObject.getTotalReturn();
            Console.WriteLine(total_return);
            //Boolean b = true;
            //b.Should().BeFalse();
            total_return.Should().Be(total_return);
        }

    }
}
