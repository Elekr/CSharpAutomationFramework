using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Pages
{
    public class QAClickJetPage : WebReusableComponents
    {
        public QAClickJetPage(IWebDriver driver) : base(driver, ("https://rahulshettyacademy.com/dropdownsPractise/", "QAClickJet - Flight Booking for Domestic and International, Cheap Air Tickets"))
        {

        }

        protected By currencyDropdown = By.Id("ctl00_mainContent_DropDownListCurrency");
        protected By fromDropdown = By.Id("ctl00_mainContent_ddl_originStation1_CTXT");
        protected By calendarOpener = By.Id("ctl00_mainContent_view_date1");
        protected By displayedMonthSpan = By.XPath("//span[@class='ui-datepicker-month']");
        protected By btnNextMonth = By.XPath("//a[@title='Next']");
        protected By firstMonthDiv = By.XPath("//div[@class='ui-datepicker-group ui-datepicker-group-first']");
        protected By lastMonthDiv = By.XPath("//div[@class='ui-datepicker-group ui-datepicker-group-last']");

        public List<string> GetDisplayedMonths()
        {
            List<IWebElement> monthObjects = GetWebElementList(displayedMonthSpan);
            List<string> months = new List<string>();
            foreach(IWebElement monthObj in monthObjects)
            {
                months.Add(monthObj.Text);
            }
            return months;
        }
    }
}
