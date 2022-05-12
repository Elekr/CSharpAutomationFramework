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
    public class TC14_ExplicitWaitsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        GooglePage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC14_ExplicitWaitsStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have created an explicit wait]")]
        public void GivenIHaveCreatedAnExplicitWait()
        {
            throw new PendingStepException();
        }

        [When(@"\[I navigate to the webpage which is still loading]")]
        public void WhenINavigateToTheWebpageWhichIsStillLoading()
        {
            throw new PendingStepException();
        }


        [Then(@"\[The explicit wait will stop execution until the condition is met]")]
        public void ThenTheExplicitWaitWillStopExecutionUntilTheConditionIsMet()
        {
            throw new PendingStepException();
        }

    }
}
