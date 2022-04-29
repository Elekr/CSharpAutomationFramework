using CSharpAutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.StepDefinitions
{
    [TestFixture]
    [Binding]
    public class ReusablesTestStepDefinitions : ReusablesTestPage
    {
        
        public ReusablesTestStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {

        }

        [Given(@"\[We have moved to the the site]")]
        public void GivenWeHaveMovedToTheTheSite()
        {
            navigateHome();
            loadBtnForgotPassword();
        }

        [When(@"\[We click the forgot password buttton]")]
        public void WhenWeClickTheForgotPasswordButton()
        {
            driver.FindElement(btnForgotPassword).Click();
        }

        [When(@"\[Don't wait]")]
        public void DontWait()
        {
            return;
        }

        [When(@"\[Wait for element enabled]")]
        public void WaitForElementEnabled()
        {
            waitUntilElementEnabled(btnBackToLogin, 2L);
        }

        [Then(@"\[Clicking the go back button should fail]")]
        public void ThenClickingGoBackNoWaitShouldFail()
        {
            Assert.Throws<ElementClickInterceptedException>(delegate { driver.FindElement(btnBackToLogin).Click(); });
        }

        [Then(@"\[Clicking the go back button should succeed]")]
        public void ThenClickingGoBackNoWaitShouldNotFail()
        {
            driver.FindElement(btnBackToLogin).Click();

        }

        [Then(@"\[Clicking with clickElement should succeed]")]
        public void ThenClickingWithClickElementShouldSucceed()
        {
            clickElement(btnBackToLogin);
        }
    }
}
