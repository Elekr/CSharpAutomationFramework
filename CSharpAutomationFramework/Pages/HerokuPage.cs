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

        public By addRemoveLink = By.LinkText("Add/Remove Elements");
        public By multipleWindowsLink = By.LinkText("Multiple Windows");
        public By newWindowLink = By.LinkText("Click Here");
        
        public HerokuPage(IWebDriver driver) : base(driver, ("https://the-internet.herokuapp.com/", "The Internet"))
        {

        }
        
    }
}
