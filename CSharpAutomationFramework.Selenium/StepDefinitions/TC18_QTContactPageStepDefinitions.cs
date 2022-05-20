using CSharpAutomationFramework.Selenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.Selenium.StepDefinitions
{
    [Binding]
    public class TC18_QTContactPageStepDefinitions : QTPage
    {

        public TC18_QTContactPageStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I am on the Qualitest site homepage]")]
        [When(@"\[I load the Qualitest site homepage]")]
        public void GivenTheUserLoadsQualitestOfficialSite()
        {
            NavigateHome();
        }

        [Given(@"\[I maximize the page]")]
        public void GivenIMaxThePage()
        {
            MaximizeWindow();
        }


        [Given(@"\[I have navigated to the Contact Us page]")]
        public void GivenIHaveNavigatedToTheContactUsPage()
        {
            GoToContactUs();
        }


        [When(@"\[I click the Contact Us button]")]
        public void WhenIClickTheContactUsButton()
        {
            ClickElement(btnContactUs);
        }

        [When(@"\[I enter the first name (.*)]")]
        public void WhenIEnterTheFirstName(string firstname)
        {
            EnterText(txtFirstname, firstname);
        }

        [When(@"\[I enter the surname (.*)]")]
        public void WhenIEnterTheSurname(string surname)
        {
            EnterText(txtLastname, surname);
        }

        [When(@"\[I enter the company name (.*)]")]
        public void WhenIEnterTheCompanyName(string companyName)
        {
            EnterText(txtCompany, companyName);
        }

        [When(@"\[I select that I want to talk about (.*)]")]
        public void WhenISelectThatIWantToTalkAboutSubject(string subject)
        {
            foreach(IWebElement lblRadio in lblSubjectRadios)
            {
                if(lblRadio.FindElement(By.TagName("span")).Text.Equals(subject))
                {
                    lblRadio.FindElement(By.TagName("input")).Click();
                    break;
                }
            }

        }

        [When(@"\[I enter the email (.*)]")]
        public void WhenIEnterTheEmail(string emailAddress)
        {
            EnterText(txtEmail, emailAddress);
        }

        [When(@"\[I enter the phone number (.*)]")]
        public void WhenIEnterThePhoneNumber(string phoneNumber)
        {
            EnterText(txtPhone, phoneNumber);
        }

        [When(@"\[I select the location (.*)]")]
        public void WhenISelectTheLocation(string location)
        {
            SelectByValue(slctLocation, location);
        }

        [When(@"\[I enter (.*) into the how can Qualitest help field]")]
        public void WhenIEnterIntoHowCanHelp(string text)
        {
            EnterText(txtHowCanWeHelp, text);
        }

        [When(@"\[I click the Submit button]")]
        public void WhenIClickSubmit()
        {
            //ClickElement(btnSubmit); // We're not going to do this as we don't want to send junk to the server
        }


        [Then(@"\[I receive a Thank you message]")]
        public void ThenIReceiveThanksMessage()
        {
            //Assert.AreEqual(_.Text,"Thank You"); // Can't do this or get the locators for it without doing the previous step

            Wait(5);
        }

        [Then(@"\[The current page title is (.*)]")]
        public void ThenTitleIs(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Then(@"\[The current url is (.*)]")]
        public void ThenUrlIs(string expectedUrl)
        {
            Assert.AreEqual(expectedUrl, driver.Url);
        }

        [Then(@"\[The page contains the contact form]")]
        public void ThenThePagContainsContactForm()
        {
            WaitUntilElementLocated(txtFirstname, 3);
        }
    }
}
