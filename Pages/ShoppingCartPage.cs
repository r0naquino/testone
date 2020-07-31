using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabs.Pages
{
    public class ShoppingCartPage : BasePage
    {
        IWebDriver driver;
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private readonly By shoppingCartHeader = By.CssSelector("");

        public bool VerifyIfShoppingCartPageIsLoaded()
        {
            return this.driver.ElementExists(shoppingCartHeader);
        }
    }
}
