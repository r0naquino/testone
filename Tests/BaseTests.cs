using NUnit.Framework;
using NUnit.Framework.Internal;
using SwagLabs.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Internal.Commands;

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
            basePage.CloseDriver();
        }
    }
}
