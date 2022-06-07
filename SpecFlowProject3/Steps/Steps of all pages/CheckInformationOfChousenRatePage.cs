using System;
using FluentAssertions;
using TechTalk.SpecFlow;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Hooks;
namespace SpecFlowProject2.Steps.Steps_of_all_pages
{
    [Binding]
    public class CheckInformationOfChousenRatePage
    {
        ChosenRatePageObject chosenRatePageObject = new ChosenRatePageObject(HookInitialization.driver);

        [Then(@"the chosen rate page should have the correct information of chosen provider")]
        public void ThenTheChosenRatePageShouldHaveTheCorrectInformationOfChosenProvider()
        {
            //Boolean b = true;
            //b.Should().BeFalse();
            Console.WriteLine("maximum term is " + ScenarioContext.Current["maximumTerm"]);
            Console.WriteLine("maximum term should be" + chosenRatePageObject.getMaximumTerm());
            int maximumTerm = Int32.Parse(ScenarioContext.Current["maximumTerm"].ToString());
            maximumTerm.Should().BeLessThanOrEqualTo(chosenRatePageObject.getMaximumTerm());
            ScenarioContext.Current["amountToInvest"].Should().Be(chosenRatePageObject.getAmountToInvest());
            ScenarioContext.Current["provider_name"].Should().Be(chosenRatePageObject.getProviderName());
        }

    }
}
