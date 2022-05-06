using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Pages
{
    public class AutomationPracticePage : WebReusableComponents
    {
        public AutomationPracticePage(IWebDriver driver) : base(driver, ("https://rahulshettyacademy.com/AutomationPractice/", "Practice Page"))
        { }

        protected By btnAlert = By.Id("alertbtn");
        protected By btnConfirm = By.Id("confirmbtn");

        public By GetRadio(int index)
        {
            return GenerateLocator("XPATH", "(//input[@type='radio'])["+(index+1).ToString()+"]");
        }

        public By GetCheckbox(int index)
        {
            return GenerateLocator("XPATH", "(//input[@type='checkbox'])[" + (index + 1).ToString() + "]");
        }

        public void DismissAlert()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }
    }
}
