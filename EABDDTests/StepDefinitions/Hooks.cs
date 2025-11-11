using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using EAFramework.Driver;
using Reqnroll;
using Reqnroll.Bindings;

namespace EABDDTests.StepDefinitions
{
    [Binding]
    public class Hooks
    {

        private static ExtentReports _extentReports;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly IPlaywrightDriver _playwrightDriver;
        private ExtentTest _scenario;

        public Hooks(FeatureContext featureContext, ScenarioContext scenarioContext, IPlaywrightDriver playwrightDriver)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _playwrightDriver = playwrightDriver;
        }

        [BeforeTestRun]
        public static void IntilializeExtentReports()
        {

            _extentReports = new ExtentReports();
            _extentReports.AddSystemInfo("Author", "Chandana");
            _extentReports.AddSystemInfo("Environment", "QA");
            _extentReports.AddSystemInfo("Project Name", "EA BDD Tests");
            var spark = new ExtentSparkReporter("ExtentReports.html");
            
            _extentReports.AttachReporter(spark);
        }


        [AfterStep]
        public async Task AfterStep()
        {

            var fileName = $"{_featureContext.FeatureInfo.Title.Trim()}";

            if (_scenarioContext.TestError == null)
            {

                switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    case StepDefinitionType.When:
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    case StepDefinitionType.Then:
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                }
            } else
            {
                switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text)
                            .Fail(_scenarioContext.TestError.Message, new ScreenCapture
                            {
                                Title = "Error Screenshot",
                                Path = await _playwrightDriver.TaskScreenshotAsPathAsync(fileName)
                            });
                        break;
                    case StepDefinitionType.When:
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text)
                            .Fail(_scenarioContext.TestError.Message, new ScreenCapture
                            {
                                Title = "Error Screenshot",
                                Path = await _playwrightDriver.TaskScreenshotAsPathAsync(fileName)
                            });
                        break;
                    case StepDefinitionType.Then:
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text)
                            .Fail(_scenarioContext.TestError.Message, new ScreenCapture
                            {
                                Title = "Error Screenshot",
                                Path = await _playwrightDriver.TaskScreenshotAsPathAsync(fileName)
                            });
                        break;
                }
            }
        }


        [BeforeScenario]
        public void BeforeScenario()
        {

            var feature = _extentReports.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _scenario = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterTestRun]
        public static void FlushExtentReports()
        {
            _extentReports.Flush();
        }
    }
}