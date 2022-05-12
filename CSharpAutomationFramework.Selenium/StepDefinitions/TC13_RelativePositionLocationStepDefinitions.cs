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
    public class TC13_RelativePositionLocationStepDefinitions : AutomationPracticePage
    {
        public TC13_RelativePositionLocationStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {

        }

        [Given(@"\[I have navigated to the TC13 page]")]
        public void GivenIHaveNavigatedToTheTc13Page()
        {
            NavigateHome();
        }

        IWebElement table;

        [When(@"\[I choose the left table to search]")]
        public void WhenIChoosesTheLeftTableToSearch()
        {
            table = GetElement(leftTable);
        }

        [When(@"\[I choose the right table to search]")]
        public void WhenIChooseTheRightTableToSearch()
        {
            table = GetElement(rightTable);
        }

        string heading;

        [When(@"\[I get the first column heading]")]
        public void WhenIGetTheFirstColumnHeading()
        {
            heading = table.FindElement(By.TagName("th")).Text;
        }

        [Then(@"\[The heading is (.*)]")]
        public void ThenTheHeadingIs(string expectedHeading)
        {
            Assert.AreEqual(expectedHeading, heading);
        }
    }
}
