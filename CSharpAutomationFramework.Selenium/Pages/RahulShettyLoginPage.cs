﻿using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Pages
{
    public class RahulShettyLoginPage : WebReusableComponents
    {
        protected By btnForgotPassword = By.LinkText("Forgot your password?");
        protected By btnBackToLogin = By.ClassName("go-to-login-btn");
        protected By txtUsername = By.Id("inputUsername");
        protected By btnVisitUs = By.Id("visitUsTwo");
        protected By btnSubmit = By.CssSelector("button.submit");
        protected By msgIncorrectCreds = By.CssSelector("p.error");
        public RahulShettyLoginPage(IWebDriver driver) : base(driver, ("https://rahulshettyacademy.com/locatorspractice/", "Rahul Shetty Academy - Login page"))
        {
        }
    }
}
