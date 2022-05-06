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

        protected By radioButtons = GenerateLocator("XPATH", "//input[@type='radio']");

        public By GetRadio(int index)
        {
            return GenerateLocator("XPATH", "(//input[@type='radio'])["+(index+1).ToString()+"]");
        }
    }
}
