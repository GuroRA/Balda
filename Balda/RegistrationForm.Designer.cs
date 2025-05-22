namespace Balda
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            registrationButton = new Button();
            paswordTextBox = new MaskedTextBox();
            loginTextBox = new TextBox();
            PaswordRegistrationText = new Label();
            loginRegistrationText = new Label();
            titleRegistration = new Label();
            repeatPaswordTextBox = new MaskedTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // registrationButton
            // 
            resources.ApplyResources(registrationButton, "registrationButton");
            registrationButton.BackColor = Color.White;
            registrationButton.Name = "registrationButton";
            registrationButton.UseVisualStyleBackColor = false;
            registrationButton.Click += registrationButton_Click;
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
            // PaswordRegistrationText
            // 
            resources.ApplyResources(PaswordRegistrationText, "PaswordRegistrationText");
            PaswordRegistrationText.BackColor = Color.Transparent;
            PaswordRegistrationText.ForeColor = Color.FromArgb(37, 23, 23);
            PaswordRegistrationText.Name = "PaswordRegistrationText";
            // 
            // loginRegistrationText
            // 
            resources.ApplyResources(loginRegistrationText, "loginRegistrationText");
            loginRegistrationText.BackColor = Color.Transparent;
            loginRegistrationText.ForeColor = Color.FromArgb(37, 23, 23);
            loginRegistrationText.Name = "loginRegistrationText";
            // 
            // titleRegistration
            // 
            resources.ApplyResources(titleRegistration, "titleRegistration");
            titleRegistration.BackColor = Color.Transparent;
            titleRegistration.ForeColor = Color.FromArgb(37, 23, 23);
            titleRegistration.Name = "titleRegistration";
            // 
            // repeatPaswordTextBox
            // 
            resources.ApplyResources(repeatPaswordTextBox, "repeatPaswordTextBox");
            repeatPaswordTextBox.Name = "repeatPaswordTextBox";
            repeatPaswordTextBox.PasswordChar = '*';
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.FromArgb(37, 23, 23);
            label1.Name = "label1";
            // 
            // RegistrationForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            Controls.Add(repeatPaswordTextBox);
            Controls.Add(label1);
            Controls.Add(titleRegistration);
            Controls.Add(registrationButton);
            Controls.Add(paswordTextBox);
            Controls.Add(loginTextBox);
            Controls.Add(PaswordRegistrationText);
            Controls.Add(loginRegistrationText);
            Name = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button registrationButton;
        private MaskedTextBox paswordTextBox;
        private TextBox loginTextBox;
        private Label PaswordRegistrationText;
        private Label loginRegistrationText;
        private Label titleRegistration;
        private MaskedTextBox repeatPaswordTextBox;
        private Label label1;
    }
}