using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Selenium.Pages
{
    public class GooglePage : WebReusableComponents
    {
        public GooglePage(IWebDriver driver) : base(driver, ("https://google.co.uk/", "Google"))
        {
        }
    }
}
