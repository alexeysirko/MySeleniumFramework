using MySeleniumFramework.Browser;
using OpenQA.Selenium;

namespace MySeleniumFramework.Elements.ElementTypes
{
    public class ElementsCollection<T> where T : BaseElement, new()
    {
        public List<T> Elements { get; } = new();
        internal By CommonLocator { get; }
        private IWebDriver _driver = BrowserFactory.GetDriver();

        public ElementsCollection(By locator)
        {
            CommonLocator = locator;           
            var type = typeof(T);
            var elementConstructor = type.GetConstructor(new Type[] { typeof(By) });

            int webElementsCount = GetFoundCount();
            for (int xpathIndex = 1; xpathIndex < webElementsCount; xpathIndex++)
            {
                string xpathWithIndex = $"({locator})[{xpathIndex}]";
                T elementWithIndex = (T)elementConstructor.Invoke(new object[] { xpathWithIndex });
                Elements.Add(elementWithIndex);
            }
        }

        public int GetFoundCount() => _driver.FindElements(CommonLocator).Count;
    }
}
