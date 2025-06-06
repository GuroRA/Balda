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
            resources.ApplyResources(title, "title");
            title.BackColor = Color.Transparent;
            title.ForeColor = Color.FromArgb(37, 23, 23);
            title.Name = "title";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.FromArgb(37, 23, 23);
            label1.Name = "label1";
            // 
            // RulesWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            Controls.Add(label1);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "RulesWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label title;
        private Label label1;
    }
}