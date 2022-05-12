﻿using CSharpAutomationFramework.reusable;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Selenium.Pages
{
    public class PracticePage : WebReusableComponents
    {
        protected By textInput = By.XPath("//input[@type=\"text\"]");

        public PracticePage(IWebDriver driver) : base(driver, ("https://rahulshettyacademy.com/loginpagePractise/", "LoginPage Practise | Rahul Shetty Academy"))
        {

        }


    }
}
