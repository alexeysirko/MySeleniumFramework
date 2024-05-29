using MySeleniumFramework.Browser;
using OpenQA.Selenium;

namespace MySeleniumFramework.Elements.ElementTypes
{
    public class ElementsCollection<T> where T : BaseElement, new()
    {
        public List<T> Elements { get; } = new();
        internal string CommonLocator { get; }
        private IWebDriver _driver = BrowserFactory.GetDriver();

        public ElementsCollection(string XPathLocator)
        {
            CommonLocator = XPathLocator;                 
        }

        public List<T> GetElements()
        {
            var type = typeof(T);
            var elementConstructor = type.GetConstructor(new Type[] { typeof(By) });

            int webElementsCount = GetFoundCount();
            for (int xpathIndex = 1; xpathIndex < webElementsCount; xpathIndex++)
            {
                By xpathWithIndex = By.XPath($"({CommonLocator})[{xpathIndex}]");
                T elementWithIndex = (T)elementConstructor.Invoke(new object[] { xpathWithIndex });
                Elements.Add(elementWithIndex);
            }

            return Elements;
        }

        public int GetFoundCount() => _driver.FindElements(By.XPath(CommonLocator)).Count;
    }
}
