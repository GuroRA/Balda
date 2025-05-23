namespace Balda
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RegistrtionButton = new Button();
            label1 = new Label();
            loginButton = new Button();
            paswordTextBox = new MaskedTextBox();
            loginTextBox = new TextBox();
            PaswordText = new Label();
            loginText = new Label();
            title = new Label();
            SuspendLayout();
            // 
            // RegistrtionButton
            // 
            RegistrtionButton.AutoSize = true;
            RegistrtionButton.BackColor = Color.White;
            RegistrtionButton.FlatStyle = FlatStyle.Flat;
            RegistrtionButton.Font = new Font("Berlin Sans FB", 13.8F);
            RegistrtionButton.ImeMode = ImeMode.NoControl;
            RegistrtionButton.Location = new Point(444, 335);
            RegistrtionButton.Name = "RegistrtionButton";
            RegistrtionButton.Size = new Size(200, 38);
            RegistrtionButton.TabIndex = 15;
            RegistrtionButton.Text = "Регистрация";
            RegistrtionButton.UseVisualStyleBackColor = false;
            RegistrtionButton.Click += RegistrtionButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Berlin Sans FB Demi", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(37, 23, 23);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(157, 328);
            label1.Name = "label1";
            label1.Size = new Size(281, 45);
            label1.TabIndex = 14;
            label1.Text = "Нет аккаунта?";
            // 
            // loginButton
            // 
            loginButton.AutoSize = true;
            loginButton.BackColor = Color.White;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Berlin Sans FB", 13.8F);
            loginButton.ImeMode = ImeMode.NoControl;
            loginButton.Location = new Point(321, 269);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(200, 38);
            loginButton.TabIndex = 13;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // paswordTextBox
            // 
            paswordTextBox.Font = new Font("Berlin Sans FB", 12F);
            paswordTextBox.Location = new Point(391, 198);
            paswordTextBox.Name = "paswordTextBox";
            paswordTextBox.PasswordChar = '*';
            paswordTextBox.Size = new Size(251, 29);
            paswordTextBox.TabIndex = 12;
            // 
            // loginTextBox
            // 
            loginTextBox.Font = new Font("Berlin Sans FB", 12F);
            loginTextBox.Location = new Point(391, 145);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(251, 29);
            loginTextBox.TabIndex = 11;
            // 
            // PaswordText
            // 
            PaswordText.AutoSize = true;
            PaswordText.BackColor = Color.Transparent;
            PaswordText.Font = new Font("Berlin Sans FB Demi", 24F, FontStyle.Bold);
            PaswordText.ForeColor = Color.FromArgb(37, 23, 23);
            PaswordText.ImeMode = ImeMode.NoControl;
            PaswordText.Location = new Point(211, 193);
            PaswordText.Name = "PaswordText";
            PaswordText.Size = new Size(158, 45);
            PaswordText.TabIndex = 10;
            PaswordText.Text = "Пароль";
            // 
            // loginText
            // 
            loginText.AutoSize = true;
            loginText.BackColor = Color.Transparent;
            loginText.Font = new Font("Berlin Sans FB Demi", 24F, FontStyle.Bold);
            loginText.ForeColor = Color.FromArgb(37, 23, 23);
            loginText.ImeMode = ImeMode.NoControl;
            loginText.Location = new Point(239, 135);
            loginText.Name = "loginText";
            loginText.Size = new Size(130, 45);
            loginText.TabIndex = 9;
            loginText.Text = "Логин";
            // 
            // title
            // 
            title.AutoSize = true;
            title.BackColor = Color.Transparent;
            title.Font = new Font("Berlin Sans FB", 36F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(37, 23, 23);
            title.ImeMode = ImeMode.NoControl;
            title.Location = new Point(321, 18);
            title.Name = "title";
            title.Size = new Size(174, 75);
            title.TabIndex = 8;
            title.Text = "Вход";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(RegistrtionButton);
            Controls.Add(label1);
            Controls.Add(loginButton);
            Controls.Add(paswordTextBox);
            Controls.Add(loginTextBox);
            Controls.Add(PaswordText);
            Controls.Add(loginText);
            Controls.Add(title);
            Name = "LoginForm";
            Text = "Вход";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RegistrtionButton;
        private Label label1;
        private Button loginButton;
        private MaskedTextBox paswordTextBox;
        private TextBox loginTextBox;
        private Label PaswordText;
        private Label loginText;
        private Label title;
    }
}