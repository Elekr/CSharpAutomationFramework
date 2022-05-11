using CSharpAutomationFramework.Database.Config;
using CSharpAutomationFramework.Database.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using CSharpAutomationFramework.Extensions;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;

namespace CSharpAutomationFramework.Database.StepDefinitions
{
    [Binding]
    public class TCRS01_GetRequestsStepDefinitions
    {
        
        RestResponse? content;
        dynamic jsonResponse;

        private readonly ScenarioContext _scenarioContext;

        public TCRS01_GetRequestsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"\[I send a request for a single object]")]
        public void GivenISendARequestForASingleObject()
        {
            var options = new RestClientOptions
            {
                BaseUrl = new Uri(URLs.BaseURL)
            };            
            var client = new RestClient(options);

            var request = new RestRequest(URLs.GetRequest);
            request.Method = Method.Get;
           
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

            var specTable = ConnectionStrings.SQLServer.GetData(SQLQueries.GetQuery);
            var dataFromDb = specTable.Rows[0].CreateInstance<Data>();

            //NUnit Assertions
            Assert.AreEqual(dataFromDb.id, person.data.id, "id doesn't match");
            Assert.AreEqual(dataFromDb.email, person.data.email, "email doesn't match");
            Assert.AreEqual(dataFromDb.first_name, person.data.first_name, "first_name doesn't match");
            Assert.AreEqual(dataFromDb.last_name, person.data.last_name, "last_name doesn't match");
            Assert.AreEqual(dataFromDb.avatar, person.data.avatar, "avatar doesn't match");

            //FluentAssertions
            person.Should().NotBeNull();
            specTable.Should().NotBeNull();
            specTable.RowCount.Should().Be(1, "becasue there should be only one record");
            dataFromDb.id.Should().Be(person.data.id, "");
            dataFromDb.email.Should().Be(person.data.email, "");
            dataFromDb.first_name.Should().Be(person.data.first_name, "");
            dataFromDb.last_name.Should().Be(person.data.last_name, "");
            dataFromDb.avatar.Should().Be(person.data.avatar, "");


        }

    }
}
