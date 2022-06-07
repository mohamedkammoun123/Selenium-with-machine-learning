using System;
using System.Diagnostics;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Steps.Stpes_of_list_provider_page
{
    [Binding]
    public class checkCardProviderClick

    {
        private bool IsElementPresent(By by)
        {
            try
            {
                HookInitialization.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        TopRatesBasedPageObject topRatesBasedPageObject = new TopRatesBasedPageObject(HookInitialization.driver);

        [Given(@"I Am In List Provider Page after I chose amount to invest and maximum Term  (.*),(.*)")]
        public void GivenIAmInListProviderPageAfterIChoseAmountToInvestAndMaximumTerm(string p0, string p1)
        {
            HookInitialization.driver.Navigate().GoToUrl("https://cgcashgroup-dev-01.azurewebsites.net/gic/top-rates?amount=" + p0+ "&year=" +p1);
            Console.WriteLine("auuuu");
            WebDriverWait wait = new WebDriverWait(HookInitialization.driver, TimeSpan.FromSeconds(20));
            Console.WriteLine("auuuu1");
            wait.Until(driver => driver.FindElement(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/table/tbody/tr[1]/pgcard/div/div[2]")));
            Console.WriteLine("auuuu2");
            topRatesBasedPageObject.goDownToElement();
            Console.WriteLine("auuuu3");
        }

        [When(@"I press in any provider (.*)")]
        public void WhenIPressInAnyProvider(string p0)
        {
            System.Threading.Thread.Sleep(2500);
            Debug.Assert(IsElementPresent(By.XPath("/html/body/app-root/simplywhite-layout/page-container/div/div[1]/app-list-top-rate/div/div[2]/app-rates-list/div/div[2]/table/tbody/tr[" + 1 + "]/pgcard/div/div[2]/td[1]")));
            ScenarioContext.Current["provider_name"] =topRatesBasedPageObject.getNameOfSpecificProviedr(Int32.Parse(p0));
            topRatesBasedPageObject.clickInProviderCard(Int32.Parse(p0));    
        }

        [Then(@"I should be in the chosen rate page")]
        public void ThenIShouldBeInTheChosenRatePage()
        {
            System.Threading.Thread.Sleep(2500);
            HookInitialization.driver.Url.Should().Be("https://cgcashgroup-dev-01.azurewebsites.net/gic/chosen-rate-page");
        }



    }
}
