using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Appium.NUnit.IOS
{
    [TestFixture("first", "pixel-3")]
    public class SingleTest : BrowserStackNUnitTest
    {
        public SingleTest(string profile, string device) : base(profile, device) { }
        [Test]
        public void searchWikipedia()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IOSElement searchElement = (IOSElement)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia")));
            searchElement.Click();
            IOSElement insertTextElement = (IOSElement)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
            insertTextElement.SendKeys("BrowserStack");
            Thread.Sleep(5000);
            ReadOnlyCollection<IOSElement> allProductsName = driver.FindElements(By.ClassName("android.widget.TextView"));
            Assert.True(allProductsName.Count > 0);
        }
    }
}
