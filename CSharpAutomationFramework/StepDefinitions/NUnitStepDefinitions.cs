using System;
using TechTalk.SpecFlow;
using CSharpAutomationFramework.Pages;

namespace CSharpAutomationFramework.StepDefinitions
{
    [Binding]
    public class NUnitStepDefinitions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly NFTPage nftPage;

        private DriverHelper _driverHelper;

        public NUnitStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            nftPage = new NFTPage(driverHelper.webDriver);
        }
        [Given(@"\[context]")]
        public void GivenContext()
        {
            _driverHelper.webDriver.Navigate().GoToUrl("https://www.google.com");
        }

        [When(@"\[action]")]
        public void WhenAction()
        {
            Console.WriteLine("hello");
        }

        [Then(@"\[outcome]")]
        public void ThenOutcome()
        {

        }
    }
}
