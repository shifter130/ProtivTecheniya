using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ProtivTecheniya.Studio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void browsefilesbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Файл вопросов|questions.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = dialog.FileName;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (question.Text == "" || incorrectans.Text == "" || correctans.Text == "") {
                savebtn.BackColor = Color.Tomato;
                savebtn.Text = "ОШИБКА!!";
                MessageBox.Show("Невозможно записать пустой вопрос!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                savebtn.BackColor = Color.MintCream;
                savebtn.Text = "Сохранить вопрос...";
                return;
            }
            string text = "Привет, мир!" + Environment.NewLine;
            string cookedquestion = question.Text + "///" + incorrectans.Text + "///" + correctans.Text + Environment.NewLine;
            try
            {
                File.AppendAllText(filePath.Text, cookedquestion, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                savebtn.BackColor = Color.Tomato;
                savebtn.Text = "ОШИБКА!!";
                MessageBox.Show("Возникла проблема: " + ex.Message);
                savebtn.BackColor = Color.MintCream;
                savebtn.Text = "Сохранить вопрос...";
                return;
            }
                savebtn.BackColor = Color.LightGreen;
                savebtn.Text = "Успешно!";
                Application.DoEvents();
                Thread.Sleep(1200);
                savebtn.BackColor = Color.MintCream;
                savebtn.Text = "Сохранить вопрос...";
        }
    }
}
