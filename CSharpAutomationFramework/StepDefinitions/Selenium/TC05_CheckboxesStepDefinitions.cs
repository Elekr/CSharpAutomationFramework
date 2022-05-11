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
    public class TC05_CheckboxesStepDefinitions : AutomationPracticePage
    {
        public TC05_CheckboxesStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I have navigated to the TC05 page]")]
        public void GivenIHaveNavigatedToTC05()
        {
            NavigateHome();
        }

        private By checkbox;

        [Given(@"\[The webpage contains a checkbox]")]
        public void GivenTheWebpageContainsACheckbox()
        {
            checkbox = GetCheckbox(0);
            Assert.IsTrue(IsElementVisible(checkbox));
        }

        [Given(@"\[The checkbox is not checked]")]
        public void GivenTheCheckboxIsNotChecked()
        {
            Assert.IsFalse(driver.FindElement(checkbox).Selected);
        }

        [When(@"\[I click the checkbox]")]
        public void WhenIClickACheckbox()
        {
            ClickElement(checkbox);
        }


        [Then(@"\[The checkbox is checked]")]
        public void ThenTheCheckboxIsChecked()
        {
            Assert.IsTrue(IsCheckboxChecked());
        }

        [Then(@"\[The checkobox is unchecked]")]
        public void ThenTheCheckboxIsUnchecked()
        {
            Assert.IsFalse(IsCheckboxChecked());
        }

        private bool IsCheckboxChecked()
        {
            return driver.FindElement(checkbox).Selected;
        }
    }
}
