using CSharpAutomationFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [Binding]
    public class TC09_HandlingFramesStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC09_HandlingFramesStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"\[I switch focus to the middle frame]")]
        public void WhenISwitchFocusToTheMiddleFrame()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to access the text displayed in middle]")]
        public void ThenIAmAbleToAccessTheTextDisplayedInMiddle()
        {
            throw new PendingStepException();
        }

        [When(@"\[I switch focus to the bottom frame]")]
        public void WhenISwitchFocusToTheBottomFrame()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to access the text displayed in bottom]")]
        public void ThenIAmAbleToAccessTheTextDisplayedInBottom()
        {
            throw new PendingStepException();
        }

    }
}
