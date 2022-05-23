using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;


namespace CSharpAutomationFramework.Selenium
{
    [Binding]
    public class Hook
    {

        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;

        public Hook(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
        }


        [BeforeTestRun]
        public static void InitializeReport()
        {
            ReportSetup.InitializeReporter();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            ReportSetup.TearDownReport();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            ReportSetup.ClearLogsBeforeEachStep();
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            
            ReportSetup.InsertReportingSteps(_scenarioContext);

        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            ReportSetup.BeforeFeature(featurecontext);
        }


        [BeforeScenario]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("-headless");
            _driverHelper.webDriver = new ChromeDriver(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Drivers\\", options);


            ReportSetup.BeforeScenarioInitialize(_scenarioContext);
        }

        [AfterScenario]
        public void TearDown()
        {
            _driverHelper.webDriver.Close();
            _driverHelper.webDriver.Dispose();
        }
    }

    enum WebDriver
    {
        Chrome,
        Firefox,
        IE
    }
}
