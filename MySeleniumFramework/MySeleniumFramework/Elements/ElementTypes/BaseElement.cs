using MySeleniumFramework.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MySeleniumFramework.Elements.ElementTypes
{
    public abstract class BaseElement
    {
        public Actions Actions { get => new Actions(_driver); }
        public IWebElement Element { get => GetWebElement(); }
        internal By Locator { get; private set; }
        private IWebDriver _driver = BrowserFactory.GetDriver();


        protected BaseElement(By locator)
        {
            Locator = locator;
        }


        public IWebElement GetWebElement()
        {
            IWebElement element = _driver.FindElement(Locator);
            new ElementJsActions(element).HighlightElement();
            return element;
        }
    
        public ElementVisibility Visibility => new ElementVisibility(this);
        public ElementJsActions JsActions => new ElementJsActions(GetWebElement());
        public int SameElementsCount() => _driver.FindElements(Locator).Count;
        public string GetText() => GetWebElement().Text;
        public void Click() => GetWebElement().Click();
        public string GetValue()
        {
            return GetWebElement().GetCssValue("value");
        }
    }
}
