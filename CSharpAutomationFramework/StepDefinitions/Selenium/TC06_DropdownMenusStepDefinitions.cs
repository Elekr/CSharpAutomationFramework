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
    public class TC06_DropdownMenusStepDefinitions : QAClickJetPage
    {
        public TC06_DropdownMenusStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver)
        {
            
        }

        [Given(@"\[I have navigated to the TC06 page]")]
        public void GivenIHaveNavigatedToTC06()
        {
            NavigateHome();
        }

        [Given(@"\[The webpage contains the currency static dropdown]")]
        public void GivenTheWebpageContainsTheCurrencyStaticDropdown()
        {
            Assert.IsTrue(CanLocateElement(currencyDropdown));
        }


        [Given(@"\[The dropdown contains the option (.*)]")]
        public void GivenTheDropdownContains(string s)
        {
            var options = GetSelectOptions(currencyDropdown);
            Assert.IsTrue(options.Contains(s), "The dropdown should contain "+s);

        }


        [Given(@"\[The dropdown currently has (.*) selected]")]
        public void GivenTheDropdownHasxSelected(string x)
        {
            Assert.IsTrue(GetSelectSelected(currencyDropdown).Equals(x));
        }

        [When(@"\[I select (.*)]")]
        public void WhenISelect(string value)
        {
            SelectByValue(currencyDropdown, value);
        }

        [Then(@"\[The dropdown now has (.*) selected]")]
        public void ThenTheDropdownHasxSelected(string x)
        {
            Assert.IsTrue(GetSelectSelected(currencyDropdown).Equals(x));
        }
    }
}
