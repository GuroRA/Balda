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
            Column5 = new DataGridViewButtonColumn();
            Column4 = new DataGridViewButtonColumn();
            Column3 = new DataGridViewButtonColumn();
            Column2 = new DataGridViewButtonColumn();
            Column1 = new DataGridViewButtonColumn();
            GameField = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)GameField).BeginInit();
            SuspendLayout();
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column5.FlatStyle = FlatStyle.Flat;
            Column5.HeaderText = "";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // Column4
            // 
            Column4.FlatStyle = FlatStyle.Flat;
            Column4.HeaderText = "";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column3
            // 
            Column3.FlatStyle = FlatStyle.Flat;
            Column3.HeaderText = "";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column2
            // 
            Column2.FlatStyle = FlatStyle.Flat;
            Column2.HeaderText = "";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column1
            // 
            Column1.FlatStyle = FlatStyle.Flat;
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            Column1.UseColumnTextForButtonValue = true;
            Column1.Width = 125;
            // 
            // GameField
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Berlin Sans FB", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GameField.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            GameField.BackgroundColor = Color.White;
            GameField.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GameField.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            GameField.Location = new Point(216, 172);
            GameField.Name = "GameField";
            GameField.RowHeadersWidth = 51;
            GameField.Size = new Size(365, 180);
            GameField.TabIndex = 0;
            GameField.CellContentClick += dataGridView1_CellContentClick;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(76, 69);
            label2.Name = "label2";
            label2.Size = new Size(91, 29);
            label2.TabIndex = 2;
            label2.Text = "Руслан";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(76, 98);
            label3.Name = "label3";
            label3.Size = new Size(103, 29);
            label3.TabIndex = 3;
            label3.Text = "Счёт: 25";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(618, 98);
            label4.Name = "label4";
            label4.Size = new Size(102, 29);
            label4.TabIndex = 6;
            label4.Text = "Счёт: 35";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(618, 69);
            label5.Name = "label5";
            label5.Size = new Size(96, 29);
            label5.TabIndex = 5;
            label5.Text = "Анжела";
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
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(128, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(305, 60);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 56);
            textBox1.TabIndex = 7;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(638, 385);
            button1.Name = "button1";
            button1.Size = new Size(132, 36);
            button1.TabIndex = 8;
            button1.Text = "Пропуск хода";
            button1.UseVisualStyleBackColor = false;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.коричнеый_фон;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GameField);
            Name = "GameForm";
            Text = "Балда";
            ((System.ComponentModel.ISupportInitialize)GameField).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewButtonColumn Column5;
        private DataGridViewButtonColumn Column4;
        private DataGridViewButtonColumn Column3;
        private DataGridViewButtonColumn Column2;
        private DataGridViewButtonColumn Column1;
        private DataGridView GameField;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private Button button1;
    }
}