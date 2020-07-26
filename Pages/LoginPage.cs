using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NUnitTestProject1.Pages
{
    public class LoginPage : BasePage
    {

        IWebDriver driver;

        public LoginPage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }

        private readonly By userNameField = By.CssSelector("input[type='email']");
        private readonly By passwordField = By.CssSelector("input[type='password']");
        private readonly By loginButton = By.XPath("//button[text()='Login']");

        public void InputUsernameAndPassword(string username, string password)
        {
            this.driver.FindElementUntil(userNameField, 10).SendKeys(username);
            this.driver.FindElement(passwordField).SendKeys(password);
            this.driver.FindElement(loginButton).Click();
        }


    }
}
