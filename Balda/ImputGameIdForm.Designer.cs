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
            idLable = new Label();
            gameIdTextBox = new TextBox();
            submitIdButton = new Button();
            SuspendLayout();
            // 
            // idLable
            // 
            idLable.AutoSize = true;
            idLable.BackColor = Color.Transparent;
            idLable.Font = new Font("Berlin Sans FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            idLable.Location = new Point(105, 205);
            idLable.Name = "idLable";
            idLable.Size = new Size(242, 35);
            idLable.TabIndex = 0;
            idLable.Text = "Введите id игры";
            // 
            // gameIdTextBox
            // 
            gameIdTextBox.Location = new Point(363, 211);
            gameIdTextBox.Name = "gameIdTextBox";
            gameIdTextBox.Size = new Size(278, 27);
            gameIdTextBox.TabIndex = 1;
            // 
            // submitIdButton
            // 
            submitIdButton.BackColor = Color.White;
            submitIdButton.Location = new Point(289, 306);
            submitIdButton.Name = "submitIdButton";
            submitIdButton.Size = new Size(153, 40);
            submitIdButton.TabIndex = 2;
            submitIdButton.Text = "Подтвердить";
            submitIdButton.UseVisualStyleBackColor = false;
            submitIdButton.Click += submitIdButton_Click;
            // 
            // ImputGameIdForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(submitIdButton);
            Controls.Add(gameIdTextBox);
            Controls.Add(idLable);
            Name = "ImputGameIdForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Id комнаты";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLable;
        private TextBox gameIdTextBox;
        private Button submitIdButton;
    }
}