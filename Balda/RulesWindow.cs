using System.Resources;

namespace Balda
{
    /// <summary>
    /// Форма с правилами игры
    /// </summary>
    public partial class RulesWindow : Form
    {
        /// <summary>
        /// Конструктор класса инициализирующий элементы формы
        /// </summary>
        public RulesWindow()
        {
            InitializeComponent();
            UpdateUIStrings();
        }

        private readonly LanguageManager _languageManager = new LanguageManager();
        private void UpdateUIStrings()
        {
            ResourceManager resourceManager = new ResourceManager("Balda.RulesWindow", typeof(RulesWindow).Assembly);
            this.Text = _languageManager.GetString("$this.Text", "Balda.RulesWindow");
            title.Text = _languageManager.GetString("title.Text", "Balda.RulesWindow");
            label1.Text = _languageManager.GetString("label1.Text", "Balda.RulesWindow");
        }
    }
}
