using MySeleniumFramework.Elements.ElementTypes;
using MySeleniumFramework.PageObjects;
using OpenQA.Selenium;

namespace BsuirExample.PageObjects
{
    internal class BsuirMainPage : PageObject
    {
        private Button MenuButton(string menuText) => new(By.XPath($"//*[@id='menu_1']//*[text()='{menuText}']"));
        private TextLabel MenuOption(string optionText) => new(By.XPath($"//*[@id='menu_1']//*[@class='bh-menu-popup']//*[text()='{optionText}']"));
        private TextLabel _logoText = new TextLabel(By.XPath("//*[@class='title desktop']"));
        private Container _header = new Container(By.XPath("//*[contains(@class,'top-header desktop')]"));
        private Container _middleHeader = new(By.XPath("//*[contains(@class,'middle-header-cont')]"));
        private Container _footer = new Container(By.XPath("//*[contains(@class,'main-footer-cont')]"));
        private Button _contactUs = new Button(By.XPath("//*[contains(@class,'main-footer-cont')]//*[contains(@class,'social-icon-admin')]"));
        private Button _engLanguage = new Button(By.XPath("//*[contains(@class,'languages')]//*[text()='eng']"));
        private ImageLabel _headerLogo = new ImageLabel(By.XPath("//*[contains(@class,'header')]//*[contains(@class,'logo-img')]"));
        private TextBox _searchBox = new TextBox(By.XPath("//input[@class='search-input']"));
        private Button _arrowRight = new Button(By.XPath("//*[@u='arrowright']"));
        private TextBox _searchTextBox = new TextBox(By.XPath("//*[@class='search-input']"));
        private Button _searchButton = new Button(By.XPath("//*[@name='search'][@type='submit']"));
        private Button _achivementsButton = new Button(By.XPath("//a[contains(@href,'achievements')]"));


        public BsuirMainPage() : base(new ImageLabel(By.ClassName("gallery")))
        {
        }


        internal void ClickMenuButtonByText(string menuText) => MenuButton(menuText).Click();
        internal bool IsOptionWithTextDisplayed(string optionText) => MenuOption(optionText).Visibility.IsDisplayed();
        internal void HoverMouseToMenuButton(string menuText)
        {
            var element = MenuButton(menuText).GetWebElement();
            MenuButton(menuText).Actions.MoveToElement(element).Perform();
        }
        internal void ClickArrowRight() => _arrowRight.Click();
        internal bool IsLogoDisappeared() => _headerLogo.Visibility.IsNotExist();
        internal bool IsSearchBoxDisappeared() => _searchBox.Visibility.IsNotExist();
        internal void DeleteMiddleHeader() => _middleHeader.JsActions.DeleteElement();
        internal string GetLogoText() => _logoText.GetText();
        internal void ScrollPageToFooter() => _footer.JsActions.ScrollToElement();
        internal void ScrollPageToHeader() => _header.JsActions.ScrollToElement();
        internal bool IsContactButtonDisplayed() => _contactUs.Visibility.IsDisplayed();
        internal void ClickEngLanguageButton() => _engLanguage.Click();
        internal bool IsHeaderLogoDisplayed() => _headerLogo.Visibility.IsDisplayed();
        internal void TypeTextToSearchTextBox(string text) => _searchTextBox.TypeText(text);
        internal void ClickSearchButton() => _searchButton.Click();
        internal void ClickAchivementsButton() => _achivementsButton.Click();
    }
}
