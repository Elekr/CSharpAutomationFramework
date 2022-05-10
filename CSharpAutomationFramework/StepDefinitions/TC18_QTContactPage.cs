using CSharpAutomationFramework.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.StepDefinitions
{
    [Binding]
    public class TC18_QTContactPage : QtContactPage
    {
        public TC18_QTContactPage(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {
            NavigateHome();
        }

        [Given(@"the user loads Qualitest official site")]
        public void GivenTheUserLoadsQualitestOfficialSite()
        {
            throw new PendingStepException();
        }

        [Then(@"the user is able to access the Qualitest site")]
        public void ThenTheUserIsAbleToAccessTheQualitestSite()
        {
            throw new PendingStepException();
        }

        [Then(@"the title of the page is The World’s Leading AI-Led Quality Engineering Company \| Qualitest")]
        public void ThenTheTitleOfThePageIsTheWorldSLeadingAI_LedQualityEngineeringCompanyQualitest()
        {
            throw new PendingStepException();
        }

        [Given(@"the user is on Qualitest site")]
        public void GivenTheUserIsOnQualitestSite()
        {
            throw new PendingStepException();
        }

        [When(@"the user clicks on Contact us button")]
        public void WhenTheUserClicksOnContactUsButton()
        {
            throw new PendingStepException();
        }

        [Then(@"the user is able to access the Qualitest Contact us web page")]
        public void ThenTheUserIsAbleToAccessTheQualitestContactUsWebPage()
        {
            throw new PendingStepException();
        }

        [Then(@"the page contains a form for the user")]
        public void ThenThePageContainsAFormForTheUser()
        {
            throw new PendingStepException();
        }

        [Given(@"the user is on contact us page")]
        public void GivenTheUserIsOnContactUsPage()
        {
            throw new PendingStepException();
        }

        [When(@"the user enters first name")]
        public void WhenTheUserEntersFirstName()
        {
            throw new PendingStepException();
        }

        [When(@"the user enters last name")]
        public void WhenTheUserEntersLastName()
        {
            throw new PendingStepException();
        }

        [When(@"the user enters company name")]
        public void WhenTheUserEntersCompanyName()
        {
            throw new PendingStepException();
        }

        [When(@"the user selects what he wants to talk about")]
        public void WhenTheUserSelectsWhatHeWantsToTalkAbout()
        {
            throw new PendingStepException();
        }

        [When(@"the user enters email")]
        public void WhenTheUserEntersEmail()
        {
            throw new PendingStepException();
        }

        [When(@"the user enters phone number")]
        public void WhenTheUserEntersPhoneNumber()
        {
            throw new PendingStepException();
        }

        [When(@"the user enters location")]
        public void WhenTheUserEntersLocation()
        {
            throw new PendingStepException();
        }

        [When(@"the user fills how can we help section")]
        public void WhenTheUserFillsHowCanWeHelpSection()
        {
            throw new PendingStepException();
        }

        [When(@"the user clicks on Submit button")]
        public void WhenTheUserClicksOnSubmitButton()
        {
            throw new PendingStepException();
        }

        [Then(@"the user receives a Thank you message")]
        public void ThenTheUserReceivesAThankYouMessage()
        {
            throw new PendingStepException();
        }
    }
}
