using System.Text.Json;

namespace MySeleniumFramework.Configurations
{
    internal class BrowserSettingsReader
    {
        private IReadOnlyDictionary<string, object> _browserSettings;
        internal IReadOnlyDictionary<string, object> BrowserSettings => _browserSettings ??= ReadSettingsFile();
        private string browserSettingsPath;


        public BrowserSettingsReader()
        {
            string defaultSettingsPath = Path.GetFullPath(@"Resources/BrowserSettings.json");
            browserSettingsPath = defaultSettingsPath;
        }


        private IReadOnlyDictionary<string, object> ReadSettingsFile()
        {
            string settingsJson = File.ReadAllText(browserSettingsPath);
            _browserSettings = JsonSerializer.Deserialize<Dictionary<string, object>>(settingsJson);
            return _browserSettings;
        }
    }
}
