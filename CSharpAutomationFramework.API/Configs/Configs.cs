using Newtonsoft.Json;

namespace CSharpAutomationFramework.API.Configs
{
    [JsonObject("URLs")]
    public class URLs
    {
        [JsonProperty("BaseURL")]
        public static string BaseURL { get; set; }

        [JsonProperty("GetRequest")]
        public static string GetRequest { get; set; }

        [JsonProperty("PostRequest")]
        public static string PostRequest { get; set; }

        [JsonProperty("PutRequest")]
        public static string PutRequest { get; set; }

        [JsonProperty("DeleteRequest")]
        public static string DeleteRequest { get; set; }
    }

    [JsonObject("ConnectionStrings")]
    public class ConnectionStrings
    {
        [JsonProperty("SQLServer")]
        public static string SQLServer { get; set; }

    }

    [JsonObject("SQLQueries")]
    public class SQLQueries
    {
        [JsonProperty("GetQuery")]
        public static string GetQuery { get; set; }

    }
}
