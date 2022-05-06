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

        [Given(@"\[The webpage contains the from input]")]
        public void GivenTheWebpageContainsTheFromInput()
        {
            Assert.IsTrue(CanLocateElement(fromDropdown));
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

        [Given(@"\[We have maximized the window]")]
        public void GivenWeHaveMaximizedTheWindow()
        {
            MaximizeWindow(); // This dropdown functions differently if the page is not maximized
        }

        [When(@"\[I select (.*)]")]
        public void WhenISelect(string value)
        {
            SelectByValue(currencyDropdown, value);
        }

        [When(@"\[I click onto the fromDropdown]")]
        public void WhenIClickOntoTheFromDropdown()
        {
            driver.FindElement(fromDropdown).Click();
        }

        [When(@"\[I enter the query string (.*)]")]
        public void WhenIEnterTheQueryString(string query)
        {
            EnterText(fromDropdown, query);
        }

        [When(@"\[I click the option (.*)]")]
        public void WhenIClick(string optionToClick)
        {
            var links = GetWebElementList(By.XPath("//a"));
            foreach(var link in links)
            {
                if(link.Text.Contains(optionToClick))
                {
                    link.Click();
                }
            }
        }

        [Then(@"\[The dropdown now has (.*) selected]")]
        public void ThenTheDropdownHasxSelected(string x)
        {
            Assert.IsTrue(GetSelectSelected(currencyDropdown).Equals(x));
        }

        [Then(@"\[The input now contains (.*)]")]
        public void ThenTheInputNowContains(string contained)
        {
            Assert.AreEqual(contained, GetAttribute(fromDropdown, "value"));
        }
    }
}
