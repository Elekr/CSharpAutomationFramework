using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace CSharpAutomationFramework.Pages
{
    public class  QtContactPage : WebReusableComponents
    {
        public QtContactPage(IWebDriver driver) : base(driver, (" https://qualitestgroup.com/contact-us/", "Contact Us – Independent Software Testing Company | Quality Assurance Services | Qualitest"))
        {



        }
    }
}

