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
    public class TC16_ActionsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC16_ActionsStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"\[I build and perform the action]")]
        public void WhenIBuildAndPerformTheAction()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The effect is seen on the web page]")]
        public void ThenTheEffectIsSeenOnTheWebPage()
        {
            throw new PendingStepException();
        }

        [When(@"\[I build and perform the composite action]")]
        public void WhenIBuildAndPerformTheCompositeAction()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The full action is performed]")]
        public void ThenTheFullActionIsPerformed()
        {
            throw new PendingStepException();
        }

    }
}
