using BsuirExample.PageObjects;
using MySeleniumFramework.Browser;
using NUnit.Framework;

namespace BsuirExample.StepDefinitions
{
    [Binding]
    public sealed class BsuirStepDefinitions
    {
        private BsuirMainPage _mainPage = new();
        private SciencePage _sciencePage = new();

        [Given(@"Открыта страница БГУИР")]
        public void GivenОткрытаСтраницаБГУИР()
        {
            BrowserFactory.GetDriver().Navigate().GoToUrl("https://www.bsuir.by/");
            new BrowserJsActions().StopPageLoading(TimeSpan.FromSeconds(10));
        }

        [Then(@"Отображается галерея основной страницы БГУИР")]
        public void ThenОтображаетсяГалереяОсновнойСтраницыБГУИР()
        {
            Assert.That(_mainPage.WaitForOpened(TimeSpan.FromMinutes(1)));
        }

        [When(@"Нажатие на кнопку ""([^""]*)""")]
        public void WhenНажатиеНаКнопку(string menuText)
        {
            _mainPage.ClickMenuButtonByText(menuText);
        }

        [Then(@"Отображается заголовок страницы Наука")]
        public void ThenОтображаетсяЗаголовокСтраницыНаука()
        {
            Assert.That(_sciencePage.WaitForOpened(TimeSpan.FromMinutes(1)));
        }

    }
}
