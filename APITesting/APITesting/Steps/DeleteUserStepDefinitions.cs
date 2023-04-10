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
    public class DeleteUserStepDefinitions
    {
        private static readonly string ENDPOINT = "https://reqres.in/api/users/2";
        private HttpResponseMessage httpResponse;

        [Given(@"I make the API call to delete a new user")]
        public async Task GivenIMakeTheAPICallToDeleteANewUser()
        {
            var httpClient = new HttpClient();

            httpResponse = await httpClient.DeleteAsync(ENDPOINT);
        }

        [Then(@"the DELETE call is successful")]
        public void ThenTheDELETECallIsSuccessful()
        {
            HttpStatusCode statusCode = httpResponse.StatusCode;
            int statusCodeValue = (int)statusCode;
            Assert.AreEqual(statusCodeValue, 204);
        }

        [Then(@"the user profile is deleted")]
        public async void ThenTheUserProfileIsDeleted()
        {
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            Assert.IsTrue(responseContent.Contains(""));
        }
    }
}
