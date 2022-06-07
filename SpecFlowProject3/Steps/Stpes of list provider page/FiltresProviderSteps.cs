using System;
using TechTalk.SpecFlow;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Hooks;
using FluentAssertions;

namespace SpecFlowProject3.Steps.Stpes_of_list_provider_page
{
    [Binding]
    public class FiltresProviderSteps
    {
        String[] providerBanks = { "Home Bank - Agent", "Canadian Western Bank", "Equitable Bank", "VersaBank", "ADS Canadian Bank", "Bank of Montreal", "Bridgewater Bank", "*RFA Bank of Canada", "Haventree Bank", "Wealth One Bank Canada", "Shinhan Bank Canada", "Equitable Trust" };
        String[] CreditUnions = { };
        private Boolean checkNameProviderInBanks(String name_provider)
        {
            for (int index_provider = 0; index_provider < providerBanks.Length; index_provider++)
            {
                if (name_provider == providerBanks[index_provider])
                {
                    return true;
                }
            }
            return false;
        }
        TopRatesBasedPageObject topRatesBasedPageObject = new TopRatesBasedPageObject(HookInitialization.driver);
        [Given(@"I press In Any Filtres (.*)")]
        public void GivenIPressInAnyFiltres(string p0)
        {
            if (p0 == "banks")
            {
                topRatesBasedPageObject.goDownToElement();
                System.Threading.Thread.Sleep(3000);
                topRatesBasedPageObject.ClickCreditUnionsProviderButton();
                
                topRatesBasedPageObject.ClickTrustCompaniesProviderButton();
            }
        }

        [Then(@"I Should be watch the correct list provider")]
        public void ThenIShouldBeWatchTheCorrectListProvider()
        {
            Boolean verif=false;
            for (int index_provider = 1; index_provider <= 6; index_provider++)
            {
                try
                {
                    Console.WriteLine("name provider =" + topRatesBasedPageObject.getNameOfProvider(index_provider));
                    verif = checkNameProviderInBanks(topRatesBasedPageObject.getNameOfProvider(index_provider));
                }
                catch
                {
                    Console.WriteLine("out of index "+index_provider);
                    if (index_provider == 1)
                    {
                        verif = false;
                        verif.Should().BeTrue();
                    }
                }
                //verif.Should().BeTrue();
            }

        }

    }
}
