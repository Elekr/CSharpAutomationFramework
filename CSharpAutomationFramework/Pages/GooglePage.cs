using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Pages
{
    internal class GooglePage
    {
        private readonly IWebDriver driver;
        private IWebElement googleBar => driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
        private IWebElement cookiesButton => driver.FindElement(By.Id("L2AGLb"));
        public GooglePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterSearchTerm(string searchTerm)
        {
            googleBar.SendKeys(searchTerm);
        }

        public void AcceptCookies()
        {
            cookiesButton.Click();
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
