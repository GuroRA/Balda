namespace Balda
{
    public partial class LobbyForm : Form
    {
        public LobbyForm()
        {
            InitializeComponent();
        }

        private void CreateGame_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm();
            gameForm.Show();
            this.Hide();
        }
    }
}
