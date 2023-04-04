using APITesting.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APITesting.Steps
{
    [Binding]
    public class CreateUserSteps
    {
        private static readonly string ENDPOINT = "https://reqres.in/api/users";
        private HttpResponseMessage httpResponse;
        private CreateUserRequest createUserRequest;

        [Given(@"I populate the API call")]
        public void GivenIPopulateTheAPICall()
        {
            createUserRequest = new CreateUserRequest { FirstName = "Ingrid", LastName = "Briscan", Job = "QA", username = "Ingrid" };
        }

        [When(@"I make the API call to create a new user")]
        public async Task WhenIMakeTheAPICallToCreateANewUserAsync()
        {
            var httpClient = new HttpClient();

            var serialized = JsonConvert.SerializeObject(createUserRequest);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            httpResponse = await httpClient.PostAsync(ENDPOINT, stringContent);
        }

        [Then(@"the call is successful")]
        public void ThenTheCallIsSuccessful()
        {
            HttpStatusCode statusCode = httpResponse.StatusCode;
            int statusCodeValue = (int)statusCode;
            Assert.AreEqual(statusCodeValue, 201);
        }

        [Then(@"the user profile is created")]
        public async void ThenTheUserProfileIsCreated()
        {
            var expectedString = "Ingrid";
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            Assert.IsTrue(responseContent.Contains(expectedString));
        }
    }
}
