using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SwagLabs.Pages
{
    public class BasePage
    {
        IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly string url = "https://www.saucedemo.com/";

        public void CloseDriver()
        {
            driver.Quit();
        }

        public bool AssertLoad()
        {
            return false;
        }

        public LoginPage GoToLoginPage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return new LoginPage(driver);
        }

    }
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementUntil(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static bool ElementExists(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void WaitUntilPageIsLoaded(this IWebDriver driver, int timeoutInSeconds)
        {
            var javaScriptExecutor = driver as IJavaScriptExecutor;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            try
            {
                Func<IWebDriver, bool> readyCondition = webDriver => (bool)javaScriptExecutor.ExecuteScript("return (document.readyState == 'complete' && jQuery.active == 0)");
                wait.Until(readyCondition);
            }
            catch (InvalidOperationException)
            {
                wait.Until(wd => javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
            }
        }
    }
}