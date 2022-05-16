using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.IO;
using WebDriverManager.DriverConfigs.Impl;

using Driver_Automation_Assessment.utilities;

namespace CsharpSelFramework.Utilities
{
    public class Base

    {
        public ExtentReports extent; //key boject listings to test case results and updates results to html
        public ExtentTest test;
        public String browserName;

        [OneTimeSetUp]
        public void Setup()
        {

            // report file getting current directory moving to parent generate file and pass path
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportpath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportpath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Hostname", "Local host");
            extent.AddSystemInfo("Envrionment", "QA ");
            extent.AddSystemInfo("Username", "Simphiwe");

        }
        public IWebDriver driver;

      
        [SetUp]

        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            // configuration passing browser type
            
            string browserName = System.Configuration.ConfigurationManager.AppSettings["browser"];
             

            InitBrowser(browserName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.ilabquality.com/";
        }

        // Method to call driver - not calling driver directly
        public IWebDriver getDriver()
        {
            return driver;
        }

        public void InitBrowser(string browserName)

        {
            switch (browserName)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

            }

        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();

        }

        [TearDown]

        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            String filename = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {
                test.Fail("Test fail", captureScreenShot(getDriver(), filename));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
            }
            else if (status == TestStatus.Passed)
            {

            }

            extent.Flush();
            driver.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, string screenShotname)
        {

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotname).Build();

        }
    }
}
