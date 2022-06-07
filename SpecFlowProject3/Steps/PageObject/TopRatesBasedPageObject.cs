using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowProject2.Steps.PageObject
{

    class TopRatesBasedPageObject
    {
        private readonly String url = @"https://cgcashgroup-dev-01.azurewebsites.net/";
        private readonly IWebDriver driver;

        public const int DefaultWaitInSecondes = 5;
        
        public TopRatesBasedPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement amount_to_invest_slider => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/pg-slider[1]/div/pg-slider-handle/div"));
        private IWebElement maximum_term_slider => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/pg-slider[2]/div/pg-slider-handle/div"));

        private IWebElement type_of_providers_banks_button => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/div[3]/div/button[1]"));

        private IWebElement type_of_providers_credit_union_banks_button => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/div[3]/div/button[2]"));

        private IWebElement type_of_provider_trust_companies_button => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/div[3]/div/button[3]"));

        private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> providers_list => driver.FindElements(By.ClassName("span-style"));

        private IWebElement Amount_to_invest_slider_value => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/p[3]"));
        private IWebElement Maximum_Term_slider_value => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/p[4]"));
        private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> intrest_rates_list => driver.FindElements(By.ClassName("td-text"));

        private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> provider_names_and_total_returns => driver.FindElements(By.ClassName("td-text"));

        private IWebElement retourn_button => driver.FindElement(By.ClassName("btnicon"));

        private IWebElement cards_list_proviers(int pos_card ) => (driver.FindElements(By.ClassName("card-progress"))[pos_card]);

        private IWebElement intrest_rate_of_specific_providers(int pos_provider) => (driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/table/tbody/tr["+pos_provider+"]/pgcard/div/div[2]/td[1]")));
        private IWebElement total_return_of_specific_provider(int pos_provider) => (driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/table/tbody/tr["+pos_provider+"]/pgcard/div/div[2]/td[3]/p[1]/span")));

        IWebElement show_more_provider_button => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/div[2]/div/button"));
        private IWebElement name_of_specific_provider(int pos_provider) => (driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/table/tbody/tr["+pos_provider+"]/pgcard/div/div[2]/td[2]/label")));
        private IWebElement card_Text => (driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[1]/app-filter-list/div/div[2]/p[5]")));
        public void goDownToElement()
        {
            Actions action = new Actions(driver);
            for (int i = 0; i < 3; i++)
            {
                action.SendKeys(Keys.ArrowDown).Build().Perform();

            }
            //action.SendKeys(Keys.ArrowDown);

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

        public void ClickBanksProviderBanksButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(type_of_providers_banks_button).Build().Perform();
        }

        public void ClickCreditUnionsProviderButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(type_of_providers_credit_union_banks_button).Build().Perform();
        }

        public void ClickTrustCompaniesProviderButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(type_of_provider_trust_companies_button).Build().Perform();
        }

        public float getAmountToInvest()
        {
            return float.Parse(Amount_to_invest_slider_value.Text.Split(" ")[1]);
        }

        public int getMaximumTerm()
        {
            //Console.WriteLine("this the maximumTerm =");
            //Console.WriteLine((Maximum_Term_slider_value.Text.Split(" "))[0]);
            return Int32.Parse((Maximum_Term_slider_value.Text.Split(" "))[0]);
        }

        public float getIntrestRateOfSpecificProvider(int pos_provider)
        {
            //Console.WriteLine("intrest Rate of provider =");
            //Console.WriteLine(intrest_rate_of_specific_providers(pos_provider).Text.Split("%")[0]);
            return float.Parse(intrest_rate_of_specific_providers(pos_provider).Text.Split("%")[0], CultureInfo.InvariantCulture.NumberFormat);
        }

        public string getNameOfSpecificProviedr(int pos_provider)
        {
            return providers_list[2 * pos_provider].Text;
        }

        public float getTotalReturnOfSpecificProvider(int pos_provider)
        {
            //Console.WriteLine("provider names total return =");
            //Console.WriteLine(total_return_of_specific_provider(pos_provider).Text.Split(" ")[1]);
            return float.Parse(total_return_of_specific_provider(pos_provider).Text.Split(" ")[1], CultureInfo.InvariantCulture.NumberFormat);
        }

        public void clickReturnButton()
        {
            Actions actions = new Actions(driver);
            actions.Click(retourn_button).Build().Perform();
        }

        public void clickInProviderCard(int pos_provider)
        {
            Actions actions = new Actions(driver);
            actions.Click(cards_list_proviers(pos_provider)).Build().Perform();
        }

        public int getNumberOfProvider()
        {
            return intrest_rates_list.Count;
        }

        public String getNameOfProvider(int pos_provider)
        {
            return name_of_specific_provider(pos_provider).Text;
        }

    }
}
