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
    public class TC10_UsingCalendarStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC10_UsingCalendarStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"\[I click to open the calendar]")]
        public void WhenIClickToOpenTheCalendar()
        {
            throw new PendingStepException();
        }

        [When(@"\[I enter the day required]")]
        public void WhenIEnterTheDayRequired()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The specific day is selected]")]
        public void ThenTheSpecificDayIsSelected()
        {
            throw new PendingStepException();
        }

    }
}
