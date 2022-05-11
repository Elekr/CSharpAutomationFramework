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
    public class TC10_UsingCalendarStepDefinitions : QAClickJetPage
    {
        public TC10_UsingCalendarStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[I have navigated to the TC10 page]")]
        public void GivenIHaveNavigatedToTheTC10Page()
        {
            NavigateHome();
        }

        [Given(@"\[I have maximized the page]")]
        public void GivenIHaveMaximizedThePage()
        {
            MaximizeWindow();
        }

        [When(@"\[I click to open the calendar]")]
        public void WhenIClickToOpenTheCalendar()
        {
            ClickElement(calendarOpener);
        }

        [When(@"\[I enter the date (.*)]")]
        public void WhenIEnterTheDate(string date)
        {
            string day = date.Split(" ")[0], month = date.Split(" ")[1];
            List<string> months = new List<string>();
            do
            {
                months = GetDisplayedMonths();
                if (!month.Contains(day)) ClickElement(btnNextMonth);
            } while (!months.Contains(month));
            By monthDiv;
            if (months[0] == month) monthDiv = firstMonthDiv;
            else monthDiv = lastMonthDiv;
            WaitUntilElementLocated(monthDiv, 3);
            IWebElement monthToChooseFrom = driver.FindElement(monthDiv);
            Wait(2);
            monthToChooseFrom.FindElement(By.LinkText(day)).Click();
        }

        [Then(@"\[(.*) is selected]")]
        public void ThenxIsSelected(string x)
        {
            Assert.AreEqual(x, GetAttribute(calendarOpener, "value"));
        }
    }
}
