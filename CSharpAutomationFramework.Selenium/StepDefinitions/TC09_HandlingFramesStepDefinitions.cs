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
    public class TC09_HandlingFramesStepDefinitions : HerokuPage
    {
        public TC09_HandlingFramesStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I have navigated to the TC09 page]")]
        public void GivenIHaveNavigatedTC09()
        {
            NavigateHome();
            ClickElement(framesLink);
            ClickElement(nestedFramesLink);
        }

        [Given(@"\[I am unable to access the text displayed in middle]")]
        public void GivenIAmUnableToAccessTheTextInMiddle()
        {
            Assert.IsFalse(CanLocateMiddleText());
        }

        [When(@"\[I switch focus to the middle frame]")]
        public void WhenISwitchFocusToTheMiddleFrame()
        {
            SwitchToframe(topFrame);
            SwitchToframe(middleFrame);
        }

        [Then(@"\[I am able to access the text displayed in middle]")]
        public void ThenIAmAbleToAccessTheTextDisplayedInMiddle()
        {
            Assert.IsTrue(CanLocateMiddleText());
        }

        private bool CanLocateMiddleText()
        {
            return CanLocateElement(By.XPath("//*[text()='MIDDLE']"));
        }
    }
}
