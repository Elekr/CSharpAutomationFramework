<<<<<<< HEAD:CSharpAutomationFramework.API/StepDefinitions/TCRS04_DeleteRequestsStepDefinitions.cs
﻿using CSharpAutomationFramework.API.Config;
using NUnit.Framework;
=======
<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
=======
﻿using NUnit.Framework;
>>>>>>> main:CSharpAutomationFramework/StepDefinitions/RestSharp/TCRS04_DeleteRequestsStepDefinitions.cs
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
>>>>>>> 47a45f96457b0d5dabf076352fca51e8fc29a41c
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.API.StepDefinitions
{
    [Binding]
    public class TCRS04_DeleteRequestsStepDefinitions
    {
<<<<<<< HEAD
        [Given(@"\[I send a request to delete an entry]")]
        public void GivenISendARequestToDeleteAnEntry()
        {
            throw new PendingStepException();
        }

        [When(@"\[The delete request is successful]")]
        public void WhenTheDeleteRequestIsSuccessful()
        {
            throw new PendingStepException();
=======
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
>>>>>>> 47a45f96457b0d5dabf076352fca51e8fc29a41c
        }

        [Then(@"\[I am able to validate entry has been deleted]")]
        public void ThenIAmAbleToValidateEntryHasBeenDeleted()
        {
<<<<<<< HEAD
            throw new PendingStepException();
=======
            var response = _scenarioContext.Get<RestResponse>("RestResponse");
            Assert.AreEqual(204, (int)response.StatusCode);
>>>>>>> 47a45f96457b0d5dabf076352fca51e8fc29a41c
        }


    }
}
