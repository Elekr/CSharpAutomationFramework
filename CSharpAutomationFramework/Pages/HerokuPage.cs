using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Pages
{
    public class HerokuPage : WebReusableComponents
    {

        public By link = By.LinkText("Add/Remove Elements");
        
        public HerokuPage(IWebDriver driver) : base(driver, ("https://the-internet.herokuapp.com/", "The Internet"))
        {

        }
        
    }
}
