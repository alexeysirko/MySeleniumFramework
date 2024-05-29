using MySeleniumFramework.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace MySeleniumFramework.Browser
{
    public class BrowserFactory
    {
        private static ThreadLocal<IWebDriver> _driverThreadLocal = new ThreadLocal<IWebDriver>();


        public static IWebDriver GetDriver()
        {
            if (_driverThreadLocal.Value == null)
            {
                _driverThreadLocal.Value = InitDriver();
            }
            return _driverThreadLocal.Value;
        }

        public static void QuitBrowser()
        {
            if (_driverThreadLocal.Value != null)
            {
                _driverThreadLocal.Value.Quit();
                _driverThreadLocal.Value = null;
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
