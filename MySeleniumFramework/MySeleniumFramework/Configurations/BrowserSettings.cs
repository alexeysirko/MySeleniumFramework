namespace MySeleniumFramework.Configurations
{
    internal class BrowserSettings
    {
        private IReadOnlyDictionary<string, object> _browserSettings;      

        internal BrowserSettings()
        {
            _browserSettings = new BrowserSettingsReader().BrowserSettings;
        }

        public string BrowserName => _browserSettings["browserName"].ToString();
    }
}
