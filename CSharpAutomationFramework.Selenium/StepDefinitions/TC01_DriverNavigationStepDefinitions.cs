using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [TestFixture]
    [Binding]
    public class TC01_DriverNavigationStepDefinitions : GooglePage
    {
        public TC01_DriverNavigationStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {

        }

        [Given(@"\[I have a browser driver]")]
        public void GivenIHaveABrowserDriver()
        {
            Assert.IsNotNull(driver);
            Log(AventStack.ExtentReports.Status.Pass, "We have a browser driver");
        }

        [Given(@"\[This page object has the url (.*)]")]
        public void GivenThisPageObjectHasTheURL(string url)
        {
            Assert.AreEqual(url, homePage.websiteURL);
        }

        [Given(@"\[The page object has the title (.*)]")]
        public void GivenThePageObjecteHasTheTitle(string title)
        {
            Assert.AreEqual(title, homePage.websiteTitle);
        }

        [When(@"\[I use the NavigateHome method]")]
        public void WhenIUseTheNavigateHomeMethod()
        {
            NavigateHome();
        }

        [Then(@"\[The webpage open in the driver will have the same title as the page object]")]
        public void ThenWebPageTitleEqualGooglePageTitle()
        {
            Assert.AreEqual(homePage.websiteTitle, driver.Title);
        }

    }
}
