using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomationTests.PageObjects
{
    public class ShoppingCartPageObject : LoginPageObject
    {
        public ShoppingCartPageObject() : base()
        {
        }

        private IWebElement _cartButton => Driver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a"));
        private IWebElement _checkoutButton => Driver.FindElement(By.Id("checkout"));
        private IWebElement _continueButton => Driver.FindElement(By.Id("continue"));
        private IWebElement _finishButton => Driver.FindElement(By.Id("finish"));

        public IWebElement GetAddToCartButton(string productName)
        {
            string formattedProductName = StringFormatter.SeparateWordsByHyphen(productName).ToLower();

            return Driver.FindElement(By.Name($"add-to-cart-{formattedProductName}"));
        }

        public IWebElement GetRemoveButton(string productName)
        {
            string formattedProductName = StringFormatter.SeparateWordsByHyphen(productName).ToLower();

            return Driver.FindElement(By.Name($"remove-{formattedProductName}"));
        }

        public IWebElement GetNumberOfProductsInCart()
        {
            try
            {
                return Driver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a/span"));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public List<IWebElement> GetProductsFromCart()
        {
            return Driver.FindElements(By.ClassName("inventory_item_name")).ToList();
        }

        public IWebElement GetProductFromCart(string productName)
        {
            return GetProductsFromCart().SingleOrDefault(x => x.Text.Equals(productName));
        }

        public void ClickAddToCart(string productName)
        {
            IWebElement addToCart = GetAddToCartButton(productName);
            addToCart.Click();
        }

        public void ClickRemove(string productName)
        {
            IWebElement addToCart = GetRemoveButton(productName);
            addToCart.Click();
        }

        public void ClickCartButton()
        {
            _cartButton.Click();
        }

        public void ClickCheckout()
        {
            _checkoutButton.Click();
        }

        public void InputFieldValue(string fieldName, string value)
        {
            string formattedFieldName = StringFormatter.SeparateWordsByHyphen(fieldName).ToLower();

            IWebElement field = Driver.FindElement(By.Id(formattedFieldName));

            field.SendKeys(value);
        }

        public void ClickContinue()
        {
            _continueButton.Click();
        }

        public void ClickFinish()
        {
            _finishButton.Click();
        }

        public IWebElement GetThankYouMessage()
        {
            try
            {
                return Driver.FindElement(By.XPath("//*[@id=\"checkout_complete_container\"]/h2"));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
    }
}
