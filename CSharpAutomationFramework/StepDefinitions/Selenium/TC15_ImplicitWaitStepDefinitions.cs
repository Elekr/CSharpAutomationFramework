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
    public class TC15_ImplicitWaitStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        GooglePage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC15_ImplicitWaitStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have supplied the correct setup to add an implicit wait]")]
        public void GivenIHaveSuppliedTheCorrectSetupToAddAnImplicitWait()
        {
            throw new PendingStepException();
        }

        [When(@"\[I navigate to the ""([^""]*)""]")]
        public void WhenINavigateToThe(string p0)
        {
            throw new PendingStepException();
        }


        [Then(@"\[The driver will implicitly wait before the test fails]")]
        public void ThenTheDriverWillImplicitlyWaitBeforeTheTestFails()
        {
            throw new PendingStepException();
        }

    }
}
