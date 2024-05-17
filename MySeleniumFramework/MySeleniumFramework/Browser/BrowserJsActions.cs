using OpenQA.Selenium;

namespace MySeleniumFramework.Browser
{
    public class BrowserJsActions
    {
        private readonly IWebDriver _driver = BrowserFactory.GetDriver();

        public void StopPageLoading(TimeSpan stopAfterTime)
        {
            Thread.Sleep(stopAfterTime);
            var js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.stop();");
        }
    }
}
