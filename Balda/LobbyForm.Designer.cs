namespace Balda
{
    partial class LobbyForm
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
            CreateGame = new Button();
            ConnectButton = new Button();
            rulesButton = new Button();
            SuspendLayout();
            // 
            // CreateGame
            // 
            CreateGame.BackColor = Color.White;
            CreateGame.Cursor = Cursors.Hand;
            CreateGame.FlatStyle = FlatStyle.Flat;
            CreateGame.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateGame.Location = new Point(266, 87);
            CreateGame.Name = "CreateGame";
            CreateGame.Size = new Size(276, 53);
            CreateGame.TabIndex = 0;
            CreateGame.Text = "Создать";
            CreateGame.UseVisualStyleBackColor = false;
            CreateGame.Click += CreateGame_Click;
            // 
            // ConnectButton
            // 
            ConnectButton.BackColor = Color.White;
            ConnectButton.Cursor = Cursors.Hand;
            ConnectButton.FlatStyle = FlatStyle.Flat;
            ConnectButton.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConnectButton.Location = new Point(266, 179);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(276, 53);
            ConnectButton.TabIndex = 1;
            ConnectButton.Text = "Подключиться";
            ConnectButton.UseVisualStyleBackColor = false;
            // 
            // rulesButton
            // 
            rulesButton.BackColor = Color.White;
            rulesButton.Cursor = Cursors.Hand;
            rulesButton.FlatStyle = FlatStyle.Flat;
            rulesButton.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rulesButton.Location = new Point(266, 271);
            rulesButton.Name = "rulesButton";
            rulesButton.Size = new Size(276, 53);
            rulesButton.TabIndex = 2;
            rulesButton.Text = "Правила";
            rulesButton.UseVisualStyleBackColor = false;
            // 
            // LobbyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(rulesButton);
            Controls.Add(ConnectButton);
            Controls.Add(CreateGame);
            Name = "LobbyForm";
            Text = "Лобби";
            ResumeLayout(false);
        }

        #endregion

        private Button CreateGame;
        private Button ConnectButton;
        private Button rulesButton;
    }
}