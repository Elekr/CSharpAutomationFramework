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
            Assert.IsTrue(CanLocateElement(currencyDropdown), "We should be able to locate the curency static dropdown");
        }

        [Given(@"\[The webpage contains the from input]")]
        public void GivenTheWebpageContainsTheFromInput()
        {
            Assert.IsTrue(CanLocateElement(fromDropdown), "We should be able to locate the from input field");
        }


        [Given(@"\[The dropdown contains the option (.*)]")]
        public void GivenTheDropdownContains(string option)
        {
            var options = GetSelectOptions(currencyDropdown);
            Assert.IsTrue(options.Contains(option), "The dropdown should contain "+option);

        }


        [Given(@"\[The dropdown currently has (.*) selected]")]
        [Then(@"\[The dropdown now has (.*) selected]")]
        public void GivenTheDropdownHasxSelected(string expectedSelected )
        {
            Assert.AreEqual(expectedSelected, GetSelectSelected(currencyDropdown), expectedSelected+" should be selected" );
        }

        [Given(@"\[We have maximized the window]")]
        public void GivenWeHaveMaximizedTheWindow()
        {
            MaximizeWindow(); // This dropdown functions differently if the page is not maximized
        }

        [When(@"\[I select option (.*)]")]
        public void WhenISelect(string value)
        {
            SelectByValue(currencyDropdown, value);
        }

        [When(@"\[I click onto the fromDropdown]")]
        public void WhenIClickOntoTheFromDropdown()
        {
            ClickElement(fromDropdown);
        }

        [When(@"\[I enter the query string (.*)]")]
        public void WhenIEnterTheQueryString(string query)
        {
            EnterText(fromDropdown, query);
        }

        [When(@"\[I click the option (.*)]")]
        public void WhenIClick(string optionToClick)
        {
            var links = GetWebElementList(By.TagName("a"));
            foreach(var link in links)
            {
                if(link.Text.Contains(optionToClick))
                {
                    link.Click();
                }
            }
        }


        [Then(@"\[The input now contains (.*)]")]
        public void ThenTheInputNowContains(string contained)
        {
            Assert.AreEqual(contained, GetAttribute(fromDropdown, "value"));
        }

    }
}
