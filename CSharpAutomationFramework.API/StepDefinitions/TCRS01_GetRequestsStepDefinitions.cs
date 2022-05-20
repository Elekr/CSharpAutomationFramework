using CSharpAutomationFramework.API.Config;
using CSharpAutomationFramework.API.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Data;
using TechTalk.SpecFlow;
using CSharpAutomationFramework.Extensions;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;

namespace CSharpAutomationFramework.API.StepDefinitions
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

            Console.WriteLine("Response from the service: ");
            Console.WriteLine(JsonConvert.SerializeObject(person));

            var specTable = ConnectionStrings.SQLServer.GetDataSQLServer(SQLQueries.GetQuery);
            var dataFromDb = specTable.Rows[0].CreateInstance<Data>();

            Console.WriteLine("Data fetched from the database: ");
            Console.WriteLine(JsonConvert.SerializeObject(dataFromDb));

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
            dataFromDb.id.Should().Be(person.data.id, "id doesn't match");
            dataFromDb.email.Should().Be(person.data.email, "email doesn't match");
            dataFromDb.first_name.Should().Be(person.data.first_name, "first_name doesn't match");
            dataFromDb.last_name.Should().Be(person.data.last_name, "last_name doesn't match");
            dataFromDb.avatar.Should().Be(person.data.avatar, "avatar doesn't match");


        }

    }
}
