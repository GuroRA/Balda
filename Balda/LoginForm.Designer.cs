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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            RegistrtionButton = new Button();
            label1 = new Label();
            loginButton = new Button();
            paswordTextBox = new MaskedTextBox();
            loginTextBox = new TextBox();
            PaswordText = new Label();
            loginText = new Label();
            title = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // RegistrtionButton
            // 
            resources.ApplyResources(RegistrtionButton, "RegistrtionButton");
            RegistrtionButton.BackColor = Color.White;
            RegistrtionButton.Name = "RegistrtionButton";
            RegistrtionButton.UseVisualStyleBackColor = false;
            RegistrtionButton.Click += RegistrtionButton_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.FromArgb(37, 23, 23);
            label1.Name = "label1";
            // 
            // loginButton
            // 
            resources.ApplyResources(loginButton, "loginButton");
            loginButton.BackColor = Color.White;
            loginButton.Name = "loginButton";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // paswordTextBox
            // 
            resources.ApplyResources(paswordTextBox, "paswordTextBox");
            paswordTextBox.Name = "paswordTextBox";
            paswordTextBox.PasswordChar = '*';
            // 
            // loginTextBox
            // 
            resources.ApplyResources(loginTextBox, "loginTextBox");
            loginTextBox.Name = "loginTextBox";
            // 
            // PaswordText
            // 
            resources.ApplyResources(PaswordText, "PaswordText");
            PaswordText.BackColor = Color.Transparent;
            PaswordText.ForeColor = Color.FromArgb(37, 23, 23);
            PaswordText.Name = "PaswordText";
            // 
            // loginText
            // 
            resources.ApplyResources(loginText, "loginText");
            loginText.BackColor = Color.Transparent;
            loginText.ForeColor = Color.FromArgb(37, 23, 23);
            loginText.Name = "loginText";
            // 
            // title
            // 
            resources.ApplyResources(title, "title");
            title.BackColor = Color.Transparent;
            title.ForeColor = Color.FromArgb(37, 23, 23);
            title.Name = "title";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.Transparent;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            Controls.Add(button1);
            Controls.Add(RegistrtionButton);
            Controls.Add(label1);
            Controls.Add(loginButton);
            Controls.Add(paswordTextBox);
            Controls.Add(loginTextBox);
            Controls.Add(PaswordText);
            Controls.Add(loginText);
            Controls.Add(title);
            Name = "LoginForm";
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
        private Button button1;
    }
}