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
    public class TC07_AlertWindowsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HerokuPage heroPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://the-internet.herokuapp.com/", "The Internet");

        public TC07_AlertWindowsStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have navigated to the TC(.*)Page]")]
        public void GivenIHaveNavigatedToTheTCPage(int p0)
        {
            heroPage = new HerokuPage(_driverHelper.webDriver);
            _driverHelper.webDriver.Navigate().GoToUrl(homePage.websiteURL);

            //Check that the website is correct
            Assert.AreEqual(homePage.websiteURL, heroPage.ReturnURL(), "incorrect URL");
        }

        [Given(@"\[I have clicked on a link that opens an alert window]")]
        public void GivenIHaveClickedOnALinkThatOpensAnAlertWindow()
        {
            throw new PendingStepException();
        }

        [When(@"\[I select OK on the alert window]")]
        public void WhenISelectOKOnTheAlertWindow()
        {
            throw new PendingStepException();
        }

        [Then(@"\[The window is closed]")]
        public void ThenTheWindowIsClosed()
        {
            throw new PendingStepException();
        }

        [Given(@"\[I have clicked on a link that opens a confirm window]")]
        public void GivenIHaveClickedOnALinkThatOpensAConfirmWindow()
        {
            throw new PendingStepException();
        }

        [When(@"\[I select yes on the confirm window]")]
        public void WhenISelectYesOnTheConfirmWindow()
        {
            throw new PendingStepException();
        }

        [When(@"\[I select no on the confirm window]")]
        public void WhenISelectNoOnTheConfirmWindow()
        {
            throw new PendingStepException();
        }

    }
}