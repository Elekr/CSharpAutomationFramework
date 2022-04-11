using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Pages
{
    internal class HerokuPage
    {
        private readonly IWebDriver driver;

        private IWebElement button => driver.FindElement(By.XPath("//a[text()='Add/Remove Elements']"));
        public HerokuPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void ClickButton()
        {
            button.Click();
        }

        public string ReturnURL()
        {
            return driver.Url;
        }

        public string ReturnTitle()
        {
            return driver.Title;
        }
    }
}
