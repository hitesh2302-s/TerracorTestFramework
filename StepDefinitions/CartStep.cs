using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TerracorTestFramework.Pages;
using TerracorTestFramework.Utilities;

namespace TerracorTestFramework.StepDefinitions
{
    [Binding]
    public class CartSteps
    {
        private IWebDriver _driver;
        private CartPage _cartPage;

        public CartSteps()
        {
            _driver = DriverHelper.GetDriver();
            _cartPage = new CartPage(_driver);
        }

        [When(@"I search for product ""(.*)""")]
        public void WhenISearchForProduct(string productCode)
        {
            Assert.That(_cartPage.SearchProduct(productCode), Is.True, "Item not found");
        }

        [When(@"I add (.*) quantities to the cart")]
        public void WhenIAddQuantitiesToTheCart(int quantity)
        {
            _cartPage.AddToCart(quantity);
            Assert.That(_cartPage.VerifyCart(), Is.True, "Item not found in cart");
        }

        [Then(@"I verify cart shows the product with correct total price")]
        public void ThenIVerifyCartShowsTheProductWithCorrectTotalPrice()
        {
            Assert.That(_cartPage.VerifyCartPrice(4.43), Is.True, "Incorrect total price");
        }

        [When(@"I empty the cart")]
        public void WhenIEmptyTheCart()
        {
            _cartPage.EmptyCart();
        }

        [When(@"I close the cart popup")]
        public void WhenICloseTheCartPopup()
        {
            _cartPage.CloseCart();
        }

        [Then(@"the cart should be empty")]
        public void ThenTheCartShouldBeEmpty()
        {
            Assert.That(_cartPage.IsCartEmpty(), Is.True, "Expected cart to be empty, but it wasn't.");
        }


    }
}
