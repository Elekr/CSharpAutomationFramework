using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace CSharpAutomationFramework
{
    [Binding]
    class Hook
    {

        private static ExtentTest? featureName;
        private static ExtentTest? scenario;
        private static ExtentReports? extent;

        private DriverHelper _driverHelper;

        public Hook(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
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

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext sc)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(sc, null);
            if (sc.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            if (sc.TestError != null)
            {
                // https://www.extentreports.com/docs/versions/4/net/index.html
                // MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build()); used to take the screenshots when the tests fail
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("C:\\Users\\thomas.crosby\\Documents\\Projects\\C#\\CSharpAutomationFramework\\CSharpAutomationFramework\\Screenshots\\", "screenshot.png").Build());
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
            }

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending", MediaEntityBuilder.CreateScreenCaptureFromPath("C:\\Users\\thomas.crosby\\Documents\\Projects\\C#\\CSharpAutomationFramework\\CSharpAutomationFramework\\Screenshots\\", "screenshot.png").Build());
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

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
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
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
