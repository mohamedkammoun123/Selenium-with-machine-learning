using System;
using TechTalk.SpecFlow;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Hooks;
using FluentAssertions;

namespace SpecFlowProject3.Steps.Stpes_of_list_provider_page
{
    [Binding]
    public class SliderOfListProviederSteps
    {
        TopRatesBasedPageObject topRatesBasedPageObject = new TopRatesBasedPageObject(HookInitialization.driver);
        [Given(@"I move provider amount to invest to (.*)")]
        public void GivenIMoveProviderAmountToInvestTo(string p0)
        {
            topRatesBasedPageObject.EnterAmountToInvest(Int32.Parse(p0));
        }

        [Given(@"I move maximum term provider slider (.*)")]
        public void GivenIMoveMaximumTermProviderSlider(string p0)
        {
            topRatesBasedPageObject.EnterMaximumTerm(Int32.Parse(p0));
        }

    }
}
