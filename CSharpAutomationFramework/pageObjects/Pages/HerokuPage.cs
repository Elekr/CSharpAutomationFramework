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

        private By buttonsample1 = By.Id("/");
        private By buttonsample2 = By.CssSelector("/");
        private By buttonsample3 = By.Name("/");
        private By buttonsample4 = By.LinkText("/");




        public HerokuPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void ClickButton()



        {
            driver.FindElement(buttonsample1).Click();
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


        //public int ReturnFieldSize()
        //{
        //    return textField.GetAttribute("value").Length;
        //}

        //public string ReturnText()
        //{
        //    return textField.GetAttribute("value");
        //}

        //public void SendKeys(string keysToSend)
        //{
        //    textField.SendKeys(keysToSend);
        //}

        //public void ClearField()
        //{
        //    textField.Clear();
        //}
    }
}
