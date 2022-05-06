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
    public class TC02_ClickNavigationStepDefinitions : HerokuPage
    {
        public TC02_ClickNavigationStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {

        }

        [Given(@"\[I have navigated to the TC02 page]")]
        public void GivenIHaveNavigatedToTC02()
        {
            NavigateHome();
            Assert.AreEqual(homePage.websiteURL, driver.Url);
        }

        [When(@"\[I click link]")]
        public void WhenIClickLink()
        {
            ClickElement(link);
        }

        [Then(@"\[The driver Url should have changed]")]
        public void ThenTheDriverUrlShouldHaveChanged()
        {
            Assert.AreNotEqual(driver.Url, homePage.websiteURL);
        }
    }
}
