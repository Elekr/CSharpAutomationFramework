using CSharpAutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.StepDefinitions.Selenium
{
    [TestFixture]
    [Binding]
    public class TC16_ActionsStepDefinitions : AutomationPracticePage
    {
        public TC16_ActionsStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {

        }

        [Given(@"\[I have navigated to the TC16 page]")]
        public void GivenIHaveNavigatedToTheTC16Page()
        {
            NavigateHome();
        }

        [Given(@"\[The link with text Top is not visible]")]
        public void GivenTheLinkWithTheTextXIsNotVisible()
        {
            Assert.IsFalse(HoverTopLinkVisible());
        }

        [Given(@"\[The first checkbox is not checked]")]
        public void GivenTheFirstCheckboxNotChecked()
        {
            Assert.IsFalse(FirstCheckoxChecked());
        }

        [When(@"\[I hover over the mouse hover button]")]
        public void WhenIHoverOverTheMouseHoverButton()
        {
            HoverOverHoverMouseButton();
        }

        [When(@"\[I check the first checkbox hover over the mouse hover button]")]
        public void WhenIDoCompositeAction()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(GetElement(GetCheckbox(0))).Click().MoveToElement(GetElement(hoverButton)).Build().Perform();
        }

        [Then(@"\[The link with text Top is now visible]")]
        public void ThenTheLinkWithTextXIsNowVisible()
        {
            Assert.IsTrue(HoverTopLinkVisible());
        }

        [Then(@"\[The first checkbox is checked]")]
        public void ThenFirstCheckboxChecked()
        {
            Assert.IsTrue(FirstCheckoxChecked());
        }

        bool FirstCheckoxChecked()
        {
            return driver.FindElement(GetCheckbox(0)).Selected;
        }

    }
}
