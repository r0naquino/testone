using NUnit.Framework;
using SwagLabs.Pages;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace SwagLabs.Tests
{
    public class HomeTests : BaseTests
    {
        [Test]
        public void VerifyThatSpecificItemAddedAndRemovedToCartIsReflectedInTheInShoppingBagIconBadge()
        {
            string userName = "standard_user";
            string password = "secret_sauce";
            string item = "Sauce Labs Backpack";
            int quantity = 1;

            LoginPage loginPage = this.basePage.GoToLoginPage();
            HomePage homePage = loginPage.InputUsernameAndPassword(userName, password);
            Assert.IsTrue(homePage.VerifyIfHomePageIsLoaded(), "Home page is not loaded");
            homePage.AddItemToCart(item);
            Assert.IsTrue(homePage.VerifyNumberOfItemsInCart(quantity), "Item added to cart is not reflected in the shopping cart icon badge");
            homePage.RemoveItemsFromCart(item);
            Assert.IsTrue(homePage.VerifyNumberOfItemsInCart(0), "Item removed from cart is not reflecting in the shopping cart icon badge");
        }

        [Test]
        public void VerifyThatMultipleItemsAddedAndRemovedToCartIsReflectedInTheShoppingBagIconBadge()
        {
            string userName = "standard_user";
            string password = "secret_sauce";
            int noOfItems = 3;

            LoginPage loginPage = this.basePage.GoToLoginPage();
            HomePage homePage = loginPage.InputUsernameAndPassword(userName, password);
            Assert.IsTrue(homePage.VerifyIfHomePageIsLoaded(), "Home page is not loaded");
            homePage.AddItemToCart(noOfItems);
            Assert.IsTrue(homePage.VerifyNumberOfItemsInCart(noOfItems), "Item added to cart is not reflected in the shopping cart icon badge");
            homePage.RemoveItemsFromCart(noOfItems);
            Assert.IsTrue(homePage.VerifyNumberOfItemsInCart(0), "Item removed from cart is not reflecting in the shopping cart icon badge");
        }

        [Test]
        public void VerifyThatItemsAreSortedBasedOnFilter()
        {
            string userName = "standard_user";
            string password = "secret_sauce";
            string[] sortingFilter = new string[]{"Name (A to Z)", "Name (Z to A)", "Price (low to high)", "Price (high to low)"};

            LoginPage loginPage = this.basePage.GoToLoginPage();
            HomePage homePage = loginPage.InputUsernameAndPassword(userName, password);
            Assert.IsTrue(homePage.VerifyIfHomePageIsLoaded(), "Home page is not loaded");
            foreach (var item in sortingFilter)
            {
                homePage.SortItemsByFilter(item);
                Assert.IsTrue(homePage.VerifyThatItemsAreSorted(item), $"Items are not sorted by {item}");
            }
        }
    }
}
