namespace ProtivTecheniya.Studio
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.filePath = new System.Windows.Forms.TextBox();
            this.browsefilesbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.question = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.incorrectans = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.correctans = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "questions.txt|questions.txt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Путь к файлу с вопросами:";
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(164, 6);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(144, 20);
            this.filePath.TabIndex = 3;
            // 
            // browsefilesbtn
            // 
            this.browsefilesbtn.Location = new System.Drawing.Point(314, 4);
            this.browsefilesbtn.Name = "browsefilesbtn";
            this.browsefilesbtn.Size = new System.Drawing.Size(26, 23);
            this.browsefilesbtn.TabIndex = 4;
            this.browsefilesbtn.Text = "...";
            this.browsefilesbtn.UseVisualStyleBackColor = true;
            this.browsefilesbtn.Click += new System.EventHandler(this.browsefilesbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.question);
            this.groupBox1.Location = new System.Drawing.Point(15, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 48);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вопрос";
            // 
            // question
            // 
            this.question.Location = new System.Drawing.Point(7, 20);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(328, 20);
            this.question.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.incorrectans);
            this.groupBox2.Location = new System.Drawing.Point(15, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 48);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Неправильный ответ";
            // 
            // incorrectans
            // 
            this.incorrectans.Location = new System.Drawing.Point(7, 20);
            this.incorrectans.Name = "incorrectans";
            this.incorrectans.Size = new System.Drawing.Size(328, 20);
            this.incorrectans.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.correctans);
            this.groupBox3.Location = new System.Drawing.Point(15, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 48);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Правильный ответ";
            // 
            // correctans
            // 
            this.correctans.Location = new System.Drawing.Point(7, 20);
            this.correctans.Name = "correctans";
            this.correctans.Size = new System.Drawing.Size(328, 20);
            this.correctans.TabIndex = 0;
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.MintCream;
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.savebtn.Location = new System.Drawing.Point(123, 194);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(143, 38);
            this.savebtn.TabIndex = 8;
            this.savebtn.Text = "Сохранить вопрос...";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 242);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browsefilesbtn);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Студия \"Против Течения\"";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button browsefilesbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox question;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox incorrectans;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox correctans;
        private System.Windows.Forms.Button savebtn;


    }
}

