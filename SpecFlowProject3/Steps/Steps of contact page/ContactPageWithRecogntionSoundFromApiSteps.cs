using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
using SpecFlowProject2.Steps.PageObject.soundRecognition;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
namespace SpecFlowProject2.Steps.Sound_Recognition_Steps
{
    [Binding]
    public class ContactPageWithRecogntionSoundFromApiSteps
    {
        ContactPageObject contactPageObject = new ContactPageObject(HookInitialization.driver);
        int verro = 0;
        public async Task<String> GetMessageAsync(string pathSound)
        {
            //HttpClient client = new HttpClient();
            String message  ;
            //tring response = await client.GetStringAsync("http://127.0.0.1:5000/" + pathSound);
            using (HttpClient client=new HttpClient())
            {
                using(HttpResponseMessage responseMessage=await client.GetAsync("http://127.0.0.1:5000/" + pathSound))
                {
                    using(HttpContent content = responseMessage.Content)
                    {
                        message = await content.ReadAsStringAsync();
                    }
                }
            }
            return message;
        }
        [Given(@"I entre the name from a sound file (.*)")]
        public async void GivenIEntreTheNameFromASoundFile(string p0)
        {
            System.Threading.SpinWait.SpinUntil(() => verro==0);
            String message = await GetMessageAsync(p0);
            contactPageObject.setFirstNameInLabel(message);
            verro++;
        }

        [Given(@"I enter last name from sound file (.*)")]
        public async void GivenIEnterLastNameFromSoundFile(string p0)
        {
            Console.WriteLine("abc");
            System.Threading.SpinWait.SpinUntil(() => verro == 1);
            String message = await GetMessageAsync(p0);

            contactPageObject.setLastNameInLabel(message);
            verro++;
        }
        [Given(@"I enter the contact (.*)")]
        public async void GivenIEnterTheContact(string p0)
        {
            System.Threading.SpinWait.SpinUntil(() => verro == 2);
            String message = await GetMessageAsync(p0);
            contactPageObject.setPhoneInLabel(message);
            verro++;
        }

        

    }
}
