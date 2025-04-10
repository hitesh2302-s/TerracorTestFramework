using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TerracorTestFramework.Pages;
using TerracorTestFramework.Utilities;
using NUnit.Framework;
using TerracorTestFramework.Models;

namespace TerracorTestFramework.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private TestDataModel _testData;

        public LoginSteps()
        {
            _driver = DriverHelper.GetDriver();
            _loginPage = new LoginPage(_driver);
            _testData = JsonDataReader.LoadTestData();
        }

        [Given(@"I launch the browser")]
        public void GivenILaunchTheBrowser()
        {
            _driver = DriverHelper.GetDriver();
        }

        [Given(@"I navigate to the TerraCor Hub page")]
        public void GivenINavigateToTheSite()
        {
            _driver.Navigate().GoToUrl(_testData.Url ?? throw new InvalidOperationException("URL is missing in TestData.json"));
        }

        [When(@"I click the login page")]
        public void WhenIClickTheLoginPage()
        {
            _loginPage.ClickLoginPage();
        }

        [When(@"I enter the username and password")]
        public void WhenIEnterUsernamePassword()
        {
            _loginPage.EnterUsername(_testData.LoginCredentials.Username ?? throw new InvalidOperationException("Username is missing in TestData.json"));
            _loginPage.EnterPassword(_testData.LoginCredentials.Password ?? throw new InvalidOperationException("Password is missing in TestData.json"));
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