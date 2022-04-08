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

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC02_ClickNavigationStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the ""([^""]*)""]")]
        public void GivenIHaveNavigatedToThe(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"\[I click on a link]")]
        public void WhenIClickOnALink()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am navigated to another ""([^""]*)""]")]
        public void ThenIAmNavigatedToAnother(string p0)
        {
            throw new PendingStepException();
        }


    }
}
