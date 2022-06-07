using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace SpecFlowProject2.Steps.Steps_of_provider_list_page
{
    [Binding]
    public sealed class calculatorOfTotalReturnOfAllProviders
    {
        TopRatedObjectPage topRatedObjectPage = new TopRatedObjectPage(HookInitialization.driver);
        [Then(@"the calculator of total return should give the correct result")]
        public void ThenTheCalculatorOfTotalReturnShouldGiveTheCorrectResult()
        {
            System.Threading.Thread.Sleep(5000);
            float amount_to_invest = topRatedObjectPage.getAmountToInvest();
            int maximum_term = topRatedObjectPage.getMaximuTerm();
            int nbJour;
            if (maximum_term == 30 || maximum_term == 60 || maximum_term == 90)
            {
                nbJour = maximum_term;
            }
            else
            {
                nbJour = maximum_term * 365;
            }
            float correct_result_of_total_return_of_specific_provider;
            float total_return_of_specific_provider;
            float intrest_rate_of_specific_provider;
            for(int index_provider = 1; index_provider < 7; index_provider++)
            {
                total_return_of_specific_provider = topRatedObjectPage.getTotalReturnOfSpecificProvider(index_provider);
                intrest_rate_of_specific_provider = topRatedObjectPage.getIntrestRateOfSpecificProvider(index_provider);
                correct_result_of_total_return_of_specific_provider = amount_to_invest * intrest_rate_of_specific_provider * nbJour / 36500;
                float diff=MathF.Abs(total_return_of_specific_provider - correct_result_of_total_return_of_specific_provider) / total_return_of_specific_provider;
                diff.Should().BeLessThanOrEqualTo(0.5F);

            }
        }





    }
}
