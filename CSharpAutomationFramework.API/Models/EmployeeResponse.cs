using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.API.Models
{
    internal class EmployeeResponse
    {
        public string name { get; set; }
        public string designation { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
    }
}
