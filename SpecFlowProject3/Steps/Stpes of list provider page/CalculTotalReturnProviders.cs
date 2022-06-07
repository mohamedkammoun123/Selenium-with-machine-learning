using System;
using TechTalk.SpecFlow;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Hooks;
using FluentAssertions;

namespace SpecFlowProject2.Steps.Stpes_of_list_provider_page
{

    [Binding]
    public class CalculTotalReturnProviders
    {
        MainPageObject mainPageObject = new MainPageObject(HookInitialization.driver);
        TopRatesBasedPageObject topRatesBased = new TopRatesBasedPageObject(HookInitialization.driver);
        
        [Then(@"the Calculator should giving the total return of all providers")]
        public void ThenTheCalculatorShouldGivingTheTotalReturnOfAllProviders()
        {
            //Boolean b = true;
            //b.Should().BeFalse();
            float amountToInvest = topRatesBased.getAmountToInvest();
           
            
            int maximumTerm = topRatesBased.getMaximumTerm();
            
            float intrest_rate;
            float total_return;
            float truly_total_return;
            for (int index_provider = 1; index_provider <= 6; index_provider++)
            {
                total_return = topRatesBased.getTotalReturnOfSpecificProvider(index_provider);
                intrest_rate = topRatesBased.getIntrestRateOfSpecificProvider(index_provider);
                truly_total_return = amountToInvest * maximumTerm * intrest_rate * 360 / 36000;
                if (maximumTerm == 30 || maximumTerm == 60 || maximumTerm == 90)
                {
                    truly_total_return = truly_total_return / 360;
                }
                float diff = System.MathF.Abs(truly_total_return - total_return) / total_return;
                Console.WriteLine("pos_provider===>"+index_provider+"////"+"amount to invest  = " + amountToInvest+" | "+"maximum term= "+maximumTerm+" | "+"intrest rate = "+intrest_rate+" | "+"total return= "+total_return);
                Console.WriteLine("the truly total return = " + truly_total_return);
                diff.Should().BeLessThanOrEqualTo(1000F);
            }
        }
    }
}
