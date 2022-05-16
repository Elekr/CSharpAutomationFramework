using CSharpAutomationFramework.Pages;
using CSharpAutomationFramework.Selenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CSharpAutomationFramework.Selenium.StepDefinitions
{
    [Binding]
    public class TC19_LinkTestingStepDefinitions : LinksPage
    {
        public TC19_LinkTestingStepDefinitions(DriverHelper driverHelper) : base(driverHelper.webDriver) { }

        [Given(@"\[We have navigated to the TC19A page]")]
        public void GivenWeHaveNavigatedToTheTC19Page()
        {
            NavigateHome();
        }

        [Given(@"\[We have navigated to the TC19B page]")]
        public void GivenWeHaveNavigatedToTheTC19BPage()
        {
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
        }

        bool working = true;
        List<IWebElement> links;
        [When(@"\[I get all the links]")]
        public void WhenIGettAllLinks()
        {
            links = GetWebElementList(By.TagName("a"));
            Console.WriteLine("test");
        }

        [When(@"\[I discard the disabled links]")]
        public void WhenIDiscardAllDisabledLinks()
        {
            foreach (IWebElement link in links)
            {
                if (!link.Enabled)
                {
                    links.Remove(link);
                }
            }
        }

        [When(@"\[I test the remaining links]")]
        public void WhenITestRemainingLinks()
        {
            foreach (IWebElement link in links)
            {
                string url = link.GetAttribute("href");
                if (!url.Contains("http")) url = homePage.websiteURL + url;
                working = working && IsSiteWorking(url);
            }
        }

        [Then(@"\[They should all be working]")]
        public void ThenAllLinksWorking()
        {
            Assert.IsTrue(working);
        }

        [Then(@"\[They should not all be working]")]
        public void ThenTheyShouldNoAllBeWorking()
        {
            Assert.IsFalse(working);
        }

    }
}
