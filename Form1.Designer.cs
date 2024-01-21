namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SUDOKU = new System.Windows.Forms.DataGridView();
            this.HOUSE = new System.Windows.Forms.PictureBox();
            this.VADIMKA = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.text_timer = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.vadik_state = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numbers_storage = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.SUDOKU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOUSE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VADIMKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numbers_storage)).BeginInit();
            this.SuspendLayout();
            // 
            // SUDOKU
            // 
            this.SUDOKU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SUDOKU.Location = new System.Drawing.Point(12, 12);
            this.SUDOKU.Name = "SUDOKU";
            this.SUDOKU.ReadOnly = true;
            this.SUDOKU.RowHeadersWidth = 51;
            this.SUDOKU.RowTemplate.Height = 50;
            this.SUDOKU.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SUDOKU.Size = new System.Drawing.Size(438, 426);
            this.SUDOKU.TabIndex = 0;
            // 
            // HOUSE
            // 
            this.HOUSE.Location = new System.Drawing.Point(1161, 437);
            this.HOUSE.Name = "HOUSE";
            this.HOUSE.Size = new System.Drawing.Size(150, 150);
            this.HOUSE.TabIndex = 1;
            this.HOUSE.TabStop = false;
            // 
            // VADIMKA
            // 
            this.VADIMKA.Location = new System.Drawing.Point(1055, 487);
            this.VADIMKA.Name = "VADIMKA";
            this.VADIMKA.Size = new System.Drawing.Size(50, 50);
            this.VADIMKA.TabIndex = 2;
            this.VADIMKA.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(470, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Решить судоку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_timer
            // 
            this.text_timer.AutoSize = true;
            this.text_timer.Location = new System.Drawing.Point(467, 50);
            this.text_timer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.text_timer.Name = "text_timer";
            this.text_timer.Size = new System.Drawing.Size(35, 13);
            this.text_timer.TabIndex = 4;
            this.text_timer.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(603, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Выпустить Вадимку";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // vadik_state
            // 
            this.vadik_state.AutoSize = true;
            this.vadik_state.Location = new System.Drawing.Point(609, 50);
            this.vadik_state.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vadik_state.Name = "vadik_state";
            this.vadik_state.Size = new System.Drawing.Size(30, 13);
            this.vadik_state.TabIndex = 6;
            this.vadik_state.Text = "state";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(609, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "state";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(658, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "state";
            // 
            // numbers_storage
            // 
            this.numbers_storage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.numbers_storage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.numbers_storage.ColumnHeadersVisible = false;
            this.numbers_storage.Location = new System.Drawing.Point(1161, 12);
            this.numbers_storage.Name = "numbers_storage";
            this.numbers_storage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.numbers_storage.Size = new System.Drawing.Size(150, 419);
            this.numbers_storage.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 599);
            this.Controls.Add(this.numbers_storage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vadik_state);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.text_timer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VADIMKA);
            this.Controls.Add(this.HOUSE);
            this.Controls.Add(this.SUDOKU);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SUDOKU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOUSE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VADIMKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numbers_storage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SUDOKU;
        private System.Windows.Forms.PictureBox HOUSE;
        private System.Windows.Forms.PictureBox VADIMKA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label text_timer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label vadik_state;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView numbers_storage;
    }
}

