using OpenQA.Selenium;

namespace MySeleniumFramework.Elements
{
    internal class JsActions
    {
        private readonly IWebElement _webElement;


        internal JsActions(IWebElement element)
        {
            _webElement = element;
        }


        public void HighlightElement()
        {
            var js = (IJavaScriptExecutor)_webElement;
            js.ExecuteScript("arguments[0].style.border='3px solid red'", _webElement);
        }

        public void ScrollToElement()
        {
            var js = (IJavaScriptExecutor)_webElement;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", _webElement);
        }

        public void DeleteElement()
        {
            var js = (IJavaScriptExecutor)_webElement;
            js.ExecuteScript("arguments[0].remove();", _webElement);
        }
    }
}
