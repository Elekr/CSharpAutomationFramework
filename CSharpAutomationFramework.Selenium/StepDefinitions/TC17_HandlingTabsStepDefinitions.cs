using CSharpAutomationFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.Selenium.StepDefinitions
{
    [Binding]
    public class TC17_HandlingTabsStepDefinitions : PracticePage
    {
        public TC17_HandlingTabsStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I have navigated to the TC17 page]")]
        public void GivenIHaveNavigatedToTheTCPage()
        {
            NavigateHome();
        }

        [Given(@"\[The username textbox is empty]")]
        public void GivenTheUsernameTextboxIsEmpty()
        {
            Assert.AreEqual("", GetAttribute(textInput, "value"));
        }

        [When(@"\[I open a new tab]")]
        public void WhenIOpenANewTab()
        {
            OpenNewTab();
        }

        RahulShettyLoginPage loginPage;

        [When(@"\[I navigate the new tab to the Rahul Shetty Academy login page]")]
        public void WhenINavigateTheNewTabToTheRahulShettyAcademyLoginPage()
        {
            loginPage = new RahulShettyLoginPage(driver);
            loginPage.NavigateHome();
        }

        string tagline;
        [When(@"\[I grab the tagline]")]
        public void WhenIGrabTheTagline()
        {
            tagline = loginPage.GetTagline();
        }

        [When(@"\[I navigate to tab (.*)]")]
        public void WhenINavigateBackToTab(int p0)
        {
            SwitchToWindowIndex(p0);
        }

        [When(@"\[I enter the tagline into the textbox]")]
        public void WhenIEnterTheTaglineIntoTheTextbox()
        {
            EnterText(textInput, tagline);
        }

        [Then(@"\[The username textbox should contain the text (.*)]")]
        public void ThenTheTextboxShouldContainTheText(string expectedText)
        {
            Assert.AreEqual(expectedText, GetAttribute(textInput, "value"));
        }
    }
}
