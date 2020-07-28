using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SwagLabs.Pages
{
    public class HomePage : BasePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private readonly By homePageHeader = By.CssSelector("div.product_label");
        private readonly By menu = By.XPath("//button[text()='Open Menu']");
        private readonly By shoppingCartIcon = By.CssSelector("#shopping_cart_container svg[data-icon='shopping-cart']");
        private readonly By shoppingCartIconBadge = By.CssSelector("span[class='fa-layers-counter shopping_cart_badge']");
        private readonly By productFilterDropDown = By.CssSelector("select.product_sort_container");
        private List<IWebElement> ProductFilterValues() => this.driver.FindElements(By.CssSelector("select option")).Select(a => a).ToList();
        private List<IWebElement> InventoryItems() => this.driver.FindElements(By.CssSelector("div.inventory_item")).Select(a => a).ToList();
        private List<IWebElement> InventoryItemNames() => this.driver.FindElements(By.XPath("//div[@class='inventory_item_name']")).Select(a => a).ToList();

        public bool VerifyIfHomePageIsLoaded()
        {
            return this.driver.ElementExists(homePageHeader);
        }

        public void AddItemToCartBasedOnItemName(string itemName)
        {
            foreach (var item in InventoryItemNames())
            {
                string addToCartButton = "//../../../div[@class='pricebar']/button[text()='ADD TO CART']";

                if (item.Text == itemName)
                {
                    var selector = item.FindElement(By.XPath(addToCartButton));
                    selector.Click();
                    break;
                }
            }
        }

        public bool VerifyThatItemIsAddedToCart(string quantity)
        {
            if (this.driver.FindElement(shoppingCartIconBadge).Text == quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
