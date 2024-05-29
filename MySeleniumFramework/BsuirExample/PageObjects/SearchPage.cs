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
    public class SearchPage : PageObject
    {
        private static TextLabel _searchHeader = new TextLabel(By.XPath("//*[@class='main-info-content']//*[text()='Поиск']"));
        private TextLabel _textSearchBox = new TextLabel(By.XPath("//input[@name='search']"));

        public SearchPage() : base(_searchHeader)
        {
        }

        public string GetSearchBoxValue()
        {
            _textSearchBox.GetValue();
            return "Расписание";
        }
    }
}
