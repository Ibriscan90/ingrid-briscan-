using APITesting.Models;
using System.Net.Http;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APITesting.Steps
{
    [Binding]
    public class RegisterUserSteps
    {
        private static readonly string ENDPOINT = "https://reqres.in/api/register";
        private HttpResponseMessage httpResponse;
        private RegisterUserRequest registerUserRequest;

        [Given(@"I populate the API call for registration")]
        public void GivenIPopulateTheAPICallForRegistration()
        {
            registerUserRequest = new RegisterUserRequest { email = "eve.holt@reqres.in", password = "pistol" };
        }

        [When(@"I make the API call to register a new user")]
        public async Task WhenIMakeTheAPICallToRegisterANewUser()
        {
            var httpClient = new HttpClient();

            var serialized = JsonConvert.SerializeObject(registerUserRequest);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            httpResponse = await httpClient.PostAsync(ENDPOINT, stringContent);
        }

        [Then(@"the registration call is successful")]
        public void ThenTheRegistrationCallIsSuccessful()
        {
            HttpStatusCode statusCode = httpResponse.StatusCode;
            int statusCodeValue = (int)statusCode;
            Assert.AreEqual(statusCodeValue, 200);
        }

        [Then(@"the user is succesfully registered")]
        public async void ThenTheUserIsRegistered()
        {
            string responseContent = await httpResponse.Content.ReadAsStringAsync();

            Assert.IsTrue(responseContent.Contains("id"));
            Assert.IsTrue(responseContent.Contains("token"));

        }


    }
}




