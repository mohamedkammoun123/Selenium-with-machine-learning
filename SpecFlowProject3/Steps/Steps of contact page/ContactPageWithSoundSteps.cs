using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Steps.PageObject.soundRecognition;
namespace SpecFlowProject2.Steps.Steps_of_contact_page
{
    [Binding]
    public class ContactPageWithSoundSteps
    {
        TopRatedObjectPage topRatedObject = new TopRatedObjectPage(HookInitialization.driver);
        ContactPageObject contactPageObject = new ContactPageObject(HookInitialization.driver);
        SoundRecognition soundRecognition = new SoundRecognition();
        recognition r = new recognition();

        [When(@"I click in a specific provider(.*)")]
        public void WhenIClickInASpecificProvider(string p0)
        {
            topRatedObject.clickInSpecificProvider(Int32.Parse(p0));
        }

        [Given(@"I enter the first name sound (.*)")]
        public void GivenIEnterTheFirstNameSound(string p0)
        {
            contactPageObject.setFirstNameInLabel(soundRecognition.fromSoundToText(p0));
        }

        [Given(@"I enter the last name (.*)")]
        public void GivenIEnterTheLastName(string p0)
        {
            contactPageObject.setLastNameInLabel(soundRecognition.fromSoundToText(p0));
        }

        [Given(@"I enter my contact sound (.*)")]
        public void GivenIEnterMyContactSound(string p0)
        {
            contactPageObject.setEmailInLabel(soundRecognition.fromSoundToText(p0));
            
        }

    }
}
