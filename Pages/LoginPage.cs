using OpenQA.Selenium;

namespace TerracorTestFramework.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By loginPageLink = By.XPath("//a[contains(text(),'Login')]");
        private By usernameField = By.XPath("//input[@id='login-username']");
        private By passwordField = By.XPath("//input[@id='login-password']");
        private By loginButton = By.XPath("//button[@id='login-button']");

        public void ClickLoginPage() => _driver.FindElement(loginPageLink).Click();
        public void EnterUsername(string username) => _driver.FindElement(usernameField).SendKeys(username);
        public void EnterPassword(string password) => _driver.FindElement(passwordField).SendKeys(password);
        public void ClickLoginButton() => _driver.FindElement(loginButton).Click();
    }
}
