using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NUnitTestProject1.Pages
{
    public class BasePage
    {
        IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly string url = "https://shopsm.com";
        private readonly By loginLink = By.XPath("//span[text()='Log in']");

        public void CloseDriver()
        {
            driver.Quit();
        }

        public bool AssertLoad()
        {
            return false;
        }

        public void OpenURL()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public LoginPage GoToLoginPage()
        {
            driver.FindElementUntil(loginLink, 10).Click();
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
    }
}