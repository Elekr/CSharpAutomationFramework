using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Pages
{
    public class ReusablesTestPage : WebReusableComponents
    {
        protected By btnForgotPassword;
        protected By btnBackToLogin = By.ClassName("go-to-login-btn");
        protected By txtUsername = By.Id("inputUsername");
        protected By btnVisitUs = By.Id("visitUsTwo");
        public ReusablesTestPage(IWebDriver driver) : base(driver, ("https://rahulshettyacademy.com/locatorspractice/", "Rahul Shetty Academy - Login page"))
        {
        }

        public void loadBtnForgotPassword()
        {
            btnForgotPassword = generateLocator("LINKTEXT", "Forgot your password?");
        }


    }
}
