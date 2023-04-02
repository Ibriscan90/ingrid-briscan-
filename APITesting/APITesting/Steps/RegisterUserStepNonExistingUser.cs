using TechTalk.SpecFlow;
using APITesting.Models;
using System.Net.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APITesting
{
    [Binding]
    public class RegisterUserStepNonExistingUser
    { 

    private static readonly string ENDPOINT = "https://reqres.in/api/register";
    private HttpResponseMessage httpResponse;
    private RegisterUserRequest registerUserRequest;
    
        [Given(@"I populate the API call for registration with a non existing user")]
        public void GivenIPopulateTheAPICallForRegistrationWithANonExistingUser()
        {
            registerUserRequest = new RegisterUserRequest { email = "ingrid@gmail.com", password = "ilovedogs90" };
        }

        [When(@"I make the API call to register a new user account")]
        public async Task WhenIMakeTheAPICallToRegisterANewUserAccount()
        {
            var httpClient = new HttpClient();

            var serialized = JsonConvert.SerializeObject(registerUserRequest);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            httpResponse = await httpClient.PostAsync(ENDPOINT, stringContent);
        }

        [Then(@"the  registration call is not successful")]
        public void ThenTheRegistrationCallIsNotSuccessful()
        {
            HttpStatusCode statusCode = httpResponse.StatusCode;
            int statusCodeValue = (int)statusCode;
            Assert.AreEqual(statusCodeValue, 400);
        }

        [Then(@"the user is not registered")]
        public async void ThenTheUserIsNotRegistered()
        {
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            Assert.IsTrue(responseContent.Contains("error"));
            Assert.IsTrue(responseContent.Contains("Note: Only defined users succeed registration"));


        }
    }
}
