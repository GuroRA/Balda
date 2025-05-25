using NLog;
using System.Text.RegularExpressions;

namespace Balda
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private void CheckFormValidation()
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text))
            {
                MessageBox.Show("Введите имя пользователя");
                loginTextBox.Focus();
                return;
            }
            else if (!Regex.IsMatch(loginTextBox.Text, @"^[a-zA-Zа-яА-Я0-9_]{4,}$"))
            {
                MessageBox.Show("Пароль может быть минимум 4 символов и не содержать спец символов");
                loginTextBox.Focus();
                return;
            }
            if (paswordTextBox.TextLength < 10)
            {
                MessageBox.Show("Пароль должен содержать минимум 10 символов");
                paswordTextBox.Focus();
                return;
            }
            if (paswordTextBox.Text != repeatPaswordTextBox.Text)
            {
                MessageBox.Show("Пароли не соответствуют");
                repeatPaswordTextBox.Focus();
                return;
            }
        }

        private void CreateUserInDb()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    Logger.Info("Начало регистрации");

                    if (db.Users.Any(u => u.Name == loginTextBox.Text))
                    {
                        MessageBox.Show("Этот логин уже занят");
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
                    Logger.Info("Пользователь зарегестрировался");
                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Info("не удалось сохранить пользователя");
                Console.WriteLine($"Ошибка при сохранении пользователя: {ex.Message}");
                return;
            }
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            CheckFormValidation();
            CreateUserInDb();
        }
    }
}
