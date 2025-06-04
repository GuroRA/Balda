namespace Balda
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            GameField = new DataGridView();
            Column1 = new DataGridViewButtonColumn();
            Column2 = new DataGridViewButtonColumn();
            Column3 = new DataGridViewButtonColumn();
            Column4 = new DataGridViewButtonColumn();
            Column5 = new DataGridViewButtonColumn();
            label1 = new Label();
            leftPlayerLabelName = new Label();
            leftPlayerLabelScore = new Label();
            rightPlayerLabelScore = new Label();
            rightPlayerLableName = new Label();
            label6 = new Label();
            wordTextBox = new TextBox();
            skipButton = new Button();
            acceptButton = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)GameField).BeginInit();
            SuspendLayout();
            // 
            // GameField
            // 
            resources.ApplyResources(GameField, "GameField");
            GameField.AllowUserToAddRows = false;
            GameField.AllowUserToDeleteRows = false;
            GameField.AllowUserToResizeColumns = false;
            GameField.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Berlin Sans FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GameField.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            GameField.BackgroundColor = Color.White;
            GameField.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GameField.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            GameField.MultiSelect = false;
            GameField.Name = "GameField";
            GameField.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            GameField.RowsDefaultCellStyle = dataGridViewCellStyle4;
            GameField.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column1.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(Column1, "Column1");
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.False;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column2.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(Column2, "Column2");
            Column2.Name = "Column2";
            Column2.Resizable = DataGridViewTriState.False;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column3.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(Column3, "Column3");
            Column3.Name = "Column3";
            Column3.Resizable = DataGridViewTriState.False;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column4.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(Column4, "Column4");
            Column4.Name = "Column4";
            Column4.Resizable = DataGridViewTriState.False;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column5.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(Column5, "Column5");
            Column5.Name = "Column5";
            Column5.Resizable = DataGridViewTriState.False;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.Name = "label1";
            // 
            // leftPlayerLabelName
            // 
            resources.ApplyResources(leftPlayerLabelName, "leftPlayerLabelName");
            leftPlayerLabelName.BackColor = Color.Transparent;
            leftPlayerLabelName.Name = "leftPlayerLabelName";
            // 
            // leftPlayerLabelScore
            // 
            resources.ApplyResources(leftPlayerLabelScore, "leftPlayerLabelScore");
            leftPlayerLabelScore.BackColor = Color.Transparent;
            leftPlayerLabelScore.Name = "leftPlayerLabelScore";
            // 
            // rightPlayerLabelScore
            // 
            resources.ApplyResources(rightPlayerLabelScore, "rightPlayerLabelScore");
            rightPlayerLabelScore.BackColor = Color.Transparent;
            rightPlayerLabelScore.Name = "rightPlayerLabelScore";
            rightPlayerLabelScore.Click += label4_Click;
            // 
            // rightPlayerLableName
            // 
            resources.ApplyResources(rightPlayerLableName, "rightPlayerLableName");
            rightPlayerLableName.BackColor = Color.Transparent;
            rightPlayerLableName.Name = "rightPlayerLableName";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.BackColor = Color.Transparent;
            label6.Name = "label6";
            // 
            // wordTextBox
            // 
            resources.ApplyResources(wordTextBox, "wordTextBox");
            wordTextBox.BackColor = Color.FromArgb(128, 64, 64);
            wordTextBox.BorderStyle = BorderStyle.None;
            wordTextBox.Name = "wordTextBox";
            // 
            // skipButton
            // 
            resources.ApplyResources(skipButton, "skipButton");
            skipButton.BackColor = Color.White;
            skipButton.ForeColor = Color.Black;
            skipButton.Name = "skipButton";
            skipButton.UseVisualStyleBackColor = false;
            skipButton.Click += skipButton_Click;
            // 
            // acceptButton
            // 
            resources.ApplyResources(acceptButton, "acceptButton");
            acceptButton.BackColor = Color.White;
            acceptButton.ForeColor = Color.Black;
            acceptButton.Name = "acceptButton";
            acceptButton.UseVisualStyleBackColor = false;
            acceptButton.Click += acceptButton_Click;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // GameForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            Controls.Add(button1);
            Controls.Add(acceptButton);
            Controls.Add(skipButton);
            Controls.Add(wordTextBox);
            Controls.Add(rightPlayerLabelScore);
            Controls.Add(rightPlayerLableName);
            Controls.Add(label6);
            Controls.Add(leftPlayerLabelScore);
            Controls.Add(leftPlayerLabelName);
            Controls.Add(label1);
            Controls.Add(GameField);
            Name = "GameForm";
            ((System.ComponentModel.ISupportInitialize)GameField).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView GameField;
        private Label label1;
        private Label leftPlayerLabelName;
        private Label leftPlayerLabelScore;
        private Label rightPlayerLabelScore;
        private Label rightPlayerLableName;
        private Label label6;
        private TextBox wordTextBox;
        private Button skipButton;
        private DataGridViewButtonColumn Column1;
        private DataGridViewButtonColumn Column2;
        private DataGridViewButtonColumn Column3;
        private DataGridViewButtonColumn Column4;
        private DataGridViewButtonColumn Column5;
        private Button acceptButton;
        private Button button1;
    }
}