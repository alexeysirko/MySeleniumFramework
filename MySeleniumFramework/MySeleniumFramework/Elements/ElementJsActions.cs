using MySeleniumFramework.Browser;
using OpenQA.Selenium;

namespace MySeleniumFramework.Elements
{
    public class ElementJsActions
    {
        private readonly IWebElement _webElement;
        private readonly IWebDriver _driver = BrowserFactory.GetDriver();

        internal ElementJsActions(IWebElement element)
        {
            _webElement = element;
        }


        public void HighlightElement()
        {
            var js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].style.border='3px solid red'", _webElement);
        }

        public void ScrollToElement()
        {
            var js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", _webElement);
        }

        public void DeleteElement()
        {
            var js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].remove();", _webElement);
        }
    }
}
