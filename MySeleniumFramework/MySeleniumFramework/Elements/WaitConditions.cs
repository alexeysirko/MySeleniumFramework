using MySeleniumFramework.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MySeleniumFramework.Elements
{
    public static class WaitConditions
    {
        private static IWebDriver _driver = BrowserFactory.GetDriver();
        private static string ExpireMessage(By locator, string waitType, int totalSeconds)
            => $"Element with locator '{locator}' wasn't in '{waitType}' state after '{totalSeconds}' seconds";

        public static bool WaitForDisplayed(this ElementVisibility visibility, TimeSpan timeout)
        {
            WebDriverWait webDriverWait = new(_driver, timeout);
            webDriverWait.Message = ExpireMessage(visibility.Element.Locator, "Displayed", timeout.Seconds);
            return webDriverWait.Until(_driver => visibility.IsDisplayed());
        }

        public static bool WaitForDisappeared(this ElementVisibility visibility, TimeSpan timeout)
        {
            WebDriverWait webDriverWait = new(_driver, timeout);
            webDriverWait.Message = ExpireMessage(visibility.Element.Locator, "Displayed", timeout.Seconds);
            return webDriverWait.Until(_driver => !visibility.IsDisplayed());
        }

        public static bool WaitForNotExist(this ElementVisibility visibility, TimeSpan timeout)
        {
            WebDriverWait webDriverWait = new(_driver, timeout);
            webDriverWait.Message = ExpireMessage(visibility.Element.Locator, "Displayed", timeout.Seconds);
            return webDriverWait.Until(_driver => !visibility.IsNotExist());
        }
    }
}
