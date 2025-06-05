using NLog;
using System.Resources;
using System.Text.RegularExpressions;

namespace Balda
{
    /// <summary>
    /// Форма регистрации
    /// </summary>
    public partial class RegistrationForm : Form
    {
        /// <summary>
        /// Конструктор формы инициализирующий её
        /// </summary>
        public RegistrationForm()
        {
            InitializeComponent();
            UpdateUIStrings();
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly LanguageManager _languageManager = new LanguageManager();

        private void UpdateUIStrings()
        {
            ResourceManager resourceManager = new ResourceManager("Balda.RegistrationForm", typeof(RegistrationForm).Assembly);
            this.Text = _languageManager.GetString("$this.Text", "Balda.RegistrationForm");
            titleRegistration.Text = _languageManager.GetString("titleRegistration.Text", "Balda.RegistrationForm");
            loginRegistrationText.Text = _languageManager.GetString("loginRegistrationText.Text", "Balda.RegistrationForm");
            PaswordRegistrationText.Text = _languageManager.GetString("PaswordRegistrationText.Text", "Balda.RegistrationForm");
            label1.Text = _languageManager.GetString("label1.Text", "Balda.RegistrationForm");
            registrationButton.Text = _languageManager.GetString("registrationButton.Text", "Balda.RegistrationForm");
        }


        private bool CheckFormValidation()
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text))
            {
                MessageBox.Show(_languageManager.GetString("EnterUsernameMessage", "Balda.Resources.MessageSources"));
                loginTextBox.Focus();
                return false;
            }
            else if (!Regex.IsMatch(loginTextBox.Text, @"^[a-zA-Zа-яА-Я0-9_]{4,}$"))
            {
                MessageBox.Show(_languageManager.GetString("IncorrectLogginMessage", "Balda.Resources.MessageSources"));
                loginTextBox.Focus();
                return false;
            }
            if (paswordTextBox.TextLength < 10)
            {
                MessageBox.Show(_languageManager.GetString("IncorrectPasswordMessage", "Balda.Resources.MessageSources"));
                paswordTextBox.Focus();
                return false;
            }
            if (paswordTextBox.Text != repeatPaswordTextBox.Text)
            {
                MessageBox.Show(_languageManager.GetString("PasswordsNotEqualMessage", "Balda.Resources.MessageSources"));
                repeatPaswordTextBox.Focus();
                return false;
            }
            return true;
        }

        private void CreateUserInDb()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    Logger.Info("Начало регистрации");
                    if (!CheckFormValidation())
                    {
                        return;
                    }

                    if (db.Users.Any(u => u.Name == loginTextBox.Text))
                    {
                        MessageBox.Show(_languageManager.GetString("LogginInUseMessage", "Balda.Resources.MessageSources"));
                        return;
                    }

                    var newUser = new UserEntity
                    {
                        Name = loginTextBox.Text,
                        Password = BCrypt.Net.BCrypt.HashPassword(paswordTextBox.Text),
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    MessageBox.Show("Вы успешно зарегистрировались!");
                    Logger.Info(_languageManager.GetString("RegistrationSuccsessMessage", "Balda.Resources.MessageSources"));
                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Info("не удалось сохранить пользователя");
                Console.WriteLine($"{_languageManager.GetString("ErrorMessagePrefix", "Balda.Resources.MessageSources")}: {ex.Message}");
                return;
            }
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            CreateUserInDb();
        }
    }
}
