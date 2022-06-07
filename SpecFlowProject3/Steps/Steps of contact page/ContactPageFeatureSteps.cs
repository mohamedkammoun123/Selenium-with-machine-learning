using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Steps.PageObject.soundRecognition;
namespace SpecFlowProject2.Steps.Steps_of_contact_page
{
    [Binding]
    public class ContactPageFeatureSteps
    {
        ContactPageObject contactPageObject = new ContactPageObject(HookInitialization.driver);

        [Given(@"I enter the first_name (.*)")]
        public void GivenIEnterTheFirst_Name(string p0)
        {
            contactPageObject.setFirstNameInLabel(p0);
        }

        [Given(@"I enter the last_name (.*)")]
        public void GivenIEnterTheLast_Name(string p0)
        {
            contactPageObject.setLastNameInLabel(p0);
        }

        [Given(@"I enter the language(.*)")]
        public void GivenIEnterTheLanguage(string p0)
        {
            if (p0 == "eng")
            {
                contactPageObject.pressEnglishButton();
            }
            else
            {
                contactPageObject.pressFrenchButton();
            }
        }

        [Given(@"I enter the best way (.*)")]
        public void GivenIEnterTheBestWay(string p0)
        {
            if (p0 == "email")
            {
                contactPageObject.pressByEmailButton();
            }
            else
            {
                contactPageObject.pressByPhoneButton();
            }
        }

        [Given(@"I enter my contact (.*)")]
        public void GivenIEnterMyContact(string p0)
        {
            contactPageObject.goDownToElement();
            try
            {
                contactPageObject.setEmailInLabel(p0);
            }
            catch
            {
                contactPageObject.setPhoneInLabel(p0);
            }
            
        }

        [When(@"I click in subbmit button")]
        public void WhenIClickInSubbmitButton()
        {
            
            contactPageObject.goDownToElement();
            
            
            contactPageObject.pressSubbmitButton();
            
        }

        [Then(@"I should be in the page")]
        public void ThenIShouldBeInThePage()
        {
            System.Threading.Thread.Sleep(2500);
            HookInitialization.driver.Url.Should().Be("https://cgcashgroup-dev-01.azurewebsites.net/gic/ContactFormSent");
        }

    }
}
