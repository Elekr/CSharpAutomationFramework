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


        HerokuPage heroPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://the-internet.herokuapp.com/", "The Internet");

        public TC01_DriverNavigationStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the ""([^""]*)""]")]
        public void GivenIHaveNavigatedToThe(string webpage)
        {
            heroPage = new HerokuPage(_driverHelper.webDriver);
            _driverHelper.webDriver.Navigate().GoToUrl(homePage.websiteURL);

            //Check that the website is correct
            Assert.AreEqual(homePage.websiteURL, heroPage.ReturnURL(), "incorrect URL");

        }

        [When(@"\[I use the Navigate method]")]
        public void WhenIUseTheNavigateMethod()
        {
            _driverHelper.webDriver.Navigate().GoToUrl(homePage.websiteURL);

            //Check that the website is correct
            Assert.AreEqual(homePage.websiteURL, heroPage.ReturnURL(), "incorrect URL");
        }

        [Then(@"\[The correct page will be displayed]")]
        public void ThenTheCorrectPageWillBeDisplayed()
        {
            Assert.AreEqual(homePage.websiteTitle, heroPage.ReturnTitle(), "URLs do not match");
            log.Info("Test passed correctly");
        }
    }
}
