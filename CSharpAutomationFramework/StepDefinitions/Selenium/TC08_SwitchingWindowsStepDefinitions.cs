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
    public class TC08_SwitchingWindowsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC08_SwitchingWindowsStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"\[I click on a link to open a new window]")]
        public void WhenIClickOnALinkToOpenANewWindow()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to navigate to the new window]")]
        public void ThenIAmAbleToNavigateToTheNewWindow()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to access elements within the new window]")]
        public void ThenIAmAbleToAccessElementsWithinTheNewWindow()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to close the child window]")]
        public void ThenIAmAbleToCloseTheChildWindow()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to navigate back to the original window]")]
        public void ThenIAmAbleToNavigateBackToTheOriginalWindow()
        {
            throw new PendingStepException();
        }

    }
}
