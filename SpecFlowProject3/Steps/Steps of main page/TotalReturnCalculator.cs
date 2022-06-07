using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Hooks;
using FluentAssertions;


namespace SpecFlowProject2.Steps
{
    [Binding]
    public sealed class TotalReturnCalculator
    {

        MainPageObject mainPageObject = new MainPageObject(HookInitialization.driver);
        [Then(@"the Calculator should giving the truly the total return")]
        public void ThenTheCalculatorShouldGivingTheTrulyTheTotalReturn()
        {
            //Boolean b = true;
            //b.Should().BeFalse();
            //mainPageObject.goDownToElement();
            int[] intrest_rate_percents = { 0, 10, 20,30,40,50,60,70,80,100 };
            int[] maximum_term_percents = { 0, 14, 28, 42, 56, 70, 84, 100 };
            float the_truly_total_return;
            for (int indexOfIntrestRate=0; indexOfIntrestRate < intrest_rate_percents.Length; indexOfIntrestRate++)
            {
                for(int indexOfMaximumTerm = 0; indexOfMaximumTerm < maximum_term_percents.Length; indexOfMaximumTerm++)
                {
                    //System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("test1");
                    mainPageObject.EnterAmountToInvest(intrest_rate_percents[indexOfIntrestRate]);
                    Console.WriteLine("test2");
                    //System.Threading.Thread.Sleep(2000);
                    mainPageObject.EnterMaximumTerm(maximum_term_percents[indexOfMaximumTerm]);
                    Console.WriteLine("test3");
                    float amountToInvest = mainPageObject.getAmountToInvest();
                    Console.WriteLine("test4");
                    float maximumTerm = mainPageObject.getMaximumTerm();
                    Console.WriteLine("test5");
                    float intrestRate = mainPageObject.getIntrestRate();
                    Console.WriteLine("test6");
                    if (indexOfMaximumTerm <= 2)
                    {
                        Console.WriteLine("test7");
                        the_truly_total_return = amountToInvest * maximumTerm * intrestRate / 36500;
                        Console.WriteLine("test8");
                    }
                    else
                    {
                        Console.WriteLine("test9");
                        the_truly_total_return = amountToInvest * maximumTerm * intrestRate/100;
                        Console.WriteLine("test10");
                    }
                    
                    float totalReturn = mainPageObject.getTotalReturn();
                    if (totalReturn == 0)
                    {
                        totalReturn.Should().NotBe(0);
                    }
                    float diff = System.MathF.Abs(the_truly_total_return - totalReturn)/totalReturn;
                    diff.Should().BeLessThanOrEqualTo(0.1F);

                }
            }
        }

    }
}
