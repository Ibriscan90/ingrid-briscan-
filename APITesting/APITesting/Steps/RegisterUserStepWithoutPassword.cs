using TechTalk.SpecFlow;
using APITesting.Models;
using System.Net.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APITesting.Steps
{
    [Binding]
    public class RegisterUserStepWithoutPassword
    {
        private static readonly string ENDPOINT = "https://reqres.in/api/register";
        private HttpResponseMessage httpResponse;
        private RegisterUserRequest registerUserRequest;

        [Given(@"I populate the API call for registration without a password")]
        public void GivenIPopulateTheAPICallForRegistrationWithoutAPassword()
        {
            registerUserRequest = new RegisterUserRequest { email = "eve.holt@reqres.in"};
        }

        [When(@"I call the API to register a new user account")]
        public async Task WhenICallTheAPIToRegisterANewUserAccount()
        {
            var httpClient = new HttpClient();

            var serialized = JsonConvert.SerializeObject(registerUserRequest);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            httpResponse = await httpClient.PostAsync(ENDPOINT, stringContent);
        }

        [Then(@"the  registration call is unsuccessful")]
        public void ThenTheRegistrationCallIsUnsuccessful()
        {
            HttpStatusCode statusCode = httpResponse.StatusCode;
            int statusCodeValue = (int)statusCode;
            Assert.AreEqual(statusCodeValue, 400);
        }

        [Then(@"the user cannot be registered")]
        public async void ThenTheUserCannotBeRegistered()
        {
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            Assert.IsTrue(responseContent.Contains("error"));
            Assert.IsTrue(responseContent.Contains("Missing password"));
        }
    }
}
