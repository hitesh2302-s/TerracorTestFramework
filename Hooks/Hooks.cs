using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TerracorTestFramework.Utilities;

namespace TerracorTestFramework.Hooks
{
    [Binding]
    public sealed class Hook
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverHelper.driver = new ChromeDriver();
            DriverHelper.driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (DriverHelper.driver != null)
            {
                DriverHelper.driver.Quit();
            }
        }
    }
}
