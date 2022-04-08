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
    public class TC06_DropdownMenusStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC06_DropdownMenusStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"\[The webpage contains a static dropdown]")]
        public void GivenTheWebpageContainsAStaticDropdown()
        {
            throw new PendingStepException();
        }

        [When(@"\[I select an element from the dropdown]")]
        public void WhenISelectAnElementFromTheDropdown()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The option is selected and displayed]")]
        public void ThenTheOptionIsSelectedAndDisplayed()
        {
            throw new PendingStepException();
        }

        [Given(@"\[There is an input for the query]")]
        public void GivenThereIsAnInputForTheQuery()
        {
            throw new PendingStepException();
        }

        [When(@"\[I enter the query string]")]
        public void WhenIEnterTheQueryString()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The list is updated with elements that match the query]")]
        public void ThenTheListIsUpdatedWithElementsThatMatchTheQuery()
        {
            throw new PendingStepException();
        }

        [When(@"\[I select an option]")]
        public void WhenISelectAnOption()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The option is displayed]")]
        public void ThenTheOptionIsDisplayed()
        {
            throw new PendingStepException();
        }


    }
}
