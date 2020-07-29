using NUnit.Framework;
using NUnit.Framework.Internal;
using SwagLabs.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework.Interfaces;
using System.Drawing.Imaging;

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

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\SeleniumScreenshot\FailedTest_" + testName + "_" + date + ".png", ScreenshotImageFormat.Png);
            }

            basePage.CloseDriver();
        }
    }
}
