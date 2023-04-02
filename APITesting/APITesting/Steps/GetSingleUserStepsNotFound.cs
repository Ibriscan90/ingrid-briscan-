
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APITesting.Steps
{
    [Binding]
    public class GetSingleUserStepsNotFound
    { 
        HttpClient httpClient;
        private static readonly string ENDPOINT = "https://reqres.in/api/users/200";
        private HttpResponseMessage httpResponse;

    [Given(@"I perform the API call to retrieve a user")]
        public async Task GivenIPerformTheAPICallToRetrieveAUser()
        {

            var httpClient = new HttpClient();

            httpResponse = await httpClient.GetAsync(ENDPOINT);
        }

        [Then(@"the API call is unsuccessful")]
        public void ThenTheAPICallIsUnsuccessful()
        {
            HttpStatusCode statusCode = httpResponse.StatusCode;
            int statusCodeValue = (int)statusCode;
            Assert.AreEqual(statusCodeValue, 404);
        }

        [Then(@"the user details are not found")]
        public async void ThenTheUserDetailsAreNotFound()
        {
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            Assert.IsTrue(responseContent.Equals("{}"));
        }
    }
}
