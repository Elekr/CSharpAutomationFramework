using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Specialized;
using System.Configuration;
using OpenQA.Selenium.Appium;
using System;
using CSharpAutomationFramework.Appium.Config;

namespace CSharpAutomationFramework.Appium.NUnit.Android
{
	public class BrowserStackNUnitTest
	{
		protected AndroidDriver<AndroidElement> driver;
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
			ConfigReader.SetFrameworkSettings(device);

			driver = new AndroidDriver<AndroidElement>(ConfigReader.uri, ConfigReader.options);
		}

		[TearDown]
		public void Cleanup()
		{
			driver.Quit();
		}
	}
}
