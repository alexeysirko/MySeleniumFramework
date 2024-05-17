using MySeleniumFramework.Elements.ElementTypes;
using MySeleniumFramework.PageObjects;
using OpenQA.Selenium;

namespace BsuirExample.PageObjects
{
    internal class BsuirMainPage : PageObject
    {
        private Button MenuButton(string menuText) => new(By.XPath($"//*[@id='menu_1']//*[text()='{menuText}']"));

        public BsuirMainPage() : base(new ImageLabel(By.ClassName("gallery")))
        {
        }

        public void ClickMenuButtonByText(string menuText) => MenuButton(menuText).Click();
    }
}
