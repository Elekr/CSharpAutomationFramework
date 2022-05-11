﻿using CSharpAutomationFramework.Pages;
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
    public class TC17_HandlingTabsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HerokuPage heroPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://the-internet.herokuapp.com/", "The Internet");

        public TC17_HandlingTabsStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to a form]")]
        public void GivenIHaveNavigatedToAForm()
        {
            heroPage = new HerokuPage(_driverHelper.webDriver);
            _driverHelper.webDriver.Navigate().GoToUrl(homePage.websiteURL);

            //Check that the website is correct
            Assert.AreEqual(homePage.websiteURL, heroPage.ReturnURL(), "incorrect URL");
        }

        [Given(@"\[I have opened two extra tabs]")]
        public void GivenIHaveOpenedTwoExtraTabs()
        {
            throw new PendingStepException();
        }

        [Given(@"\[I have navigated to two separate pages on the other tabs]")]
        public void GivenIHaveNavigatedToTwoSeparatePagesOnTheOtherTabs()
        {
            throw new PendingStepException();
        }

        [When(@"\[I grab the text from the second tab]")]
        public void WhenIGrabTheTextFromTheSecondTab()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to insert it into the first name input in the first tab]")]
        public void ThenIAmAbleToInsertItIntoTheFirstNameInputInTheFirstTab()
        {
            throw new PendingStepException();
        }

        [When(@"\[I grab the text from the third tab]")]
        public void WhenIGrabTheTextFromTheThirdTab()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to insert it into the last name input in the first tab]")]
        public void ThenIAmAbleToInsertItIntoTheLastNameInputInTheFirstTab()
        {
            throw new PendingStepException();
        }

    }
}
