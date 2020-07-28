using NUnit.Framework;
using SwagLabs.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabs.Tests
{
    public class HomeTests : BaseTests
    {
        [Test]
        public void VerifyThatItemAddedToCartIsReflectedInShoppingBagIconBadge()
        {
            string userName = "standard_user";
            string password = "secret_sauce";
            string item = "Sauce Labs Backpack";

            LoginPage loginPage = this.basePage.GoToLoginPage();
            HomePage homePage = loginPage.InputUsernameAndPassword(userName, password);
            Assert.IsTrue(homePage.VerifyIfHomePageIsLoaded(), "Home page is not loaded");
            homePage.AddItemToCartBasedOnItemName(item);
            Assert.IsTrue(homePage.VerifyThatItemIsAddedToCart("1"), "Item added to cart is not reflected in the shopping bag icon badge");
        }
    }
}
