using BoDi;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlow.Tests
{
    [Binding]
    public sealed class Hooks_Initialize
    {

        [BeforeTestRun]
        public static void BeforeTestRun(IObjectContainer container)
        {
            Console.WriteLine("Before Test run Initialized");
        }

        [BeforeFeature]
        public static void BeforeFeature( FeatureContext featureContext)
        {
            
            Console.WriteLine($"Before feature Started:{featureContext.FeatureInfo.Title}");
           
        }
        [AfterFeature]
        public static void AfterFeature( FeatureContext featureContext)
        {
            Console.WriteLine($"After feature ended:{featureContext.FeatureInfo.Title}");

        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
          

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            //Initialize the config file data
            Console.WriteLine("starting scenario");
        
        }
        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
           

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            scenarioContext.ScenarioContainer.RegisterInstanceAs(stopWatch);
            //Initialize the config file data
            Console.WriteLine("After scenario");

        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            //TODO! - Add before step logic here if required.
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
           
            bool stepStatus = scenarioContext.ScenarioExecutionStatus.HasFlag(ScenarioExecutionStatus.TestError);
            Console.WriteLine("Step status :" + stepStatus);
        }

        public enum TestExecutionStatus
        {
            PASS = 0, FAIL = 1, PENDING = 2, UNKNOWN = 3, SKIPPED = 4
        }
        private TestExecutionStatus ParseTestExecutionStatus(ScenarioExecutionStatus status)
        {
            var testResult = TestExecutionStatus.UNKNOWN;
            switch (status)
            {
                case ScenarioExecutionStatus.OK:
                    testResult = TestExecutionStatus.PASS;
                    break;
                case ScenarioExecutionStatus.StepDefinitionPending:
                    testResult = TestExecutionStatus.UNKNOWN;
                    break;
                case ScenarioExecutionStatus.UndefinedStep:
                    testResult = TestExecutionStatus.UNKNOWN;
                    break;
                case ScenarioExecutionStatus.BindingError:
                    testResult = TestExecutionStatus.FAIL;
                    break;
                case ScenarioExecutionStatus.TestError:
                    testResult = TestExecutionStatus.FAIL;
                    break;
                case ScenarioExecutionStatus.Skipped:
                    testResult = TestExecutionStatus.SKIPPED;
                    break;
                default:
                    break;
            }
            return testResult;
        }

        [AfterTestRun]
        public static void AfterTestRun(IObjectContainer container)
        {
            Console.WriteLine("After test run completed");
        }

        private double GetRealMinutesDouble(TimeSpan a)
        {
            var aSecondsPart = a.TotalMinutes - Math.Truncate(a.TotalMinutes);// Cut the decimal part which shows the seconds
            var aSecondsPartInRealSeconds = Math.Round(aSecondsPart * 60 / 100 * 100) / 100;// convert them to the interval 0-59
            return Math.Truncate(a.TotalMinutes) + aSecondsPartInRealSeconds;//add them back
        }

        private void CaptureScreenshot()
        {
           
        }
    }
}