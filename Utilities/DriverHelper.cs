using OpenQA.Selenium;

namespace TerracorTestFramework.Utilities
{
    public static class DriverHelper
    {
        // ✅ Declare as nullable with `?`
        public static IWebDriver? driver;

        // Optional helper method
        public static IWebDriver GetDriver()
        {
            if (driver == null)
                throw new Exception("WebDriver not initialized. Call Initialize() first.");
            return driver;
        }
    }
}
