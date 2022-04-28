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
    public class TC14_ExplicitWaitsStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        HerokuPage heroPage;

        private DriverHelper _driverHelper;

        (string websiteURL, string websiteTitle) homePage = ("https://the-internet.herokuapp.com/", "The Internet");

        public TC14_ExplicitWaitsStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }

        [Given(@"\[I have created an explicit wait]")]
        public void GivenIHaveCreatedAnExplicitWait()
        {
            heroPage = new HerokuPage(_driverHelper.webDriver);
            _driverHelper.webDriver.Navigate().GoToUrl(homePage.websiteURL);

            //Check that the website is correct
            Assert.AreEqual(homePage.websiteURL, heroPage.ReturnURL(), "incorrect URL");
        }

        [When(@"\[I navigate to the webpage which is still loading]")]
        public void WhenINavigateToTheWebpageWhichIsStillLoading()
        {
            throw new PendingStepException();
        }


        [Then(@"\[The explicit wait will stop execution until the condition is met]")]
        public void ThenTheExplicitWaitWillStopExecutionUntilTheConditionIsMet()
        {
            throw new PendingStepException();
        }

    }
}
