using CSharpAutomationFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [Binding]
    public class TC05_CheckboxesStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC05_CheckboxesStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"\[The webpage contains checkboxes]")]
        public void GivenTheWebpageContainsCheckboxes()
        {
            throw new PendingStepException();
        }

        [When(@"\[I select a checkbox]")]
        public void WhenISelectACheckbox()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The checkbox is checked]")]
        public void ThenTheCheckboxIsChecked()
        {
            throw new PendingStepException();
        }

    }
}
