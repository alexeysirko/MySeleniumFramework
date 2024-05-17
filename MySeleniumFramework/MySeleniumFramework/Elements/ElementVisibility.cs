using MySeleniumFramework.Elements.ElementTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MySeleniumFramework.Elements
{
    public class ElementVisibility
    {
        internal BaseElement Element { get; }


        internal ElementVisibility(BaseElement element)
        {
            Element = element;
        }

        public bool IsDisplayed() => Element.GetWebElement().Displayed;
        public bool IsEnabled() => Element.GetWebElement().Enabled;
        public bool IsExistInDOM() => Element.SameElementsCount() > 0;
        public bool IsNotExist() => Element.SameElementsCount() == 0;
    }
}
