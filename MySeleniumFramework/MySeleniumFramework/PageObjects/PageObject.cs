using MySeleniumFramework.Elements;
using MySeleniumFramework.Elements.ElementTypes;

namespace MySeleniumFramework.PageObjects
{
    public abstract class PageObject
    {
        protected BaseElement _uniqueElement;

        protected PageObject(BaseElement uniqueElement)
        {
            _uniqueElement = uniqueElement;
        }

        public bool WaitForOpened(TimeSpan timeout)
        {
            return _uniqueElement.Visibility.WaitForDisplayed(timeout);
        }
    }
}
