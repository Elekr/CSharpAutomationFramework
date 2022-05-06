using CSharpAutomationFramework.Database.Config;
using NUnit.Framework;
using System.Reflection;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace CSharpAutomationFramework.Database.Hooks
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

            ConfigReader.SetFrameworkSettings();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
        }

        [BeforeStep]
        public void BeforeStep()
        {

        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            

        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {

        }


        [BeforeScenario]
        public void Initialize()
        {
           
        }

        [AfterScenario]
        public void TearDown()
        {
        }
    }

}
