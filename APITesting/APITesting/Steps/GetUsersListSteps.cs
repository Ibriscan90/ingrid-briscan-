using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
using System.Text;

namespace APITesting.Steps
{
    [Binding]
    public class GetUsersListSteps
    {
        private static readonly string ENDPOINT = "https://reqres.in/api/users/";
        private HttpResponseMessage httpResponse;
        private string apiUrl;

        [Given(@"I want to retrieve a list of users from the system by passing query parameters in my URL")]
        public void GivenIWantToRetrieveAListOfUsersFromTheSystemByPassingQueryParametersInMyURL()
        {
            StringBuilder urlBuilder = new StringBuilder(ENDPOINT);
            urlBuilder.Append("?page=1&per_page=1");
            apiUrl = urlBuilder.ToString();
        }

        [When(@"I perform a GET request")]
        public async Task WhenIPerformAGETRequest()
        {
            var httpClient = new HttpClient();

            httpResponse = await httpClient.GetAsync(apiUrl);
        }

        [Then(@"the GET API call is successfully performed")]
        public void ThenTheGETAPICallIsSuccessfullyPerformed()
        {
            HttpStatusCode statusCode = httpResponse.StatusCode;
            int statusCodeValue = (int)statusCode;
            Assert.AreEqual(statusCodeValue, 200);
        }

        [Then(@"the user details are retrieved correctly based on the query parameters")]
        public async Task ThenTheUserDetailsAreRetrievedCorrectlyBasedOnTheQueryParameters()
        {
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            JObject responseJson = JObject.Parse(responseContent);
            Assert.AreEqual(1, (int)responseJson["page"]);
            Assert.AreEqual(1, (int)responseJson["per_page"]);

          
        }
    }
}
