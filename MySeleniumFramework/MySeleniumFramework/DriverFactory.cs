using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace MySeleniumFramework
{
    public class DriverFactory
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
            throw new NotImplementedException();
            string browserTypeFromConfig = null; //TO DO: Implement getting information from configuration
            string browserType = browserTypeFromConfig.ToLower();            
            return InitDriverByType(browserType);
        }
        
        private static IWebDriver InitDriverByType(string browserType, DriverOptions options = null)
        {
            return browserType switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new PlatformNotSupportedException($"Browser type '{browserType}' is not supported. Please pick another browser type in your config.")
            };
        }

        
    }
}
