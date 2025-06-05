using NLog;
using System.Globalization;
using System.Resources;

namespace Balda
{
    /// <summary>
    /// Форма логина также начальная точка
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Конструктор формы инициализирующий форму
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            UpdateUIStrings();
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly LanguageManager _languageManager = new LanguageManager();

        private void UpdateUIStrings()
        {
            ResourceManager resourceManager = new ResourceManager("Balda.LoginForm", typeof(LoginForm).Assembly);
            this.Text = _languageManager.GetString("$this.Text", "Balda.LoginForm");
            title.Text = _languageManager.GetString("title.Text", "Balda.LoginForm");
            loginText.Text = _languageManager.GetString("loginText.Text", "Balda.LoginForm");
            PaswordText.Text = _languageManager.GetString("PaswordText.Text", "Balda.LoginForm");
            loginButton.Text = _languageManager.GetString("loginButton.Text", "Balda.LoginForm");
            RegistrtionButton.Text = _languageManager.GetString("RegistrtionButton.Text", "Balda.LoginForm");
            NoAccText.Text = _languageManager.GetString("NoAccText.Text", "Balda.LoginForm");
            ChangeLanguageButton.Text = _languageManager.GetString("ChangeLanguageButton.Text", "Balda.LoginForm");
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
                MessageBox.Show(_languageManager.GetString("LoginRequiredMessage", "Balda.Resources.MessageSources"));
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show(_languageManager.GetString("PasswordRequiredMessage", "Balda.Resources.MessageSources"));
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
                        MessageBox.Show(_languageManager.GetString("InvalidLoginPasswordMessage", "Balda.Resources.MessageSources"));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Info($"Ошибка при авторизации", ex.Message);
                MessageBox.Show($"{_languageManager.GetString("ErrorMessagePrefix", "Balda.Resources.MessageSources")}: {ex.Message}");
            }
        }

        private void ChangeLanguageButton_Click(object sender, EventArgs e)
        {
            _languageManager.ToggleLanguage();
            UpdateUIStrings();
            Properties.Settings1.Default.SelectedLanguage = _languageManager.CurrentCulture.Name;
            Properties.Settings1.Default.Save();
        }

    }
}
