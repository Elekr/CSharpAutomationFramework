using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAutomationFramework.reusable;

namespace CSharpAutomationFramework.SelfTesting.reusable
{
    public class WebReusableComponentsTests
    {
        public IWebDriver driver = new ChromeDriver(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Drivers\\");
        class WRC_Tester : WebReusableComponents
        {
            public WRC_Tester(IWebDriver driver) : base(driver, ("https://google.co.uk",""))
            {

            }
        }
        WRC_Tester tester;
        public void BeforeEach()
        {
            tester = new WRC_Tester(driver);
        }

        [Test]
        [TestCase("XPATH", "//input[@type='radio']", 3)]
        [TestCase("LINKTEXT", "REST API", 1)]
        public void CorrectLengths_GetWebElementList(string type, string value, int expectedLength)
        {
            BeforeEach();
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            By locator = WebReusableComponents.GenerateLocator(type, value);
            var list = tester.GetWebElementList(locator);
            Assert.AreEqual(expectedLength, list.Count);
        }

    }
}
