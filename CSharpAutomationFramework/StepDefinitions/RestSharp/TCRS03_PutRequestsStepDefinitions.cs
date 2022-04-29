<<<<<<< HEAD
﻿using System;
=======
﻿using CSharpAutomationFramework.StepDefinitions.RestSharp.API;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
>>>>>>> 47a45f96457b0d5dabf076352fca51e8fc29a41c
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.RestSharp
{
    [Binding]
    public class TCRS03_PutRequestsStepDefinitions
    {
<<<<<<< HEAD
        [Given(@"\[I send a put request]")]
        public void GivenISendAPutRequest()
        {
            throw new PendingStepException();
=======
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
            var client = new RestClient("https://reqres.in/api/users/2");
            var request = new RestRequest("", Method.Put);
            var employee = new EmployeeRequest();
            employee.name = employee_name;
            employee.designation = designation;
            request.AddJsonBody<EmployeeRequest>(employee);
            response = client.ExecuteAsync(request).Result;
>>>>>>> 47a45f96457b0d5dabf076352fca51e8fc29a41c
        }

        [When(@"\[The put request is successful]")]
        public void WhenThePutRequestIsSuccessful()
        {
<<<<<<< HEAD
            throw new PendingStepException();
=======
            Assert.AreEqual("OK", response.StatusCode.ToString());
>>>>>>> 47a45f96457b0d5dabf076352fca51e8fc29a41c
        }

        [Then(@"\[I am able to validate the entry has been updated]")]
        public void ThenIAmAbleToValidateTheEntryHasBeenUpdated()
        {
<<<<<<< HEAD
            throw new PendingStepException();
=======
            EmployeeResponse employee = JsonConvert.DeserializeObject<EmployeeResponse>(response.Content);

            (string name, string designation) testEmployee = ("Employee1",
                                          "Team Lead");

            Assert.AreEqual(employee.name, employee.name, "name doesn't match");
            Assert.AreEqual(testEmployee.designation, employee.designation, "desigation doesn't match");
>>>>>>> 47a45f96457b0d5dabf076352fca51e8fc29a41c
        }


    }
}
