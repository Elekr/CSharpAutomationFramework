using CSharpAutomationFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [Binding]
    public class TC12_ScrollingStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC12_ScrollingStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"\[I scroll the page down a specific amount]")]
        public void WhenIScrollThePageDownASpecificAmount()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The offset of the window has changed by the specific amount]")]
        public void ThenTheOffsetOfTheWindowHasChangedByTheSpecificAmount()
        {
            throw new PendingStepException();
        }

    }
}
