using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.RestSharp.API
{
    internal class EmployeeResponse
    {
        public string name { get; set; }
        public string designation { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
    }
}
