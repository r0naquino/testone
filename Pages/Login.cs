using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NUnitTestProject1.Pages
{
    public class Login : BasePage
    {

        private readonly By userNameField = By.CssSelector("input[type='email']");
        private readonly By passwordField = By.CssSelector("input[type='password']");
        private readonly By loginButton = By.XPath("//button[text()='Login']");

        public void InputUsernameAndPassword(string username, string password)
        {
            this.GetDriver().FindElementUntil(userNameField, 10).SendKeys(username);
            this.GetDriver().FindElement(passwordField).SendKeys(password);
            this.GetDriver().FindElement(loginButton).Click();
        }


    }
}
