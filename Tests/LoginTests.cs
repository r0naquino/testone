using NUnit.Framework;
using NUnitTestProject1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestProject1
{
    public class LoginTests : BaseTests
    {
        Login login = new Login();

        [Test]
        public void LoginWithoutCredentials()
        {
            string userName = "";
            string password = "";
            this.OpenURL();
            this.GoToLoginPage();
            login.InputUsernameAndPassword(userName, password);
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            string userName = "Test";
            string password = "123";
            this.OpenURL();
            this.GoToLoginPage();
            login.InputUsernameAndPassword(userName, password);
        }
    }
}