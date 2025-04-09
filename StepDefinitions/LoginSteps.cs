using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TerracorTestFramework.Pages;
using TerracorTestFramework.Utilities;
using NUnit.Framework;

namespace TerracorTestFramework.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        public LoginSteps()
        {
            _driver = DriverHelper.GetDriver();
            _loginPage = new LoginPage(_driver);
        }

        [Given(@"I launch the browser")]
        public void GivenILaunchTheBrowser()
        {
            _driver = DriverHelper.GetDriver();
        }

        [Given(@"I navigate to the TerraCor Hub page")]
        public void GivenINavigateToTheSite()
        {
            _driver.Navigate().GoToUrl("https://hub-demo.terracor.ca/_staging/search?limit=12");
        }

        [When(@"I click the login page")]
        public void WhenIClickTheLoginPage()
        {
            _loginPage.ClickLoginPage();
        }

        [When(@"I enter the username and password")]
        public void WhenIEnterUsernamePassword()
        {
            _loginPage.EnterUsername("user976272");
            _loginPage.EnterPassword("Password@123");
        }

        [When(@"I click the login button")]
        public void WhenIClickLogin()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"I should be logged in and see the correct page title")]
        public void ThenIShouldSeeCorrectTitle()
        {
            string title = _driver.Title;
            Assert.That(title, Does.Contain("- Terracor Business Solutions"), $"Actual title was: '{title}'");
        }
    }
}
