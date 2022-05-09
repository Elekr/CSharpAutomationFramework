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
    public class TC08_SwitchingWindowsStepDefinitions : HerokuPage
    {
        public TC08_SwitchingWindowsStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        { }

        [Given(@"\[I have navigated to the TC08 page]")]
        public void GivenIHaveNavigatedToTheTC08Page()
        {
            NavigateHome();
            ClickElement(multipleWindowsLink);
        }

        [Given(@"\[I have opened the new window with the new window link]")]
        public void GivenIHaveOpenedTheNewWindow()
        {
            ClickElement(newWindowLink);
        }

        [Given(@"\[I am still on the page with the new window link]")]
        public void GivenThisWindowContainsTheHeading()
        {
            Assert.IsTrue(CanLocateElement(newWindowLink));
        }

        [Given(@"\[I am on a child window]")]
        public void GivenIAmOnAChildWindow()
        {
            GivenIHaveNavigatedToTheTC08Page();
            GivenIHaveOpenedTheNewWindow();
            WhenINavigatetoTheLatestWindow();
            ThenThisWindowContainsHeading("New Window");
        }

        [When(@"\[I navigate to window (.*)]")]
        public void WhenINavigateToWindow(int index)
        {
            SwitchToWindowIndex(index);
        }

        [When(@"\[I navigate to the latest window]")]
        public void WhenINavigatetoTheLatestWindow()
        {
            SwitchToLatestWindow();
        }

        [Then(@"\[I am now on a window that does not contain the new window link]")]
        public void ThenWeAreNoLongerOnParentWindow() // Prove we are no longer on the parent window
        {
            Assert.IsFalse(CanLocateElement(newWindowLink));
        }


        [Then(@"\[I am now on a window that contains the heading (.*)]")]
        public void ThenThisWindowContainsHeading(string heading) // Prove we are on the correct window
        {
            Assert.IsTrue(CanLocateElement(By.XPath("//h3[text()='"+heading+"']")));
        }
    }
}
