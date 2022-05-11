using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace CSharpAutomationFramework
{
    [Binding]
    class Hook
    {

        private static ExtentTest? featureName;
        private static ExtentTest? scenario;
        
        private static ExtentReports? extent;

        private static List<(Status status, string text)> logs = new List<(Status status, string text)>();

        private DriverHelper _driverHelper;

        private readonly ScenarioContext _scenarioContext;

        public Hook(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
        }

        public static void Log(Status status, string text)
        {
            logs.Add((status, text));
        }


        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Reports\\" + "ExtentReports.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.DocumentTitle = "C# Automation Framework Report";

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            logs.Clear();
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString(); 

            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(_scenarioContext, null);
            ExtentTest? step = null;
            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    step = scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    step = scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    step = scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    step = scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            if (_scenarioContext.TestError != null)
            {
                // https://www.extentreports.com/docs/versions/4/net/index.html
                // MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build()); used to take the screenshots when the tests fail
                if (stepType == "Given")
                    step = scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("C:\\Users\\thomas.crosby\\Documents\\Projects\\C#\\CSharpAutomationFramework\\CSharpAutomationFramework\\Screenshots\\", "screenshot.png").Build());
                if (stepType == "When")
                    step = scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
                if (stepType == "Then")
                    step = scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
                if (stepType == "And")
                    step = scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
            }

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    step = scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending", MediaEntityBuilder.CreateScreenCaptureFromPath("C:\\Users\\thomas.crosby\\Documents\\Projects\\C#\\CSharpAutomationFramework\\CSharpAutomationFramework\\Screenshots\\", "screenshot.png").Build());
                else if (stepType == "When")
                    step = scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    step = scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");

            }

            foreach (var log in logs)
            {
                step.Log(log.status, log.text);
            }

        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            featureName = extent.CreateTest(featurecontext.FeatureInfo.Title);
        }


        [BeforeScenario]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("-headless");
            _driverHelper.webDriver = new ChromeDriver(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Drivers\\", options);
           
            //Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
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
