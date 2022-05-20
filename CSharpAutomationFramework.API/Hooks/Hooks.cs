using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using CSharpAutomationFramework.API.Config;
using NUnit.Framework;
using System.Reflection;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace CSharpAutomationFramework.API.Hooks
{
    [Binding]
    class Hook
    {
        private readonly ScenarioContext _scenarioContext;
        
        public Hook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }        

        [BeforeTestRun]
        public static void TestInitialize()
        {
            ReportSetup.InitializeReporter();

            ConfigReader.SetFrameworkSettings();
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
            ReportSetup.BeforeScenarioInitialize(_scenarioContext);
        }

        [AfterScenario]
        public void TearDown()
        {
        }
    }

}
