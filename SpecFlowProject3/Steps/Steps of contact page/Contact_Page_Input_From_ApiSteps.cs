using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace SpecFlowProject3.Steps.Steps_of_contact_page
{
    [Binding]
    public class Contact_Page_Input_From_ApiSteps
    {
        ContactPageObject contactPageObject= new ContactPageObject(HookInitialization.driver);
        int verro = -1;
        static HttpClient client = new HttpClient();
        public async Task<String> GetMessageAsync()
        {
            //HttpClient client = new HttpClient();
            String message;
            //tring response = await client.GetStringAsync("" + pathSound);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync("http://127.0.0.1:5000//input_test"))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        message = await content.ReadAsStringAsync();
                    }
                }
            }
            return message;
        }
        
        [Given(@"i am in contact page")]
        public void GivenIAmInContactPage()
        {
            System.Threading.SpinWait.SpinUntil(() => verro == -1);
            HookInitialization.driver.Navigate().GoToUrl("https://cgcashgroup-dev-01.azurewebsites.net/gic/contact-page");
            verro++;
        }

        [When(@"i givent all the input form api correct")]
        public async void WhenIGiventAllTheInputFormApiCorrect()
        {
            System.Threading.SpinWait.SpinUntil(() => verro == 0);
            String message = await GetMessageAsync();
            Console.WriteLine("this is the message:______");
            Console.WriteLine(message);
            String[] inputs = message.Split(' ');
            contactPageObject.setFirstNameInLabel(inputs[1]);
            contactPageObject.setLastNameInLabel(inputs[2]);
            for (int i = 0; i < inputs.Length; i++)
            {
                Console.WriteLine("this tab has");
                Console.WriteLine(inputs[i]);
            }
            if (inputs[3] == "0")
            {
                contactPageObject.pressFrenchButton();
            }
            else
            {
                contactPageObject.pressEnglishButton();
            }
            if (inputs[4] == "0")
            {
                contactPageObject.pressByPhoneButton();
                contactPageObject.setPhoneInLabel(inputs[5]);
            }
            else
            {
                contactPageObject.pressByEmailButton();
                contactPageObject.setEmailInLabel(inputs[5]);
            }
            verro++;
        }

        [When(@"i click in subbmit button")]
        public async void WhenIClickInSubbmitButton()
        {
            System.Threading.SpinWait.SpinUntil(() => verro == 1);
            Console.WriteLine("wait to code this ");
            verro++;
        }
        [Then(@"I should be in this page")]
        public async void ThenIShouldBeInThisPage()
        {
            System.Threading.SpinWait.SpinUntil(() => verro == 2);
            Console.WriteLine("wait to code the condition");
        }

    }
}
