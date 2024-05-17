using MySeleniumFramework.Elements.ElementTypes;
using MySeleniumFramework.PageObjects;
using OpenQA.Selenium;

namespace BsuirExample.PageObjects
{
    internal class SciencePage : PageObject
    {
        public SciencePage() : base(new TextLabel(By.XPath("//*[@class='main-info-content']//*[contains(text(),'Наука')]")))
        {
        }
    }
}
