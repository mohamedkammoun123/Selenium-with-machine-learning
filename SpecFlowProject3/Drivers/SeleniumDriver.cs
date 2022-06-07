using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;


namespace SpecFlowProject2.Drivers
{
    public class SeleniumDriver
    {
        private FirefoxDriver driver;

        private readonly ScenarioContext scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        public IWebDriver setup()
        {
            FirefoxOptions options = new FirefoxOptions();
            return driver;
        }

    }
}
