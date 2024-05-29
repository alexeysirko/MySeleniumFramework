using OpenQA.Selenium;

namespace MySeleniumFramework.Elements.ElementTypes
{
    public class Button : BaseElement
    {
        public Button() : base(By.XPath(""))
        {
        }

        public Button(By locator) : base(locator)
        {
        }
    }
}
