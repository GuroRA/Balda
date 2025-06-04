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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            GameField.AllowUserToAddRows = false;
            GameField.AllowUserToDeleteRows = false;
            GameField.AllowUserToResizeColumns = false;
            GameField.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Berlin Sans FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GameField.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            GameField.BackgroundColor = Color.White;
            GameField.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GameField.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            GameField.Location = new Point(263, 122);
            GameField.MultiSelect = false;
            GameField.Name = "GameField";
            GameField.RowHeadersWidth = 51;
            GameField.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            GameField.RowsDefaultCellStyle = dataGridViewCellStyle2;
            GameField.ScrollBars = ScrollBars.None;
            GameField.Size = new Size(307, 312);
            GameField.TabIndex = 0;
            GameField.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column1.FlatStyle = FlatStyle.Flat;
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.False;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column2.FlatStyle = FlatStyle.Flat;
            Column2.HeaderText = "";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Resizable = DataGridViewTriState.False;
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column3.FlatStyle = FlatStyle.Flat;
            Column3.HeaderText = "";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Resizable = DataGridViewTriState.False;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column4.FlatStyle = FlatStyle.Flat;
            Column4.HeaderText = "";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Resizable = DataGridViewTriState.False;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column5.FlatStyle = FlatStyle.Flat;
            Column5.HeaderText = "";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Resizable = DataGridViewTriState.False;
            Column5.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Berlin Sans FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(76, 21);
            label1.Name = "label1";
            label1.Size = new Size(110, 35);
            label1.TabIndex = 1;
            label1.Text = "Игрок1";
            // 
            // leftPlayerLabelName
            // 
            leftPlayerLabelName.AutoSize = true;
            leftPlayerLabelName.BackColor = Color.Transparent;
            leftPlayerLabelName.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leftPlayerLabelName.Location = new Point(76, 69);
            leftPlayerLabelName.Name = "leftPlayerLabelName";
            leftPlayerLabelName.Size = new Size(91, 29);
            leftPlayerLabelName.TabIndex = 2;
            leftPlayerLabelName.Text = "Руслан";
            // 
            // leftPlayerLabelScore
            // 
            leftPlayerLabelScore.AutoSize = true;
            leftPlayerLabelScore.BackColor = Color.Transparent;
            leftPlayerLabelScore.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leftPlayerLabelScore.Location = new Point(76, 98);
            leftPlayerLabelScore.Name = "leftPlayerLabelScore";
            leftPlayerLabelScore.Size = new Size(103, 29);
            leftPlayerLabelScore.TabIndex = 3;
            leftPlayerLabelScore.Text = "Счёт: 25";
            // 
            // rightPlayerLabelScore
            // 
            rightPlayerLabelScore.AutoSize = true;
            rightPlayerLabelScore.BackColor = Color.Transparent;
            rightPlayerLabelScore.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rightPlayerLabelScore.Location = new Point(618, 98);
            rightPlayerLabelScore.Name = "rightPlayerLabelScore";
            rightPlayerLabelScore.Size = new Size(102, 29);
            rightPlayerLabelScore.TabIndex = 6;
            rightPlayerLabelScore.Text = "Счёт: 35";
            rightPlayerLabelScore.Click += label4_Click;
            // 
            // rightPlayerLableName
            // 
            rightPlayerLableName.AutoSize = true;
            rightPlayerLableName.BackColor = Color.Transparent;
            rightPlayerLableName.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rightPlayerLableName.Location = new Point(618, 69);
            rightPlayerLableName.Name = "rightPlayerLableName";
            rightPlayerLableName.Size = new Size(96, 29);
            rightPlayerLableName.TabIndex = 5;
            rightPlayerLableName.Text = "Анжела";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Berlin Sans FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(618, 21);
            label6.Name = "label6";
            label6.Size = new Size(114, 35);
            label6.TabIndex = 4;
            label6.Text = "Игрок2";
            // 
            // wordTextBox
            // 
            wordTextBox.BackColor = Color.FromArgb(128, 64, 64);
            wordTextBox.BorderStyle = BorderStyle.None;
            wordTextBox.Location = new Point(319, 74);
            wordTextBox.Name = "wordTextBox";
            wordTextBox.Size = new Size(208, 20);
            wordTextBox.TabIndex = 7;
            // 
            // skipButton
            // 
            skipButton.BackColor = Color.White;
            skipButton.BackgroundImageLayout = ImageLayout.None;
            skipButton.FlatStyle = FlatStyle.Flat;
            skipButton.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            skipButton.ForeColor = Color.Black;
            skipButton.Location = new Point(600, 398);
            skipButton.Name = "skipButton";
            skipButton.Size = new Size(132, 36);
            skipButton.TabIndex = 8;
            skipButton.Text = "Пропуск хода";
            skipButton.UseVisualStyleBackColor = false;
            skipButton.Click += skipButton_Click;
            // 
            // acceptButton
            // 
            acceptButton.BackColor = Color.White;
            acceptButton.BackgroundImageLayout = ImageLayout.None;
            acceptButton.FlatStyle = FlatStyle.Flat;
            acceptButton.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            acceptButton.ForeColor = Color.Black;
            acceptButton.Location = new Point(600, 340);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(132, 36);
            acceptButton.TabIndex = 9;
            acceptButton.Text = "Подтвердить ";
            acceptButton.UseVisualStyleBackColor = false;
            acceptButton.Click += acceptButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(99, 398);
            button1.Name = "button1";
            button1.Size = new Size(132, 36);
            button1.TabIndex = 10;
            button1.Text = "Очистить ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
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
            Text = "Балда";
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