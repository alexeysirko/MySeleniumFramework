using MySeleniumFramework.Browser;
using OpenQA.Selenium;

namespace MySeleniumFramework.Elements.ElementTypes
{
    public abstract class BaseElement
    {
        internal By Locator { get; private set; }
        public IWebElement Element { get; private set; }
        private IWebDriver _driver = BrowserFactory.GetDriver();


        protected BaseElement(By locator)
        {
            Locator = locator;
            Element = GetWebElement();
        }

        public IWebElement GetWebElement() => _driver.FindElement(Locator);
        public ElementVisibility Visibility => new ElementVisibility(GetWebElement());
        public ElementJsActions JsActions => new ElementJsActions(GetWebElement());
        public string GetText() => GetWebElement().Text;
        public void Click() => GetWebElement().Click();
    }
}
