using System;
using FluentAssertions;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Steps.Steps_of_chosen_rate_page
{
    [Binding]
    public class CheckGetInTouchButton
    {
        ChosenRatePageObject chosenRatePageObject = new ChosenRatePageObject(HookInitialization.driver);
        [When(@"I click in get in touch button")]
        public void WhenIClickInGetInTouchButton()
        {
            System.Threading.Thread.Sleep(5000);
            chosenRatePageObject.ClickGetInTouchButton();
        }

        [Then(@"I should be in contact page")]
        public void ThenIShouldBeInContactPage()
        {
            //Boolean b = true;
            //b.Should().BeFalse();
            System.Threading.Thread.Sleep(5000);
            HookInitialization.driver.Url.Should().Be("https://cgcashgroup-dev-01.azurewebsites.net/gic/contact-page");
        }


    }
}
