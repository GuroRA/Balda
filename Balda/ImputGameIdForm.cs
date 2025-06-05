using System.Resources;

namespace Balda
{
    /// <summary>
    /// Форма для ввода id игры
    /// </summary>
    public partial class ImputGameIdForm : Form
    {
        /// <summary>
        /// Id игры
        /// </summary>
        public Guid GameId { get; private set; }
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public ImputGameIdForm()
        {
            InitializeComponent();
            UpdateUIStrings();
        }
        private readonly LanguageManager _languageManager = new LanguageManager();

        private void UpdateUIStrings()
        {
            ResourceManager resourceManager = new ResourceManager("Balda.ImputGameIdForm", typeof(ImputGameIdForm).Assembly);
            this.Text = _languageManager.GetString("$this.Text", "Balda.ImputGameIdForm");
            idLable.Text = _languageManager.GetString("idLable.Text", "Balda.ImputGameIdForm");
            submitIdButton.Text = _languageManager.GetString("submitIdButton.Text", "Balda.ImputGameIdForm");
        }

        private void submitIdButton_Click(object sender, EventArgs e)
        {
            if (Guid.TryParse(gameIdTextBox.Text, out Guid gameId))
            {
                GameId = gameId;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(_languageManager.GetString("IncorrectIdFormatMessage", "Balda.Resources.MessageSources"));
                DialogResult = DialogResult.None;
            }
        }
    }
}
