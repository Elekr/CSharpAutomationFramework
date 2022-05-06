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

            var dataFromDb = new Data();

            using (var connection = new SqlConnection(ConnectionStrings.SQLServer))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = SQLQueries.GetQuery;
                var table = new DataTable();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataFromDb.id = (int) reader["Id"];
                        dataFromDb.email = reader["Email"].ToString();
                        dataFromDb.first_name = reader["First_Name"].ToString();
                        dataFromDb.last_name = reader["Last_Name"].ToString();
                        dataFromDb.avatar = reader["Avatar"].ToString();
                    }

                    connection.Close();
                }
            }
            Assert.AreEqual(dataFromDb.id, person.data.id, "id doesn't match");
            Assert.AreEqual(dataFromDb.email, person.data.email, "email doesn't match");
            Assert.AreEqual(dataFromDb.first_name, person.data.first_name, "first_name doesn't match");
            Assert.AreEqual(dataFromDb.last_name, person.data.last_name, "last_name doesn't match");
            Assert.AreEqual(dataFromDb.avatar, person.data.avatar, "avatar doesn't match");
        }

    }
}
