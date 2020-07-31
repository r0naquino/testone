using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        /// <summary>
        /// Adding item to cart based on item name
        /// </summary>
        /// <param name="itemName">item name</param>
        public void AddItemToCart(string itemName)
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

        /// <summary>
        /// Adding items to cart based on number of items to be added
        /// </summary>
        /// <param name="noOfItems">no of items</param>
        public void AddItemToCart(int noOfItems)
        {
            for (int i = 0; i < noOfItems; i++)
            {
                var item = InventoryItemNames()[i];
                string addToCartButton = "//../../../div[@class='pricebar']/button[text()='ADD TO CART']";

                item.FindElement(By.XPath(addToCartButton)).Click();

            }
        }

        /// <summary>
        /// Verify the number of items in cart
        /// </summary>
        /// <param name="quantity">expected quantity</param>
        /// <param name="action">action done to update cart</param>
        /// <returns></returns>
        public bool VerifyNumberOfItemsInCart(int quantity)
        {
            
            if (quantity == 0 && !this.driver.ElementExists(shoppingCartIconBadge))
            {
                return true;
            }

            var iconBadge = this.driver.FindElement(shoppingCartIconBadge);
            Actions ac = new Actions(driver);
            ac.MoveToElement(iconBadge);
            int iconBadgeNumber = int.Parse(iconBadge.Text);

            if (iconBadgeNumber == quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Remove item from cart based on no of items
        /// </summary>
        /// <param name="noOfItems"></param>
        public void RemoveItemsFromCart(int noOfItems)
        {
            for (int i = 0; i < noOfItems; i++)
            {
                var item = InventoryItemNames()[i];
                string addToCartButton = "//../../../div[@class='pricebar']/button[text()='REMOVE']";

                item.FindElement(By.XPath(addToCartButton)).Click();

            }
        }

        /// <summary>
        /// Remove item from card based on item name
        /// </summary>
        /// <param name="itemName">item name</param>
        public void RemoveItemsFromCart(string itemName)
        {
            foreach (var item in InventoryItemNames())
            {
                string addToCartButton = "//../../../div[@class='pricebar']/button[text()='REMOVE']";

                if (item.Text == itemName)
                {
                    var selector = item.FindElement(By.XPath(addToCartButton));
                    selector.Click();
                    break;
                }
            }
        }

        /// <summary>
        /// Sort items by Filter name
        /// </summary>
        /// <param name="sortingFilter">values: Name (A to Z), Name (Z to A), Price (low to high), Price (high to low)</param>
        public void SortItemsByFilter(string sortingFilter)
        {
            if ((sortingFilter == "Name (A to Z)") || (sortingFilter == "Name (Z to A)")
                || (sortingFilter == "Price (low to high)") || (sortingFilter == "Price (high to low)"))
            {
                this.driver.FindElement(productFilterDropDown).Click();

                foreach (var item in ProductFilterValues())
                {
                    if (item.Text == sortingFilter)
                    {
                        item.Click();
                        break;
                    }
                }
            }
            else
            {
                throw new Exception($"Invalid Filter is used - {sortingFilter}");
            }
        }

        public bool VerifyThatItemsAreSorted(string sortingFilter)
        {
            List<string> items;
            List<string> orderedItems;
            List<float> itemPrice;
            List<float> orderedItemPrice;

            int count = this.InventoryItems().Count;
            string itemNameSelector = "div.inventory_item_name";
            string itemPriceSelector = "div.inventory_item_price";

            switch (sortingFilter)
            {

                case "Name (A to Z)":

                    items = new List<string>();

                    foreach (var item in InventoryItems())
                    {
                        string product = item.FindElement(By.CssSelector(itemNameSelector)).Text;
                        items.Add(product);
                    }

                    orderedItems = new List<string>(items.OrderBy(a => a));

                    for (int i = 0; i < count; i++)
                    {
                        if (items[i] == orderedItems[i])
                        {
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;

                case "Name (Z to A)":

                    items = new List<string>();

                    foreach (var item in InventoryItems())
                    {
                        string product = item.FindElement(By.CssSelector(itemNameSelector)).Text;
                        items.Add(product);
                    }

                    orderedItems = new List<string>(items.OrderByDescending(a => a));

                    for (int i = 0; i < count; i++)
                    {
                        if (items[i] == orderedItems[i])
                        {
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;

                case "Price (low to high)":

                    itemPrice = new List<float>();

                    foreach (var item in InventoryItems())
                    {
                        string product = item.FindElement(By.CssSelector(itemPriceSelector)).Text;
                        float price = float.Parse(product.Remove(0, 1));
                        itemPrice.Add(price);
                    }

                    orderedItemPrice = new List<float>(itemPrice.OrderBy(a => a));

                    for (int i = 0; i < count; i++)
                    {
                        if (itemPrice[i] == orderedItemPrice[i])
                        {
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;

                case "Price (high to low)":

                    itemPrice = new List<float>();

                    foreach (var item in InventoryItems())
                    {
                        string product = item.FindElement(By.CssSelector(itemPriceSelector)).Text;
                        float price = float.Parse(product.Remove(0, 1));
                        itemPrice.Add(price);
                    }

                    orderedItemPrice = new List<float>(itemPrice.OrderByDescending(a => a));

                    for (int i = 0; i < count; i++)
                    {
                        if (itemPrice[i] == orderedItemPrice[i])
                        {
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;

                default:
                    return false;
            }
        }

        public ShoppingCartPage GoToShoppingBag()
        {
            this.driver.FindElement(shoppingCartIcon).Click();
            return new ShoppingCartPage(driver);
        }
    }
}
