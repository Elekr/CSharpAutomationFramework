using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAutomationFramework.StepDefinitions.RestSharp.API;
using NUnit.Framework;

namespace CSharpAutomationFramework.StepDefinitions.RestSharp
{
    [Binding]
    public class TCRS02_PostRequestsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        RestResponse? response;

        private readonly ScenarioContext _scenarioContext;

        public TCRS02_PostRequestsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"\[I create a post request with (.*) and (.*)]")]
        public void GivenICreateAPostRequestWithAnd(string employee_name,string designation)
        {
            var client = new RestClient("https://reqres.in/api/users");
            var request = new RestRequest("", Method.Post);
            var employee = new EmployeeRequest();
            employee.name = employee_name;
            employee.designation = designation;
            request.AddJsonBody<EmployeeRequest>(employee);
            response = client.ExecuteAsync(request).Result;
        }

        [When(@"\[The post request is successful]")]
        public void WhenThePostRequestIsSuccessful()
        {
            Assert.AreEqual("Created", response.StatusCode.ToString());
        }

        [Then(@"\[I am able to validate the entry has been added]")]
        public void ThenIAmAbleToValidateTheEntryHasBeenAdded()
        {
            EmployeeResponse employee = JsonConvert.DeserializeObject<EmployeeResponse>(response.Content);

            (string name, string designation) testEmployee = ("Employee1",
                                          "SoftwareEngineer");

            Assert.AreEqual(employee.name, employee.name, "name doesn't match");
            Assert.AreEqual(testEmployee.designation, employee.designation, "desigation doesn't match");
        }

    }
}
