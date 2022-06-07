using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowProject2.Steps.PageObject
{
    class TopRatedObjectPage
    {
        private readonly String url = @"https://cgcashgroup-dev-01.azurewebsites.net/";
        private readonly IWebDriver driver;
        public TopRatedObjectPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement amount_to_invest_slider => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/pg-slider[1]/div/pg-slider-handle/div"));
        IWebElement maximum_term_slider => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/pg-slider[2]/div/pg-slider-handle/div"));
        IWebElement button_type_of_provider_bank => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/div[3]/div/button[1]"));
        IWebElement button_type_of_provider_credit_unions => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/div[3]/div/button[2]"));
        IWebElement button_type_of_provider_trust_companies => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/div[3]/div/button[3]"));
        IWebElement intrest_rate_card_of_specific_provider(int indexProvider) => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/table/tbody/tr["+indexProvider+"]/pgcard/div/div[2]/td[1]"));
        IWebElement name_provider_card_of_specific_provider(int indexProvider) => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/table/tbody/tr[" + indexProvider + "]/pgcard/div/div[2]/td[2]/label"));
        IWebElement total_return_card_of_specific_provider(int indexProvider) => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/table/tbody/tr["+indexProvider+"]/pgcard/div/div[2]/td[3]/p[1]/span"));
        IWebElement label_of_specific_provider(int indexProvider) => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/table/tbody/tr[" + indexProvider + "]/pgcard/div/div[2]"));
        IWebElement amount_to_invest_card => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/p[3]"));
        IWebElement maximum_term_card => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/p[4]"));
        IWebElement show_more_provider_button => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/div[2]/div/button"));
        public void goDownToElement()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();",show_more_provider_button);
            
        }
        public float getAmountToInvest()
        {
            return float.Parse(amount_to_invest_card.Text.Split(" ")[1]);
        }
        public int getMaximuTerm()
        {
            return Int32.Parse((maximum_term_card.Text.Split(" "))[0]);
        }
        public float getIntrestRateOfSpecificProvider(int index_provider)
        {
            return float.Parse(intrest_rate_card_of_specific_provider(index_provider).Text.Split("%")[0], CultureInfo.InvariantCulture.NumberFormat);
        }
        public String getNameOfSpecificProvider(int index_provider)
        {
            return name_provider_card_of_specific_provider(index_provider).Text;
        }
        public float getTotalReturnOfSpecificProvider(int index_provider)
        {
            return float.Parse(total_return_card_of_specific_provider(index_provider).Text.Split(" ")[1], CultureInfo.InvariantCulture.NumberFormat);
        }
        public void clickInSpecificProvider(int indexProvider)
        {
            Actions actions = new Actions(driver);
            actions.Click(label_of_specific_provider(indexProvider)).Build().Perform();
        }

    }
}
