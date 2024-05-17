using MySeleniumFramework.Browser;
using MySeleniumFramework.Elements.ElementTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MySeleniumFramework.Elements
{
    public static class WaitConditions
    {
        private static IWebDriver _driver = BrowserFactory.GetDriver();
        private static string ExpireMessage(By locator, string waitType, int totalSeconds)
            => $"Element with locator '{locator}' wasn't in '{waitType}' state after '{totalSeconds}' seconds";

        public static bool WaitForDisplayed(this BaseElement element, TimeSpan timeout)
        {
            WebDriverWait webDriverWait = new(_driver, timeout);
            webDriverWait.Message = ExpireMessage(element.Locator, "Displayed", timeout.Seconds);
            return webDriverWait.Until(_driver => element.Visibility.IsDisplayed());
        }

        public static bool WaitForDisappeared(this BaseElement element, TimeSpan timeout)
        {
            WebDriverWait webDriverWait = new(_driver, timeout);
            webDriverWait.Message = ExpireMessage(element.Locator, "Displayed", timeout.Seconds);
            return webDriverWait.Until(_driver => element.Visibility.IsDisplayed());
        }
    }
}
