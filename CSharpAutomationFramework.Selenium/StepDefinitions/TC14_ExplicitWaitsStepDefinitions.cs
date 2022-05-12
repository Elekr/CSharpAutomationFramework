using CSharpAutomationFramework.Pages;
using NUnit.Framework;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [TestFixture]
    [Binding]
    public class TC14_ExplicitWaitsStepDefinitions : RahulShettyLoginPage
    {
        public TC14_ExplicitWaitsStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {

        }

        [Given(@"\[I navigate to the TC14 page]")]
        public void GivenINavigateToTheTC14Page()
        {
            NavigateHome();
        }

        [When(@"\[I click the forgot password buttton]")]
        public void WhenIClickTheForgotPasswordButton()
        {
            ClickElement(btnForgotPassword);
        }

        [When(@"\[I don't wait]")]
        public void WhenIDontWait()
        {
            return;
        }


        [When(@"\[I wait until the element is enabled]")]
        public void WhenIWaitUntilTheElementIsEnabled()
        {
            WaitUntilElementEnabled(btnBackToLogin, 3);
        }

        bool successfulClick;
        [When(@"\[I try to click the back to login button]")]
        public void WhenITryToClickTheBackToLoginButton()
        {
            try
            {
                driver.FindElement(btnBackToLogin).Click();
                successfulClick = true;
            }
            catch (Exception ex)
            {
                successfulClick = false;
            }
        }

        [When(@"\[I try to click the back to login button with ClickElement]")]
        public void WhenITryToClickTheBackTologinButtonWithClickElement()
        {
            try
            {
                ClickElement(btnBackToLogin);
                successfulClick = true;
            }
            catch (Exception ex)
            {
                successfulClick = false;
            }
        }

        [Then(@"\[I should get an error]")]
        public void ThenIShouldGetAnError()
        {
            Assert.IsFalse(successfulClick);
        }

        [Then(@"\[I should not get an error]")]
        public void ThenIShouldNotGetAnError()
        {
            Assert.IsTrue(successfulClick);
        }
    }
}
