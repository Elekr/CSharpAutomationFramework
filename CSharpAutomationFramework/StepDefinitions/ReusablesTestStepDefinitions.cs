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

        [Given(@"\[We are on the forgot password page]")]
        public void GivenWeAreOnTheForgottenPasswordPage()
        {
            clickElement(btnForgotPassword);
        }

        [When(@"\[We click back to login]")]
        public void WhenWeClickBackToLogin()
        {
            clickElement(btnBackToLogin);
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

        [When(@"\[We click visit us]")]
        public void WhenWeClickVisitUs()
        {
            clickElement(btnVisitUs);
        }

        [When(@"\[We wait (.*) second\(s\)]")]
        public void WhenWeWaitXSeconds(int x)
        {
            wait(x);
        }

        [When(@"\[We switch to the new tab]")]
        public void WhenWeSwitchToNewTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }

        [Then(@"\[We should successfully verify the redirect to (.*)]")]
        public void ThenWeShouldSucceedVerifyRedirect(string expectedURL)
        {
            verifyRedirect(expectedURL);
        }

        [Then(@"\[We should fail to verify redirect to (.*)")]
        public void ThenFailToVerifyRedirect(string url)
        {
            Assert.Throws<Exception>(delegate { verifyRedirect(url); });
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

        [Then(@"\[Trying to immediately send keys to the username box should fail]")]
        public void ThenSuccessfullySendText()
        {
            driver.FindElement(txtUsername).SendKeys("test string");
        }

        [Then(@"\[Trying to immediately enterText should succeed]")]
        public void ThenTryingToImmediatelyEnterTextShouldNotFail()
        {
            enterText(txtUsername, "test string");
        }

        [Then(@"\[Username element should contain the test string]")]
        public void ThenUsernameElementShouldContainTestString()
        {
            Assert.AreEqual("test string", driver.FindElement(txtUsername).GetAttribute("value"));
        }

    }
}
