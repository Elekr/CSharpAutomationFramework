using CSharpAutomationFramework.API.Configs;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.API.StepDefinitions
{
    [Binding]
    public class TCRS04_DeleteRequestsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);       

        private readonly ScenarioContext _scenarioContext;

        public TCRS04_DeleteRequestsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"\[I create a request to delete an entry]")]
        public void GivenISendARequestToDeleteAnEntry()
        {
            var options = new RestClientOptions
            {
                BaseUrl = new Uri(URLs.BaseURL)
            };
            var client = new RestClient(options);

            var request = new RestRequest(URLs.DeleteRequest);
            request.Method = Method.Delete;

            _scenarioContext.Add("RestClient", client);
            _scenarioContext.Add("RestRequest", request);
        }

        [When(@"\[The delete request is sent]")]
        public void WhenTheDeleteRequestIsSuccessful()
        {
            var client = _scenarioContext.Get<RestClient>("RestClient");
            var request = _scenarioContext.Get<RestRequest>("RestRequest");
            
            var response = client.ExecuteAsync(request).Result;
            _scenarioContext.Add("RestResponse", response);
        }

        [Then(@"\[I am able to validate entry has been deleted]")]
        public void ThenIAmAbleToValidateEntryHasBeenDeleted()
        {
            var response = _scenarioContext.Get<RestResponse>("RestResponse");
            Assert.AreEqual(204, (int)response.StatusCode);
        }


    }
}
