using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Appium.NUnit.Android
{
    [TestFixture("Google Pixel 3")]
    [TestFixture("Samsung Galaxy S10e")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SingleTest : BrowserStackNUnitTest
    {
        public SingleTest(string device) : base(device) { }
        [Test]
        public void searchWikipedia()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            AndroidElement searchElement = (AndroidElement)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia")));
            searchElement.Click();
            AndroidElement insertTextElement = (AndroidElement)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
            insertTextElement.SendKeys("BrowserStack");
            Thread.Sleep(5000);
            ReadOnlyCollection<AndroidElement> allProductsName = driver.FindElements(By.ClassName("android.widget.TextView"));
            Assert.True(allProductsName.Count > 0);
        }
    }
}
