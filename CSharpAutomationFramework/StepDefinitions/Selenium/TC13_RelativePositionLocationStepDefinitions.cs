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
    public class TC13_RelativePositionLocationStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HerokuPage heroPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://the-internet.herokuapp.com/", "The Internet");

        public TC13_RelativePositionLocationStepDefinitions(DriverHelper driverHelper)
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

        [When(@"\[I locate an element on the page]")]
        public void WhenILocateAnElementOnThePage()
        {
            throw new PendingStepException();
        }

        [When(@"\[I select another element based on its relative position]")]
        public void WhenISelectAnotherElementBasedOnItsRelativePosition()
        {
            throw new PendingStepException();
        }

        [Then(@"\[I am able to interact with that element]")]
        public void ThenIAmAbleToInteractWithThatElement()
        {
            throw new PendingStepException();
        }

    }
}
