namespace Balda
{
    partial class ImputGameIdForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImputGameIdForm));
            idLable = new Label();
            gameIdTextBox = new TextBox();
            submitIdButton = new Button();
            SuspendLayout();
            // 
            // idLable
            // 
            resources.ApplyResources(idLable, "idLable");
            idLable.BackColor = Color.Transparent;
            idLable.Name = "idLable";
            // 
            // gameIdTextBox
            // 
            resources.ApplyResources(gameIdTextBox, "gameIdTextBox");
            gameIdTextBox.Name = "gameIdTextBox";
            // 
            // submitIdButton
            // 
            resources.ApplyResources(submitIdButton, "submitIdButton");
            submitIdButton.BackColor = Color.White;
            submitIdButton.Name = "submitIdButton";
            submitIdButton.UseVisualStyleBackColor = false;
            submitIdButton.Click += submitIdButton_Click;
            // 
            // ImputGameIdForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            Controls.Add(submitIdButton);
            Controls.Add(gameIdTextBox);
            Controls.Add(idLable);
            Name = "ImputGameIdForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLable;
        private TextBox gameIdTextBox;
        private Button submitIdButton;
    }
}