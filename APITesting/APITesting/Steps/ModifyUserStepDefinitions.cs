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
    public class ModifyUserStepDefinitions
    {
        private static readonly string ENDPOINT = "https://reqres.in/api/users/2";
        private HttpResponseMessage httpResponse;
        private CreateUserRequest modifyUserRequest;
        private string newName = "Cooler";
        private string newJob = "Dev";

        [Given(@"I populate the API call to modify an existing user")]
        public void GivenIPopulateTheAPICallToModifyAnExistingUser()
        {
            modifyUserRequest = new CreateUserRequest { FirstName = newName, Job = newJob };
        }

        [When(@"I make the API call to modify the user")]
        public async Task WhenIMakeTheAPICallToModifyTheUser()
        {
            var httpClient = new HttpClient();

            var serialized = JsonConvert.SerializeObject(modifyUserRequest);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            httpResponse = await httpClient.PutAsync(ENDPOINT, stringContent);
        }

        [Then(@"the PUT call is successful")]
        public void ThenThePUTCallIsSuccessful()
        {
            HttpStatusCode statusCode = httpResponse.StatusCode;
            int statusCodeValue = (int)statusCode;
            Assert.AreEqual(statusCodeValue, 200);
        }

        [Then(@"the user profile is updated")]
        public async void ThenTheUserProfileIsUpdated()
        {
            var expectedString1 = newName;
            var expectedString2 = newJob;
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            Assert.IsTrue(responseContent.Contains(expectedString1));
            Assert.IsTrue(responseContent.Contains(expectedString2));
        }
    }
}
