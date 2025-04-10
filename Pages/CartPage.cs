using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using SeleniumExtras.WaitHelpers;

namespace TerracorTestFramework.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private By Keywords => By.XPath("(//input[@placeholder='Keywords'])[1]");
        private By SearchButton => By.XPath("//button[@data-cy='search-bar-button']");
        private By SearchResult => By.XPath("//div[@id='search-results-info']");
        private By AddToCartButton => By.XPath("//button[@aria-label='Add To Cart']");
        private By RegularPrice => By.XPath("//span[@class='regular_price']");
        private By CartLink => By.XPath("//a[@title='View Shopping Cart']");
        private By CartPrice => By.XPath("//strong[@class='text-danger']");

        private By emptyCart = By.XPath("//button[contains(text(),'Empty Cart')]");
        private By closeCart = By.XPath("(//button[@class='close']/i)[1]");

        public bool SearchProduct(string productName)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(Keywords)).SendKeys(productName);
            _wait.Until(ExpectedConditions.ElementToBeClickable(SearchButton)).Click();
            return _wait.Until(ExpectedConditions.ElementIsVisible(SearchResult)).Displayed;
        }

        public string GetRegularPrice()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(RegularPrice)).Text;
        }

        public void AddToCart(int quantity)
        {
            var addButton = _wait.Until(ExpectedConditions.ElementToBeClickable(AddToCartButton));
            for (int i = 0; i < quantity; i++)
            {
                addButton.Click();
                System.Threading.Thread.Sleep(3000); 
            }
        }

        public bool VerifyCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(CartLink)).Click();
            return _wait.Until(ExpectedConditions.ElementIsVisible(CartPrice)).Displayed;
        }

        public bool VerifyCartPrice(double expectedPrice)
        {
            var priceText = _wait.Until(ExpectedConditions.ElementIsVisible(CartPrice)).Text;
            Console.WriteLine("Cart price: " + priceText);

            var numericValue = priceText.Replace("$", "").Replace(" CAD", "");
            return double.TryParse(numericValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double price)
                   && Math.Abs(price - expectedPrice) < 0.01;
        }

        public void CloseCart()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(closeCart)).Click();
        }

        public void EmptyCart()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(emptyCart)).Click();
            Thread.Sleep(2000); 
        }

        public bool IsCartEmpty()
        {
            try
            {
                var emptyCartMessage = _driver.FindElement(By.XPath("//h3[normalize-space()='Your cart is empty.']"));
                return emptyCartMessage.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


    }
}
