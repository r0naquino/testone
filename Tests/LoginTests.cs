using NUnit.Framework;
using NUnitTestProject1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestProject1
{
    public class LoginTests : BaseTests
    {
        [Test]
        public void LoginWithoutCredentials()
        {
            string userName = "";
            string password = "";
            LoginPage loginPage = this.basePage.GoToLoginPage();
            loginPage.InputUsernameAndPassword(userName, password);
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            string userName = "Test";
            string password = "123";
            LoginPage loginPage = this.basePage.GoToLoginPage();
            loginPage.InputUsernameAndPassword(userName, password);
            Assert.IsTrue(loginPage.VerifyUsernameErrorExists(), "Invalid email address error is not displayed");
        }
    }
}