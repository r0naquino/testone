using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SwagLabs.Pages
{
    public class LoginPage : BasePage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private readonly By userNameField = By.CssSelector("input[id='user-name']");
        private readonly By passwordField = By.CssSelector("input[id='password']");
        private readonly By loginButton = By.XPath("//input[@id='login-button']");
        private readonly By loginError = By.CssSelector("h3[data-test='error']");

        public HomePage InputUsernameAndPassword(string username, string password)
        {
            this.driver.FindElementUntil(userNameField, 10).SendKeys(username);
            this.driver.FindElement(passwordField).SendKeys(password);
            this.driver.FindElement(loginButton).Click();
            return new HomePage(driver);
        }

        public bool VerifyLoginErrorMessage(string errorMessage)
        {
            if (this.driver.ElementExists(loginError))
            {
                return errorMessage == this.driver.FindElement(loginError).Text;
            }
            else
            {
                return false;
            }
        }
    }
}
