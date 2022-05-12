using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.API.Configs
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            URLs.BaseURL = config.GetSection("URLs")["BaseURL"];
            URLs.GetRequest = config.GetSection("URLs")["GetRequest"];
            URLs.PostRequest = config.GetSection("URLs")["PostRequest"];
            URLs.PutRequest = config.GetSection("URLs")["PutRequest"];
            URLs.DeleteRequest = config.GetSection("URLs")["DeleteRequest"];
            ConnectionStrings.SQLServer = config.GetSection("ConnectionStrings")["SQLServer"];
            SQLQueries.GetQuery = config.GetSection("SQLQueries")["GetQuery"];  
        }
    }
}
