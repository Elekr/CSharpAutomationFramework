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

        PracticePage pracPage;

        private DriverHelper _driverHelper;

        string keysToSend = "Hello";

        string additionalKeys = "There";

        (string websiteURL, string websiteTitle) homePage = ("https://rahulshettyacademy.com/loginpagePractise/", "LoginPage Practise | Rahul Shetty Academy");

        public TC03_TextInputStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            pracPage = new PracticePage(_driverHelper.webDriver);

            _driverHelper.webDriver.Navigate().GoToUrl(homePage.websiteURL);
        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            string f = _driverHelper.webDriver.Url;
            Assert.AreEqual(homePage.websiteTitle, f);

            //Check that the website is correct
            Assert.AreEqual(homePage.websiteURL, pracPage.ReturnURL(), "incorrect URL");
        }

        [Given(@"\[The webpage contains a text input]")]
        public void GivenTheWebpageContainsATextInput()
        {

            //Check that the field exists and can take input
            Assert.True(pracPage.ReturnFieldSize() == 0);
        }

        [When(@"\[I send text to the field]")]
        public void WhenISendTextToTheField()
        {
            pracPage.SendKeys(keysToSend);
        }

        [Then(@"\[The text is successfully entered into the field]")]
        public void ThenTheTextIsSuccessfullyEnteredIntoTheField()
        {
            Assert.AreEqual(keysToSend, pracPage.ReturnText());
        }

        [When(@"\[I send more text to the field]")]
        public void WhenISendMoreTextToTheField()
        {
            pracPage.SendKeys(additionalKeys);
            pracPage.ClearField();
        }

        [Then(@"\[The extra text is added to the field]")]
        public void ThenTheExtraTextIsAddedToTheField()
        {
            Assert.AreEqual("", pracPage.ReturnText(), "Field not cleared");

            //Testing for screenshots of a failed test
            bool g = false;
            Assert.IsTrue(g);
        }

    }
}
