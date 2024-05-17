using MySeleniumFramework.Browser;

namespace BsuirExample.Hooks
{
    [Binding]
    internal class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            BrowserFactory.GetDriver().Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(3000);
            BrowserFactory.QuitBrowser();
        }
    }
}
