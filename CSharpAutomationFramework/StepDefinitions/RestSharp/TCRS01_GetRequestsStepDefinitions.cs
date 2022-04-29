using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAutomationFramework.StepDefinitions.RestSharp.API;

namespace CSharpAutomationFramework.StepDefinitions.RestSharp
{
    [Binding]
    public class TCRS01_GetRequestsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        RestResponse? content;
        dynamic jsonResponse;

        [Given(@"\[I send a request for a single object]")]
        public void GivenISendARequestForASingleObject()
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
            Root person = JsonConvert.DeserializeObject<Root>(content.Content);

            (int id, string email, string first_name, string last_name,
             string avatar) testPerson = (2, "janet.weaver@reqres.in", 
                                          "Janet", "Weaver", 
                                          "https://reqres.in/img/faces/2-image.jpg");

            Assert.AreEqual(testPerson.id, person.data.id, "id doesn't match");
            Assert.AreEqual(testPerson.email, person.data.email, "email doesn't match");
            Assert.AreEqual(testPerson.first_name, person.data.first_name, "first_name doesn't match");
            Assert.AreEqual(testPerson.last_name, person.data.last_name, "last_name doesn't match");
            Assert.AreEqual(testPerson.avatar, person.data.avatar, "avatar doesn't match");

            log.Info(person.data.id);
        }

    }
}
