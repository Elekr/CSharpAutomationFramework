using CSharpAutomationFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [TestFixture]
    [Binding]
    public class TC02_ClickNavigationStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HerokuPage heroPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://the-internet.herokuapp.com/", "The Internet");

        public TC02_ClickNavigationStepDefinitions(DriverHelper driverHelper)
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

        [When(@"\[I click on a link]")]
        public void WhenIClickOnALink()
        {
            heroPage.ClickButton();
        }

        [Then(@"\[I am navigated to another ""([^""]*)""]")]
        public void ThenIAmNavigatedToAnother(string webpage)
        {

            Assert.IsTrue(!(heroPage.ReturnURL().Equals(homePage.websiteURL)));
        }


    }
}
