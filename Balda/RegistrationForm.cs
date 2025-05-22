using System.Text.RegularExpressions;

namespace Balda
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

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

                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Запись информации об исключении
                Console.WriteLine("Ошибка при сохранении пользователя:");
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Внутреннее исключение:");
                    Console.WriteLine(ex.InnerException.Message);
                    Console.WriteLine(ex.InnerException.StackTrace); // Это может быть очень полезно!
                }
                else
                {
                    Console.WriteLine("Внутреннего исключения нет.");
                }
                // Также можно использовать:
                MessageBox.Show("Ошибка при регистрации. Подробности записаны в консоль/файл."); // Сообщите пользователю об ошибке
                return; // Прекратите выполнение функции регистрации
            }
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            CheckFormValidation();
            CreateUserInDb();
        }
    }
}
