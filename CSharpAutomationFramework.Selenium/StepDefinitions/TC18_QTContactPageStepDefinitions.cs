using CSharpAutomationFramework.Selenium.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.Selenium.StepDefinitions
{
    [Binding]
    public class TC18_QTContactPageStepDefinitions : QTPage
    {

        public TC18_QTContactPageStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I am on the Qualitest site homepage]")]
        [When(@"\[I load the Qualitest site homepage]")]
        public void GivenTheUserLoadsQualitestOfficialSite()
        {
            NavigateHome();
        }

        [Given(@"\[I maximize the page]")]
        public void GivenIMaxThePage()
        {
            MaximizeWindow();
        }


        [When(@"\[I click the Contact us button]")]
        public void WhenIClickTheContactUsButton()
        {
            ClickElement(btnContactUs);
        }


        [Then(@"\[The current page title is (.*)]")]
        public void ThenTitleIs(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Then(@"\[The current url is (.*)]")]
        public void ThenUrlIs(string expectedUrl)
        {
            Assert.AreEqual(expectedUrl, driver.Url);
        }

        [Then(@"\[The page contains the contact form]")]
        public void ThenThePagContainsContactForm()
        {
            Assert.IsTrue(IsElementVisible(frmContact));
        }
    }
}
