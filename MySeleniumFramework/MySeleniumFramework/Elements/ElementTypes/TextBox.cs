using OpenQA.Selenium;

namespace MySeleniumFramework.Elements.ElementTypes
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator) : base(locator)
        {
        }       

        public void TypeText(string text)
        {
            GetWebElement().SendKeys(text);
        }
    }
}
