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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LobbyForm));
            CreateGame = new Button();
            ConnectButton = new Button();
            rulesButton = new Button();
            SuspendLayout();
            // 
            // CreateGame
            // 
            CreateGame.BackColor = Color.White;
            CreateGame.Cursor = Cursors.Hand;
            resources.ApplyResources(CreateGame, "CreateGame");
            CreateGame.Name = "CreateGame";
            CreateGame.UseVisualStyleBackColor = false;
            CreateGame.Click += CreateGame_Click;
            // 
            // ConnectButton
            // 
            ConnectButton.BackColor = Color.White;
            ConnectButton.Cursor = Cursors.Hand;
            resources.ApplyResources(ConnectButton, "ConnectButton");
            ConnectButton.Name = "ConnectButton";
            ConnectButton.UseVisualStyleBackColor = false;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // rulesButton
            // 
            rulesButton.BackColor = Color.White;
            rulesButton.Cursor = Cursors.Hand;
            resources.ApplyResources(rulesButton, "rulesButton");
            rulesButton.Name = "rulesButton";
            rulesButton.UseVisualStyleBackColor = false;
            rulesButton.Click += rulesButton_Click;
            // 
            // LobbyForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            Controls.Add(rulesButton);
            Controls.Add(ConnectButton);
            Controls.Add(CreateGame);
            MaximizeBox = false;
            Name = "LobbyForm";
            ResumeLayout(false);
        }

        #endregion

        private Button CreateGame;
        private Button ConnectButton;
        private Button rulesButton;
    }
}