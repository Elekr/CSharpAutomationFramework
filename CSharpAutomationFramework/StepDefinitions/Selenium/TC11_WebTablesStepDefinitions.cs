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
    public class TC11_WebTablesStepDefinitions : AutomationPracticePage
    {
        public TC11_WebTablesStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I have navigated to the TC11 page]")]
        public void GivenIHaveNavigatedToTheTC11Page()
        {
            NavigateHome();
        }

        int count;
        [When(@"\[I count the number of rows in the left table]")]
        public void WhenICountTheNumberOfRowsInTheLeftTable()
        {
            count = CountTableRows(leftTable);
        }

        [Then(@"\[I should get a count of (.*)]")]
        public void ThenIShouldGetACountOf(int expectedCount)
        {
            Assert.AreEqual(expectedCount, count);
        }
    }
}
