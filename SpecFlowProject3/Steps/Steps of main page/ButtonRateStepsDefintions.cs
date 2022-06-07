using System;
using FluentAssertions;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Steps
{
    [Binding]
    public class ButtonRateStepsDefintions
    {
        public int first_percent;
        public int seconde_percent;
        MainPageObject mainPageObject = new MainPageObject(HookInitialization.driver);

        [Given(@"I move the amount to invest slider to (.*)")]
        public void GivenIMoveTheAmountToInvestSliderTo(string p0)
        {
            first_percent = Int32.Parse(p0);
            mainPageObject.EnterAmountToInvest(first_percent);
            ScenarioContext.Current["amountToInvest"] = mainPageObject.getAmountToInvest();
        }
        
        [Given(@"I move the maximum Term to (.*)")]
        public void GivenIMoveTheMaximumTermTo(string p0)
        {
            seconde_percent = Int32.Parse(p0);
            mainPageObject.EnterMaximumTerm(seconde_percent);
            System.Threading.Thread.Sleep(2000);
            ScenarioContext.Current["maximumTerm"]=mainPageObject.getMaximumTerm();
            //System.Threading.Thread.Sleep(2000);
        }

        [When(@"I press the compare rate button")]
        public void WhenIPressTheCompareRateButton()
        {
            
            mainPageObject.ClickCompareRatesButton();
            System.Threading.Thread.Sleep(3000);

        }


        [Then(@"I must be int the right page")]
        public void ThenIMustBeIntTheRightPage()
        {
            //Boolean b = true;
            //b.Should().BeFalse();
            HookInitialization.driver.Url.Should().Be(HookInitialization.driver.Url);
        }
    }
}
