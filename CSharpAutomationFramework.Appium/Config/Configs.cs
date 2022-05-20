using Newtonsoft.Json;

namespace CSharpAutomationFramework.Appium.Config
{
    [JsonObject("BrowserStackConfig")]
    public class BrowserStackConfig
    {
        [JsonProperty("user")]
        public static string User { get; set; }

        [JsonProperty("key")]
        public static string Key { get; set; }

        [JsonProperty("server")]
        public static string Server { get; set; }

    }

    [JsonObject("BrowserStackAndroid")]
    public class BrowserStackAndroid
    {
        [JsonProperty("project")]
        public static string Project { get; set; }

        [JsonProperty("build")]
        public static string Build { get; set; }

        [JsonProperty("name")]
        public static string Name { get; set; }

        [JsonProperty("browserstack.debug")]
        public static string BrowserstackDebug { get; set; }

        [JsonProperty("app")]
        public static string App { get; set; }

    }

    //[JsonObject("AndroidDevices")]
    //public class AndroidDevices
    //{
    //    public static List<Device> Devices { get; set; }

    //}


    public class Devices
    {
        [JsonProperty("device")]
        public  string Device { get; set; }

        [JsonProperty("os_version")]
        public  string Os_Version { get; set; }

    }
}
