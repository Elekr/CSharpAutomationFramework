using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAutomationFramework.Pages;
using NUnit.Framework;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [TestFixture]
    [Binding]
    public class TC01_DriverNavigationStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC01_DriverNavigationStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have a browser driver]")]
        public void GivenIHaveABrowserDriver()
        {
            hubPage = new HUBPage(_driverHelper.webDriver);
        }

        [When(@"\[I use the Navigate method]")]
        public void WhenIUseTheNavigateMethod()
        {
            _driverHelper.webDriver.Navigate().GoToUrl(homePage.websiteURL);
        }

        [Then(@"\[The correct page will be displayed]")]
        public void ThenTheCorrectPageWillBeDisplayed()
        {
            Assert.AreEqual(homePage.websiteTitle, hubPage.ReturnTitle(), "URLs do not match");
            log.Info("Test passed correctly");
        }
    }
}
