using MySeleniumFramework.Elements.ElementTypes;
using MySeleniumFramework.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsuirExample.PageObjects
{
    internal class AchievementsPage : PageObject
    {
        private static Container s_newsContainer = new Container(By.XPath("//*[contains(@class,'news-margin')]"));
        private ElementsCollection<Button> _achievementsButtons => new ElementsCollection<Button>("//*[contains(@class,'news-padding')]/a");

        public AchievementsPage() : base(s_newsContainer)
        {
        }

        public void CheckLinksTexts()
        {
            foreach(var element in _achievementsButtons.GetElements())
            {
                element.GetText();
                Thread.Sleep(150);
            }
        }
    }
}
