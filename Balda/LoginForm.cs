namespace Balda
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void RegistrtionButton_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm();
            this.Hide();
            registrationForm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text.Trim();
            var password = paswordTextBox.Text;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Name == login);

                    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        var userId = user.Id;
                        var lobbyForm = new LobbyForm();
                        lobbyForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("неверный логин или пароль");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
