using NLog;

namespace Balda
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
                        Logger.Info($"Пользователь авторизовался");
                        var lobbyForm = new LobbyForm(userId);
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
                Logger.Info($"Ошибка при авторизации", ex.Message);
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
