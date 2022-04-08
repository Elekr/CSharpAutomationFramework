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
    public class TC03_TextInputStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HUBPage hubPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://www.google.com/", "Google");

        public TC03_TextInputStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"\[The webpage contains a text input]")]
        public void GivenTheWebpageContainsATextInput()
        {
            throw new PendingStepException();
        }

        [When(@"\[I send text to the field]")]
        public void WhenISendTextToTheField()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The text is successfully entered into the field]")]
        public void ThenTheTextIsSuccessfullyEnteredIntoTheField()
        {
            throw new PendingStepException();
        }

        [When(@"\[I send more text to the field]")]
        public void WhenISendMoreTextToTheField()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The extra text is added to the field]")]
        public void ThenTheExtraTextIsAddedToTheField()
        {
            throw new PendingStepException();
        }

    }
}
