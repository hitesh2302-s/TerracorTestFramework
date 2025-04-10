using OpenQA.Selenium;

namespace TerracorTestFramework.Utilities
{
    public static class DriverHelper
    {
        public static IWebDriver? driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
                throw new Exception("WebDriver not initialized. Call Initialize() first.");
            return driver;
        }
    }
}
