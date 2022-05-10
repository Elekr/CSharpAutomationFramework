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
    }
}

 

 