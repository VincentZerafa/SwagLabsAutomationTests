using NUnit.Framework;
using OpenQA.Selenium;
using SwagLabsAutomationTests.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SwagLabsAutomationTests.StepDefinitions
{
    [Binding]
    public class ShoppingCartStepDefinitions
    {
        private ShoppingCartPageObject _shoppingCartPageObject;

        public ShoppingCartStepDefinitions()
        {
            _shoppingCartPageObject = new ShoppingCartPageObject();
        }

        [Given(@"user is logged in with username ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenUserIsLoggedInWithUsernameAndPassword(string username, string password)
        {
            _shoppingCartPageObject.RedirectToLoginPage();
            _shoppingCartPageObject.Login(username, password);
        }

        [Given(@"user clicks on add to cart for product ""([^""]*)""")]
        [When(@"user clicks on add to cart for product ""([^""]*)""")]
        public void WhenUserClicksOnAddToCartForProduct(string productName)
        {
            _shoppingCartPageObject.ClickAddToCart(productName);
        }

        [Given(@"the product should be added to cart with number showing (.*)")]
        [Then(@"the product should be added to cart with number showing (.*)")]
        public void ThenTheProductShouldBeAddedToCartWithNumberShowing(int numberOfProducts)
        {
            IWebElement numberOfProductsLabel = _shoppingCartPageObject.GetNumberOfProductsInCart();

            int expectedNumberOfProducts = int.Parse(numberOfProductsLabel.Text);

            expectedNumberOfProducts.Should().Be(numberOfProducts);
        }

        [Given(@"the user should be redirected to the page ""([^""]*)""")]
        [Then(@"the user should be redirected to the page ""([^""]*)""")]
        public void ThenTheUserShouldBeRedirectedToTheCatalogPage(string expectedRedirectUrl)
        {
            _shoppingCartPageObject.WaitUntilPageLoad(expectedRedirectUrl).Should().Be(true);
        }

        [Given(@"user clicks on the cart button")]
        [When(@"user clicks on the cart button")]
        public void WhenUserClicksOnTheCartButton()
        {
            _shoppingCartPageObject.ClickCartButton();
        }

        [Then(@"the product ""([^""]*)"" should be visible in cart")]
        public void ThenTheProductShouldBeVisibleInCartWithAQuantityOf(string productName)
        {
            IWebElement product = _shoppingCartPageObject.GetProductFromCart(productName);

            product.Should().NotBeNull();
        }

        [When(@"user clicks on remove button for product ""([^""]*)""")]
        public void WhenUserClicksOnRemoveButton(string productName)
        {
            _shoppingCartPageObject.ClickRemove(productName);
        }

        [Then(@"the cart should be emptied")]
        public void ThenTheCartShouldBeEmptied()
        {
            IWebElement numberOfProductsLabel = _shoppingCartPageObject.GetNumberOfProductsInCart();

            numberOfProductsLabel.Should().Be(null);
        }

        [Given(@"user clicks on checkout button")]
        [When(@"user clicks on checkout button")]
        public void WhenUserClicksOnCheckoutButton()
        {
            _shoppingCartPageObject.ClickCheckout();
        }

        [Given(@"user inputs ""([^""]*)"" as ""([^""]*)""")]
        [When(@"user inputs ""([^""]*)"" as ""([^""]*)""")]
        public void WhenUserInputsAs(string fieldName, string value)
        {
            _shoppingCartPageObject.InputFieldValue(fieldName, value);
        }

        [Given(@"user clicks on continue button")]
        [When(@"user clicks on continue button")]
        public void WhenUserClicksOnContinueButton()
        {
            _shoppingCartPageObject.ClickContinue();
        }

        [When(@"user clicks on finish button")]
        public void WhenUserClicksOnFinishButton()
        {
            _shoppingCartPageObject.ClickFinish();
        }

        [Then(@"a message with ""([^""]*)"" is displayed to the user")]
        public void ThenAMessageWithIsDisplayedToTheUser(string message)
        {
            IWebElement thankyouMessage = _shoppingCartPageObject.GetThankYouMessage();

            thankyouMessage.Should().NotBeNull();
            thankyouMessage.Text.Should().Be(message);
        }

        [AfterScenario("shoppingCart")]
        public void AfterScenario()
        {
            _shoppingCartPageObject.Dispose();
        }
    }
}
