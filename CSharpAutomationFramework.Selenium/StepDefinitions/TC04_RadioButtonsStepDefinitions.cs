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
    public class TC04_RadioButtonsStepDefinitions : AutomationPracticePage
    {
        
        public TC04_RadioButtonsStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {

        }

        [Given(@"\[I have navigated to the TC04 page]")]
        public void GivenIHaveNavigatedToTC04()
        {
            NavigateHome();
        }

        [Given(@"\[The webpage contains more than (.*) radio button]")]
        public void GivenTheWebpageContainsMoreThanxRadioButton(int x)
        {
            Assert.IsTrue(GetWebElementList(GenerateLocator("XPATH", "//input[@type='radio']")).Count > x);
        }

        [Given(@"\[Radio button (.*) is not selected]")]
        public void GivenRadioButtonxIsNotSelected(int x)
        {
            Assert.IsFalse(driver.FindElement(GetRadio(x)).Selected);
        }

        [When(@"\[I click radio button (.*)]")]
        public void WhenIClickRadioButtonx(int x)
        {
            ClickElement(GetRadio(x));
        }

        [Then(@"\[Radio button (.*) is now selected]")]
        public void ThenRadioButtonxIsNowSelected(int x)
        {
            Assert.IsTrue(driver.FindElement(GetRadio(x)).Selected);
        }


        [Then(@"\[Radio button (.*) is no longer selected]")]
        public void ThenRadioButtonxIsNoLongerSelected(int x)
        {
            Assert.IsFalse(driver.FindElement(GetRadio(x)).Selected);
        }
    }
}
