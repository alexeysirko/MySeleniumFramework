using MySeleniumFramework.Elements.ElementTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MySeleniumFramework.Elements
{
    public class ElementVisibility
    {
        private readonly IWebElement _webElement;

        internal ElementVisibility(IWebElement element)
        {
            _webElement = element;
        }

        public bool IsDisplayed() => _webElement.Displayed;
        public bool IsEnabled() => _webElement.Enabled;
        public bool IsExist() => 
        public bool IsNotDisplayed() =>
    }
}
