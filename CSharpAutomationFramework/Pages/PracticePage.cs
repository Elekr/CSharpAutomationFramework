using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Pages
{
    internal class PracticePage
    {
        private readonly IWebDriver driver;
        private IWebElement textField => driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/form/div[3]/input"));

        public PracticePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string ReturnURL()
        {
            return driver.Url;
        }

        public string ReturnTitle()
        {
            return driver.Title;
        }

        public int ReturnFieldSize()
        {
            return textField.GetAttribute("value").Length;
        }

        public string ReturnText()
        {
            return textField.GetAttribute("value");
        }

        public void SendKeys(string keysToSend)
        {
            textField.SendKeys(keysToSend);
        }

        public void ClearField()
        {
            textField.Clear();
        }
    }
}
