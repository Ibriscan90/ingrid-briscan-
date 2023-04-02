
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;

namespace APITesting.Steps
{
    [Binding]
    public class GetSingleUserStep
    {

        HttpClient httpClient;
        private static readonly string ENDPOINT = "https://reqres.in/api/users/2";
        private HttpResponseMessage httpResponse;

        [Given(@"I perform the API call to get a user")]
        public async Task GivenIPerformTheAPICallToGetAUser()
        {

            var httpClient = new HttpClient();

            httpResponse = await httpClient.GetAsync(ENDPOINT);
        }

        [Then(@"the API call is successful")]
        public void ThenTheAPICallIsSuccessful()
        {
            HttpStatusCode statusCode = httpResponse.StatusCode;
            int statusCodeValue = (int)statusCode;
            Assert.AreEqual(statusCodeValue, 200);
        }

        [Then(@"the user details are retrieved")]
        public async void ThenTheUserDetailsAreRetrieved()
        {
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            Assert.IsTrue(responseContent.Contains("janet.weaver@reqres.in"));

            var responseObj = JObject.Parse(responseContent);
            var idValue = (int)responseObj["data"]["id"];
            Assert.AreEqual(2, idValue);

        }
    }
}
