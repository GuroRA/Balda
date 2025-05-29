namespace Balda
{
    public partial class ImputGameIdForm : Form
    {
        public Guid GameId { get; private set; }
        public ImputGameIdForm()
        {
            InitializeComponent();
        }

        private void ImputGameIdForm_Load(object sender, EventArgs e)
        {

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
