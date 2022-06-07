using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
namespace SpecFlowProject2.Steps.Stepsofcontactpage
{
    [Binding]
    public class SubbmitButtonCheckSteps
    {
        ContactPageObject contactPageObject = new ContactPageObject(HookInitialization.driver);
        Boolean verifCord;
        [Given(@"I am in contact Page")]
        public void GivenIAmInContactPage()
        {
            HookInitialization.driver.Navigate().GoToUrl("https://cgcashgroup-dev-01.azurewebsites.net/gic/contact-page");
        }

        [Given(@"I enter the first name correctly (.*)")]
        public void GivenIEnterTheFirstNameCorrectly(string p0)
        {
            contactPageObject.setFirstNameInLabel(p0);
            verifCord = contactPageObject.IsAllLetters(p0);

        }

        [Given(@"I enter the last name correctly (.*)")]
        public void GivenIEnterTheLastNameCorrectly(string p0)
        {
            contactPageObject.setLastNameInLabel(p0);
            verifCord = verifCord & contactPageObject.IsAllLetters(p0);
        }

        [Given(@"I press In language Button correctly (.*)")]
        public void GivenIPressInLanguageButtonCorrectly(string p0)
        {
            if (p0 == "eng")
            {
                contactPageObject.pressEnglishButton();

            }
            if (p0 == "fr")
            {
                contactPageObject.pressFrenchButton();
            }
        }

        [Given(@"I press In the bust way button correctly (.*)")]
        public void GivenIPressInTheBustWayButtonCorrectly(string p0)
        {
            if (p0 == "email")
            {
                contactPageObject.pressByEmailButton();
                ScenarioContext.Current["bestWay"] = "email";
            }
            if (p0 == "phone")
            {
                contactPageObject.pressByPhoneButton();
                ScenarioContext.Current["bestWay"] = "phone";
            }
        }

        [Given(@"I enter my contact correctly (.*)")]
        public void GivenIEnterMyContactCorrectly(string p0)
        {
            if (ScenarioContext.Current["bestWay"].ToString() == "phone")
            {
                contactPageObject.setPhoneInLabel(p0);
                verifCord = verifCord & contactPageObject.IsValidPhoneNumber(p0);
            }
            if (ScenarioContext.Current["bestWay"].ToString() == "email")
            {
                contactPageObject.setEmailInLabel(p0);
                verifCord = verifCord & contactPageObject.IsValidEmail(p0);
            }

        }

        [Then(@"I should be  In Contact From Sent Page")]
        public void ThenIShouldBeInContactFromSentPage()
        {
            
            
                System.Threading.Thread.Sleep(5000);
                contactPageObject.pressSubbmitButton();
            System.Threading.Thread.Sleep(5000);
            HookInitialization.driver.Url.Should().Be("https://cgcashgroup-dev-01.azurewebsites.net/gic/ContactFormSent");
            
        }

    }
}
