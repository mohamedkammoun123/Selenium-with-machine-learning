using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Globalization;

namespace SpecFlowProject2.Steps.PageObject
{

    public class MainPageObject
    {
        private readonly String url = @"https://cgcashgroup-dev-01.azurewebsites.net/";
        private readonly IWebDriver driver;

        public const int DefaultWaitInSecondes = 5;

        public MainPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Finding elements by ID
        private IWebElement amount_to_invest_slider => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-home-page/div/div/div[1]/div[1]/pg-slider/div/pg-slider-handle/div"));
        private IWebElement maximum_term_slider => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-home-page/div/div/div[1]/div[2]/pg-slider/div/pg-slider-handle/div"));
        private IWebElement intrest_rate_card => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-home-page/div/div/div[1]/pgcard/div/div[2]/div[1]/label[1]"));
        private IWebElement total_return_label_card => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-home-page/div/div/div[1]/pgcard/div/div[2]/div[2]/label[1]"));
        private IWebElement amount_to_invest_label_card => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-home-page/div/div/div[1]/div[1]/label[2]"));
        private IWebElement maximum_term_label_card => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-home-page/div/div/div[1]/div[2]/label"));
        private IWebElement compare_rate_button => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-home-page/div/div/div[1]/pgcard/div/div[2]/div[3]/button"));

        private IWebElement label_text => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-home-page/div/div/div[1]/div[3]/label"));
        public void goDownToElement()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", label_text);
        }




        public void EnterAmountToInvest(int percent)
        {
            
            Actions actions = new Actions(driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'left:" + percent + "%')", amount_to_invest_slider);
            Actions builder = new Actions(driver);
            builder.MoveToElement(amount_to_invest_slider).Click(amount_to_invest_slider);
            builder.Perform();
            
        }

        public void EnterMaximumTerm(int percent)
        {
            Actions actions = new Actions(driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'left:" + percent + "%')", maximum_term_slider);
            Actions builder = new Actions(driver);
            builder.MoveToElement(maximum_term_slider).Click(maximum_term_slider);
            builder.Perform();

        }

        public void ClickCompareRatesButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(compare_rate_button).Build().Perform();
        }

        public float getIntrestRate()
        {
            return float.Parse(intrest_rate_card.Text.Split("%")[0], CultureInfo.InvariantCulture.NumberFormat);
        }

        public float getTotalReturn()
        {
            return float.Parse(total_return_label_card.Text.Split(" ")[1], CultureInfo.InvariantCulture.NumberFormat);
        }

        public float getAmountToInvest()
        {
            return float.Parse(amount_to_invest_label_card.Text.Split(" ")[1]);
        }

        public int getMaximumTerm()
        {
            return Int32.Parse((maximum_term_label_card.Text.Split(" "))[0]);
        }
    }
}
