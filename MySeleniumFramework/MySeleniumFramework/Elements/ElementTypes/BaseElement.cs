using MySeleniumFramework.Browser;
using OpenQA.Selenium;

namespace MySeleniumFramework.Elements.ElementTypes
{
    public abstract class BaseElement
    {
        internal By Locator { get; private set; }
        public IWebElement Element { get => GetWebElement(); }
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
    }
}
