using NUnit.Framework;
using OpenQA.Selenium.Appium.iOS;
using System.Collections.Specialized;
using System.Configuration;
using OpenQA.Selenium.Appium;
using System;
using CSharpAutomationFramework.Appium.Config;

namespace CSharpAutomationFramework.Appium.NUnit.IOS
{
	public class BrowserStackNUnitTest
	{
		protected IOSDriver<IOSElement> driver;
		protected string profile;
		protected string device;

		public BrowserStackNUnitTest(string device)
		{
			this.profile = profile;
			this.device = device;
		}

		[SetUp]
		public void Init()
		{
			ConfigReader.SetFrameworkSettings("IOS",device);

			driver = new IOSDriver<IOSElement>(ConfigReader.uri, ConfigReader.options);
		}

		[TearDown]
		public void Cleanup()
		{
			driver.Quit();
		}
	}
}
