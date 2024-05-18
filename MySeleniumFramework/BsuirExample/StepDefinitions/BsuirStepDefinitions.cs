using BsuirExample.PageObjects;
using MySeleniumFramework.Browser;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BsuirExample.StepDefinitions
{
    [Binding]
    public sealed class BsuirStepDefinitions
    {
        private BsuirMainPage _mainPage = new();
        private SciencePage _sciencePage = new();
        private const string LOGO_TEXT_KEY = nameof(LOGO_TEXT_KEY);

        private readonly ScenarioContext _scenarioContext;


        public BsuirStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"Открыта страница БГУИР")]
        public void GivenОткрытаСтраницаБГУИР()
        {
            BrowserFactory.GetDriver().Navigate().GoToUrl("https://www.bsuir.by/");
            new BrowserJsActions().StopPageLoading(TimeSpan.FromSeconds(4));
        }

        [Then(@"Отображается галерея основной страницы БГУИР")]
        public void ThenОтображаетсяГалереяОсновнойСтраницыБГУИР()
        {
            Assert.That(_mainPage.WaitForOpened(TimeSpan.FromMinutes(1)));
        }

        [When(@"Нажатие на кнопку ""([^""]*)"" из меню")]
        public void WhenНажатиеНаКнопку(string menuText)
        {
            _mainPage.ClickMenuButtonByText(menuText);
        }

        [Then(@"Отображается заголовок страницы Наука")]
        public void ThenОтображаетсяЗаголовокСтраницыНаука()
        {
            Assert.That(_sciencePage.WaitForOpened(TimeSpan.FromMinutes(1)));
        }

        [Given(@"Получен текст логотипа")]
        [When(@"Получить текст логотипа ещё раз")]
        public void WhenПолучитьТекстЛоготипа()
        {
            string logoText = _mainPage.GetLogoText();
            _scenarioContext.Add(LOGO_TEXT_KEY, logoText);
        }

        [When(@"Изменить язык страницы на английский")]
        public void WhenChangeLanguageToEng()
        {
            _mainPage.ClickEngLanguageButton();
        }

        [Then(@"Текст логотипа соотвествует ""([^""]*)""")]
        public void ThenTextLogoIs(string expectedText)
        {
            string actualText = _scenarioContext.Get<string>(LOGO_TEXT_KEY);
            _scenarioContext.Remove(LOGO_TEXT_KEY);
            Assert.That(actualText.ToLower(), Is.EqualTo(expectedText.ToLower()));
        }

        [Given(@"Прокрутить страницу БГУИР до футера")]
        public void ScrollToFooter()
        {
            _mainPage.ScrollPageToFooter();            
        }

        [When(@"Прокрутить страницу БГУИР до хедера")]
        public void ScrollToHeader()
        {
            _mainPage.ScrollPageToHeader();
        }

        [Then(@"Кнопка Связаться с нами отображается на экране")]
        public void ContactUsIsDisplayed()
        {
            Assert.That(_mainPage.IsContactButtonDisplayed());
            Thread.Sleep(2500);
        }

        [Then(@"Основной логотип БГУИР отображается на экране")]
        public void IsLogoDisplayed()
        {
            Assert.That(_mainPage.IsHeaderLogoDisplayed());
        }

        [When(@"Наведение мыши на соответсвущую опцию из меню")]
        public void HoverMouseToMenu()
        {
        }

        [Then(@"В выпадающем меню отображается соответсвующая опция")]
        public void OptionIsDisplayed(Table table)
        {
            foreach (var row in table.Rows)
            {
                string buttonName = row["Название кнопки"];
                string expectedOption = row["Опция меню"];
                _mainPage.HoverMouseToMenuButton(buttonName);
                Assert.That(_mainPage.IsOptionWithTextDisplayed(expectedOption));
                Thread.Sleep(1200);
            }
        }

        [When(@"Удаление среднего хедера страницы")]
        public void DeleteMiddleHeader()
        {
            _mainPage.DeleteMiddleHeader();
        }


        [Then(@"Главный логотип и строка поиска ичесзли со страницы")]
        public void LogoAndTextBoxDisappeared()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_mainPage.IsLogoDisappeared());
            });
        }

        [Given(@"Кликами пролистаны слайды на главной странице")]
        public void ClickSlides()
        {
            for (int i = 0; i < 8; i++)
            {
                _mainPage.ClickArrowRight();
                Thread.Sleep(300);
            }
        }
    }
}
