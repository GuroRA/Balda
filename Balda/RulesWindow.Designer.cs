namespace Balda
{
    partial class RulesWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesWindow));
            title = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.BackColor = Color.Transparent;
            title.Font = new Font("Berlin Sans FB", 36F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(37, 23, 23);
            title.ImeMode = ImeMode.NoControl;
            title.Location = new Point(290, 49);
            title.Name = "title";
            title.Size = new Size(281, 75);
            title.TabIndex = 9;
            title.Text = "Правила";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(37, 23, 23);
            label1.Location = new Point(26, 162);
            label1.Name = "label1";
            label1.Size = new Size(783, 203);
            label1.TabIndex = 10;
            label1.Text = resources.GetString("label1.Text");
            // 
            // RulesWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(836, 450);
            Controls.Add(label1);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "RulesWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Правила игры";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label title;
        private Label label1;
    }
}