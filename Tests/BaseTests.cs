using NUnit.Framework;
using SwagLabs.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using NUnit.Framework.Interfaces;
using System.IO;

namespace SwagLabs.Tests
{
    public class BaseTests
    {
        IWebDriver driver;
        public BasePage basePage;

        [SetUp]
        public void StartTest()
        {
            driver = new ChromeDriver();
            basePage = new BasePage(driver);
        }

        [TearDown]
        public void EndTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                StringBuilder date = new StringBuilder(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                date.Replace("/", "_");
                date.Replace(":", "_");
                date.Replace(" ", "_");

                string testName = TestContext.CurrentContext.Test.MethodName;

                if (!Directory.Exists(@"C:\SeleniumScreenshot\FailedTests_"+ DateTime.Now.ToString("MM/dd/yyyy").Replace("/","_")))
                {
                    Directory.CreateDirectory(@"C:\SeleniumScreenshot\FailedTests_" + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "_"));
                }

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\SeleniumScreenshot\FailedTests_" + DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "_") + @"\FailedTest_" + testName + "_" + date + ".png", ScreenshotImageFormat.Png);
            }

            basePage.CloseDriver();
        }
    }
}
