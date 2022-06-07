using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Globalization;
namespace SpecFlowProject2.Steps.PageObject
{
    class ChosenRatePageObject
    {
        private readonly String url = @"https://cgcashgroup-dev-01.azurewebsites.net/gic/chosen-rate-page";
        private readonly IWebDriver driver;

        public const int DefaultWaitInSecondes = 5;

        public ChosenRatePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement getInTouchButton => driver.FindElement(By.ClassName("get-touch-btn"));
        private IWebElement returnButton => driver.FindElement(By.ClassName("button"));
        private IWebElement total_return_label => driver.FindElement(By.ClassName("label-total"));
        private IWebElement amount_to_invest_label => driver.FindElements(By.ClassName("label-card-value"))[0];
        private IWebElement intrest_rate_label => driver.FindElement(By.ClassName("label-card2"));
        private IWebElement name_provider_label => driver.FindElements(By.ClassName("label-card-value"))[1];
        private IWebElement maximum_term_label => driver.FindElements(By.ClassName("label-card-value"))[2];
        public void ClickGetInTouchButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(getInTouchButton).Build().Perform();
        }

        public void ClickReturnButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(returnButton).Build().Perform();
        }
        public float getTotalReturn()
        {
            return float.Parse(total_return_label.Text.Split(" ")[1], CultureInfo.InvariantCulture.NumberFormat);
        }

        public float getAmountToInvest()
        {
            return float.Parse(amount_to_invest_label.Text.Split(" ")[1]);
        }

        public int getMaximumTerm()
        {
            return Int32.Parse((maximum_term_label.Text.Split(" "))[0]);
        }

        public String getProviderName()
        {
            return name_provider_label.Text;
        }
    }
}
