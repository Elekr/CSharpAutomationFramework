using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.RestSharp
{
    [Binding]
    public class TCRS01_GetRequestsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        RestResponse? content;
        dynamic jsonResponse;

        [Given(@"\[I send a request for a single object]")]
        public async void GivenISendARequestForASingleObject()
        {
            var client = new RestClient("https://reqres.in/api/users/2");
            var request = new RestRequest("", Method.Get);




            content = client.ExecuteAsync(request).Result;
        }

        [When(@"\[The request is successful]")]
        public void WhenTheRequestIsSuccessful()
        {
            Assert.AreEqual("OK", content.StatusCode.ToString());

        }

        [Then(@"\[I am able to validate the returned object]")]
        public void ThenIAmAbleToValidateTheReturnedObject()
        {
            log.Info(content.Content.ToString());
            Data m = JsonConvert.DeserializeObject<Data>(content.Content);
            log.Info("first name is: " + m.first_name);
        }

    }
}
