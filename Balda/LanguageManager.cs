using System.Globalization;

namespace Balda
{
    public class LanguageManager
    {
        private CultureInfo _currentCulture = string.IsNullOrEmpty(Properties.Settings1.Default.SelectedLanguage) ? CultureInfo.InvariantCulture : new CultureInfo(Properties.Settings1.Default.SelectedLanguage);
        public CultureInfo CurrentCulture
        {
            get { return _currentCulture; }
            set
            {
                _currentCulture = value;
                Properties.Settings1.Default.SelectedLanguage = _currentCulture.Name;
                Properties.Settings1.Default.Save();
            }
        }

        public string GetString(string key, string baseName)
        {
            try
            {
                var resourceManager = new System.Resources.ResourceManager(baseName, typeof(LoginForm).Assembly);
                return resourceManager.GetString(key, _currentCulture) ?? key;
            }
            catch (System.Resources.MissingManifestResourceException)
            {
                return key;
            }
        }

        public void ToggleLanguage()
        {
            if (_currentCulture.Name == "en")
            {
                CurrentCulture = CultureInfo.InvariantCulture;
            }
            else
            {
                CurrentCulture = new CultureInfo("en");
            }
        }
    }
}
