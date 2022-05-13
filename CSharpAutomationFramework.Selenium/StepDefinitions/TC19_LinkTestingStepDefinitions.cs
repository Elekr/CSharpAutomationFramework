using CSharpAutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.Selenium.StepDefinitions
{
    [Binding]
    public class TC19_LinkTestingStepDefinitions : HerokuPage
    {
        public TC19_LinkTestingStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[We have navigated to the TC19 page]")]
        public void GivenWeHaveNavigatedToTheTC19Page()
        {
            NavigateHome();
        }


        bool working = true;
        [When(@"\[I test all links]")]
        public void WhenITestAllLinks()
        {
            List<IWebElement> links = GetWebElementList(By.TagName("a"));
            foreach(IWebElement link in links)
            {
                string url = link.GetAttribute("href");
                working = working && IsSiteWorking(url);
            }
        }

        [Then(@"\[They should all be working]")]
        public void ThenAllLinksWorking()
        {
            Assert.IsTrue(working);
        }
    }
}
