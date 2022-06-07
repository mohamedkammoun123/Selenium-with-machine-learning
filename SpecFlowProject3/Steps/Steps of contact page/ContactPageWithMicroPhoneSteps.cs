using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.Steps.PageObject;
namespace SpecFlowProject2.Steps.Steps_of_contact_page
{
    [Binding]
    public class ContactPageWithMicroPhoneSteps
    {
        ContactPageObject contactPageObject = new ContactPageObject(HookInitialization.driver);
        int verro = 0;
        public async Task<String> GetMessageAsync(String name)
        {
            //HttpClient client = new HttpClient();
            String message;
            //tring response = await client.GetStringAsync("http://127.0.0.1:5000/" + pathSound);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync("http://127.0.0.1:5000/"+name))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        message = await content.ReadAsStringAsync();
                    }
                }
            }
            return message;
        }
        [Given(@"I entre the name from my microPhone")]
        public async void GivenIEntreTheNameFromMyMicroPhone()
        {
            System.Threading.SpinWait.SpinUntil(() => verro == 0);
            String message = await GetMessageAsync("name");
            contactPageObject.setFirstNameInLabel(message);
            
            verro++;
        }

        [Given(@"I enter last name from my microPhone")]
        public async void GivenIEnterLastNameFromMyMicroPhone()
        {
            System.Threading.SpinWait.SpinUntil(() => verro == 1);
            String message = await GetMessageAsync("name");
            contactPageObject.setLastNameInLabel("hello");
            verro++;
        }

        [Given(@"I enter my best contact from my microPhone")]
        public void GivenIEnterMyBestContactFromMyMicroPhone()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
