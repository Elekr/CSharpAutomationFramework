using CSharpAutomationFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [Binding]
    public class TC04_RadioButtonsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC04_RadioButtonsStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"\[The webpage contains radio buttons]")]
        public void GivenTheWebpageContainsRadioButtons()
        {
            throw new PendingStepException();
        }

        [When(@"\[I select a radio button]")]
        public void WhenISelectARadioButton()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The correct radio button is selected]")]
        public void ThenTheCorrectRadioButtonIsSelected()
        {
            throw new PendingStepException();
        }

        [When(@"\[I select a different radio button]")]
        public void WhenISelectADifferentRadioButton()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The radio button selection is changed]")]
        public void ThenTheRadioButtonSelectionIsChanged()
        {
            throw new PendingStepException();
        }

    }
}
