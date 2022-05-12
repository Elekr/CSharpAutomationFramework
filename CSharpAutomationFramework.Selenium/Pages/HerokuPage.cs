using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Selenium.Pages
{
    public class HerokuPage : WebReusableComponents
    {

        public By addRemoveLink = By.LinkText("Add/Remove Elements");
        public By multipleWindowsLink = By.LinkText("Multiple Windows");
        public By newWindowLink = By.LinkText("Click Here");
        public By framesLink = By.LinkText("Frames");
        public By nestedFramesLink = By.LinkText("Nested Frames");
        public By topFrame = By.Name("frame-top");
        public By middleFrame = By.Name("frame-middle");
        
        public HerokuPage(IWebDriver driver) : base(driver, ("https://the-internet.herokuapp.com/", "The Internet"))
        {

        }
        
    }
}
