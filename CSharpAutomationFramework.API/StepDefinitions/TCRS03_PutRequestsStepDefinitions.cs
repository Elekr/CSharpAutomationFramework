using CSharpAutomationFramework.API.Configs;
using CSharpAutomationFramework.API.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.API.StepDefinitions
{
    [Binding]
    public class TCRS03_PutRequestsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        RestResponse? response;

        private readonly ScenarioContext _scenarioContext;

        public TCRS03_PutRequestsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"\[I send a put request for employee with name ""([^""]*)"" to update the designation as ""([^""]*)""]")]
        public void GivenISendAPutRequestForEmployeeWithNameToUpdateTheDesignationAs(string employee_name, string designation)
        {
            var options = new RestClientOptions
            {
                BaseUrl = new Uri(URLs.BaseURL)
            };
            var client = new RestClient(options);

            var employee = new EmployeeRequest();
            employee.name = employee_name;
            employee.designation = designation;

            var request = new RestRequest(URLs.PutRequest);
            request.Method = Method.Put;
            request.AddJsonBody<EmployeeRequest>(employee);

            response = client.ExecuteAsync(request).Result;
        }

        [When(@"\[The put request is successful]")]
        public void WhenThePutRequestIsSuccessful()
        {
            Assert.AreEqual("OK", response.StatusCode.ToString());
        }

        [Then(@"\[I am able to validate the entry has been updated]")]
        public void ThenIAmAbleToValidateTheEntryHasBeenUpdated()
        {
            EmployeeResponse employee = JsonConvert.DeserializeObject<EmployeeResponse>(response.Content);

            (string name, string designation) testEmployee = ("Employee1",
                                          "Team Lead");

            Assert.AreEqual(employee.name, employee.name, "name doesn't match");
            Assert.AreEqual(testEmployee.designation, employee.designation, "desigation doesn't match");
        }


    }
}
