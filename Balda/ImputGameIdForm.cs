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
                MessageBox.Show("Неверный формат ID игры.");
                DialogResult = DialogResult.None;
            }
        }
    }
}
