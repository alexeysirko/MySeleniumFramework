using MySeleniumFramework.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace MySeleniumFramework.Browser
{
    public class BrowserFactory
    {
        private static ThreadLocal<IWebDriver> driverThreadLocal = new ThreadLocal<IWebDriver>();


        public static IWebDriver GetDriver()
        {
            if (driverThreadLocal.Value == null)
            {
                driverThreadLocal.Value = InitDriver();
            }
            return driverThreadLocal.Value;
        }

        public static void QuitBrowser()
        {
            if (driverThreadLocal.Value != null)
            {
                driverThreadLocal.Value.Quit();
                driverThreadLocal.Value = null;
            }
        }


        private static IWebDriver InitDriver()
        {
            BrowserSettings browserSettings = new();
            string browserType = browserSettings.BrowserName.ToLower();
            return InitDriverByType(browserType);
        }

        private static IWebDriver InitDriverByType(string browserName, DriverOptions options = null)
        {
            ChromeOptions chromeOptions = new();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;

            return browserName switch
            {
                "chrome" => new ChromeDriver(chromeOptions),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new PlatformNotSupportedException($"Browser type '{browserName}' is not supported. Please pick another browser type in your config.")
            };
        }
    }
}
