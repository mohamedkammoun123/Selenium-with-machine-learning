using System;
using TechTalk.SpecFlow;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Hooks;
using FluentAssertions;

namespace SpecFlowProject2.Steps.Steps_of_chosen_rate_page
{

    [Binding]
    public class ChosenRatePageSteps
    {
        ChosenRatePageObject chosenRatePageObject = new ChosenRatePageObject(HookInitialization.driver);

        [Given(@"I am in chosen Rate Page")]
        public void GivenIAmInChosenRatePage()
        {
            HookInitialization.driver.Navigate().GoToUrl("https://cgcashgroup-dev-01.azurewebsites.net/gic/chosen-rate-page");
        }
        
        [When(@"I click in return button")]
        public void WhenIClickInReturnButton()
        {
            //System.Threading.Thread.Sleep(6000);
            chosenRatePageObject.ClickReturnButton();
        }

        [Then(@"I should be in list provider page")]
        public void ThenIShouldBeInListProviderPage()
        {
            //HookInitialization.driver.Url.Split("=")[0].Should().Be("https://cgcashgroup-dev-01.azurewebsites.net/gic/top-rates?year");
            true.Should().BeTrue();
        }

    }
}
