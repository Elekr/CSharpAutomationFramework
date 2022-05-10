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
    public class TC12_ScrollingStepDefinitions : HerokuPage
    {

        public TC12_ScrollingStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I have navigated to the TC12 page]")]
        public void GiveIHaveNavigatedToTheTC12Page()
        {
            NavigateHome();
        }

        [Given(@"\[The current y offset of the window is (.*)]")]
        public void GivenTheCurrentYOffset(int startingScroll)
        {
            AssertScrollIs(startingScroll);
        }

        [When(@"\[I scroll the page down by (.*)]")]
        public void WhenIScrollThePageDownBy(int deltaY)
        {
            ExecuteScript(String.Format("window.scrollBy(0,{0})", deltaY));
        }

        [Then(@"\[The y offset of the window is now (.*)]")]
        public void ThentheOffsetOfTheWindowIsNow(int expectedScroll)
        {
            AssertScrollIs(expectedScroll);
        }

        private void AssertScrollIs(int expectedScroll)
        {
            long value = (long)ExecuteScript("return window.pageYOffset;");
            Assert.AreEqual(expectedScroll, value);
        }
    }
}
