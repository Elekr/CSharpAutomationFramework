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

        public By GetRadio(int index)
        {
            return GenerateLocator("XPATH", "(//input[@type='radio'])["+(index+1).ToString()+"]");
        }

        public By GetCheckbox(int index)
        {
            return GenerateLocator("XPATH", "(//input[@type='checkbox'])[" + (index + 1).ToString() + "]");
        }
    }
}
