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

        public BasePage()
        {
            driver = new ChromeDriver();
        }

        private readonly string url = "https://shopsm.com";
        private readonly By loginLink = By.XPath("//span[text()='Log in']");

        public IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                return driver;
            }
            else
            {
                return driver;
            }
        }

        public void CloseDriver()
        {
            while (driver != null)
            {
                driver.Quit();
            }
        }

        public bool AssertLoad()
        {
            return false;
        }

        public void OpenURL()
        {
            this.GetDriver().Manage().Window.Maximize();
            this.GetDriver().Navigate().GoToUrl(url);
        }

        public void GoToLoginPage()
        {
            this.GetDriver().FindElementUntil(loginLink, 10).Click();
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
    }
}