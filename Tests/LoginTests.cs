using NUnit.Framework;
using SwagLabs.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Interfaces;

namespace SwagLabs.Tests
{
    public class LoginTests : BaseTests
    {
        [Test]
        public void VerifyThatLoginWithoutCredentialsDisplaysAnError()
        {
            string userName = "";
            string password = "";
            string errorMessage = "Epic sadface: Username is required";

            LoginPage loginPage = this.basePage.GoToLoginPage();
            loginPage.InputUsernameAndPassword(userName, password);
            Assert.IsTrue(loginPage.VerifyLoginErrorMessage(errorMessage), "Invalid/Missing error message for login without credentials");
        }

        [Test]
        public void VerifyThatLoginWithInvalidCredentialsDisplaysAnError()
        {
            string userName = "Test";
            string password = "123";
            string errorMessage = "Epic sadface: Username and password do not match any user in this service";

            LoginPage loginPage = this.basePage.GoToLoginPage();
            loginPage.InputUsernameAndPassword(userName, password);
            Assert.IsTrue(loginPage.VerifyLoginErrorMessage(errorMessage), "Invalid/Missing error message for login with invalid credentials");
        }

        [Test]
        public void VerifyThatLoginWithoutPasswordDisplaysAnError()
        {
            string userName = "Test";
            string password = "";
            string errorMessage = "Epic sadface: Password is required";

            LoginPage loginPage = this.basePage.GoToLoginPage();
            loginPage.InputUsernameAndPassword(userName, password);
            Assert.IsTrue(loginPage.VerifyLoginErrorMessage(errorMessage), "Invalid/Missing error message for login without password");
        }

        [Test]
        
        public void VerifyThatLoginWithValidCredentialsIsSuccessful()
        {
            string userName = "standard_user";
            string password = "secret_sauce";

            LoginPage loginPage = this.basePage.GoToLoginPage();
            HomePage homePage = loginPage.InputUsernameAndPassword(userName, password);
            Assert.IsTrue(homePage.VerifyIfHomePageIsLoaded(), "Home page is not loaded properly");
        }
    }
}