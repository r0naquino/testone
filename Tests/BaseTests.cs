using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnitTestProject1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    public class BaseTests
    {
        public static IWebDriver driver = new ChromeDriver();
        
        public BasePage basePage = new BasePage(driver);

        [SetUp]
        public void StartTest()
        {
            basePage.OpenURL();
        }

        [TearDownAttribute]
        public void EndTest()
        {
            basePage.CloseDriver();
        }
    }
}
