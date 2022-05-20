using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Selenium.Pages
{
    public class LinksPage : WebReusableComponents
    {
        public LinksPage(IWebDriver driver) : base(driver, ("https://www.helpfullinks.org/helpfullinks/index.cfm/", "Helpful Links: : ")) { }


    }
}
