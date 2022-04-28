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
    public class TC11_WebTablesStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HerokuPage heroPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://the-internet.herokuapp.com/", "The Internet");

        public TC11_WebTablesStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            heroPage = new HerokuPage(_driverHelper.webDriver);
            _driverHelper.webDriver.Navigate().GoToUrl(homePage.websiteURL);

            //Check that the website is correct
            Assert.AreEqual(homePage.websiteURL, heroPage.ReturnURL(), "incorrect URL");
        }

        [When(@"\[I locate all the columns in the table]")]
        public void WhenILocateAllTheColumnsInTheTable()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to get the number of columns]")]
        public void ThenIAmAbleToGetTheNumberOfColumns()
        {
            throw new PendingStepException();
        }

        [When(@"\[I locate all the rows in the table]")]
        public void WhenILocateAllTheRowsInTheTable()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to get the number of rows]")]
        public void ThenIAmAbleToGetTheNumberOfRows()
        {
            throw new PendingStepException();
        }

        [When(@"\[I locate a specific row in the table]")]
        public void WhenILocateASpecificRowInTheTable()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to get all the data for that row]")]
        public void ThenIAmAbleToGetAllTheDataForThatRow()
        {
            throw new PendingStepException();
        }

    }
}
