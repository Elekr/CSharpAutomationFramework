using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Appium.Config
{
    public class ConfigReader
    {
		public static AppiumOptions options;
		public static Uri uri;
		public static void SetFrameworkSettings(string device)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            var section = config.GetSection(nameof(BrowserStackConfig));
            section.Get<BrowserStackConfig>();

            var capability = config.GetSection(nameof(BrowserStackAndroid)).GetChildren().ToDictionary(x => x.Key, x => x.Value);
			var devices = config.GetSection("AndroidDevices").Get<List<Devices>>().ToDictionary(x => x.Device, x => x.Os_Version);

			options = new AppiumOptions();

			foreach (KeyValuePair<string, string> kvp in capability)
			{
				options.AddAdditionalCapability(kvp.Key, kvp.Value);
			}

            foreach (KeyValuePair<string, string> kvp in devices)
            {
				if (kvp.Key == device)
				{
					options.AddAdditionalCapability("device", kvp.Key);
					options.AddAdditionalCapability("os_version", kvp.Value);
				}
            }

            String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
			if (username == null)
			{
				username = BrowserStackConfig.User;
			}

			String accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
			if (accesskey == null)
			{
				accesskey = BrowserStackConfig.Key;
			}

			options.AddAdditionalCapability("browserstack.user", username);
			options.AddAdditionalCapability("browserstack.key", accesskey);

			String appId = Environment.GetEnvironmentVariable("BROWSERSTACK_APP_ID");
			if (appId != null)
			{
				options.AddAdditionalCapability("app", appId);
			}

			uri = new Uri("http://" + BrowserStackConfig.Server + "/wd/hub/");


		}
    }
}
