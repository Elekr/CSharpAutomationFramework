using CSharpAutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [TestFixture]
    [Binding]
    public class TC07_AlertWindowsStepDefinitions : AutomationPracticePage
    {
        public TC07_AlertWindowsStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I have navigated to the TC07 page]")]
        public void GivenIHaveNavigateToTheTC07Page()
        {
            NavigateHome();
        }

        [Given(@"\[I have clicked on a link that opens an alert window]")]
        public void GivenIHaveClickedOnALinkThatOpensAnAlertWindow()
        {
            ClickElement(btnAlert);
        }

        [Given(@"\[I have clicked on a link that opens a confirm window]")]
        public void GivenIHaveClickedOnALinkThatOpensAConfirmWindow()
        {
            ClickElement(btnConfirm);
        }

        [When(@"\[I select OK on the alert window]")]
        public void WhenISelectOkOnTheAlertWindow()
        {
            DismissAlert();
        }

        [When(@"\[I select yes on the confirm window]")]
        public void WhenISelectYesOnTheConfirmWindow()
        {
            AcceptAlert();
        }

        [When(@"\[I select no on the confirm window]")]
        public void WhenISelectNoOnTheConfirmWindow()
        {
            DismissAlert();
        }

        [Then(@"\[The window is closed]")]
        public void ThenTheWindowIsClosed()
        {
            Assert.Throws<NoAlertPresentException>(delegate { driver.SwitchTo().Alert(); });
        }
    }
}
