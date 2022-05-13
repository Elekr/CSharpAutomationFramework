using CSharpAutomationFramework.Pages;
using CSharpAutomationFramework.Selenium;
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
    public class TC15_ImplicitWaitStepDefinitions : RahulShettyLoginPage
    {
        public TC15_ImplicitWaitStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I navigate to the TC15 page]")]
        public void GivenINavigateToTheTC15Page()
        {
            NavigateHome();
        }

        [Given(@"\[I have set an implicit wait]")]
        public void GivenIHaveSetAnimplicitWait()
        {
            SetImplicitWait(10);
            Log(AventStack.ExtentReports.Status.Debug, driver.Manage().Timeouts().ImplicitWait.ToString());
            
        }

        [When(@"\[I click the submit button]")]
        public void WhenIClickTheSubmitButton()
        {
            ClickElement(btnSubmit);
        }


        bool successfullyGotMessage;
        [When(@"\[I try to get the incorrect credentials message]")]
        public void WhenITryToGetTheIncorrectCredsMessage()
        {
            try
            {
                driver.FindElement(msgIncorrectCreds);
                successfullyGotMessage = true;
            }
            catch (Exception ex)
            {
                successfullyGotMessage = false;
            }
        }

        [Then(@"\[I should get a locating error]")]
        public void ThenIShouldGetALocatingError()
        {
            Assert.IsFalse(successfullyGotMessage);
        }

        [Then(@"\[I should not get a locating error]")]
        public void ThenIShouldNotGetALocatingError()
        {
            Assert.IsTrue(successfullyGotMessage);
        }
    }
}
