using MySeleniumFramework.Browser;
using OpenQA.Selenium;

namespace MySeleniumFramework.Elements.ElementTypes
{
    public abstract class BaseElement
    {
        public By Locator { get; }
        public IWebElement Element { get; init; }
        private IWebDriver _driver = BrowserFactory.GetDriver();


        protected BaseElement(By locator)
        {
            Locator = locator;
            Element = GetWebElement();
        }


        public IWebElement GetWebElement() => _driver.FindElement(Locator);
        public ElementVisibility Visibility => new ElementVisibility(Element);
        public string GetText() => Element.Text;
        public void Click() => Element.Click();
    }
}
