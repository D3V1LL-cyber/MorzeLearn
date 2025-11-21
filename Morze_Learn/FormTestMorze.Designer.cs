using System;
using System.Drawing;
using System.Windows.Forms;

namespace YourNamespace
{
    partial class FormTestMorze
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnPause; // добавляем кнопку паузы

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(20, 20);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(194, 25);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Вопрос будет здесь";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAnswer.Location = new System.Drawing.Point(20, 45);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(400, 29);
            this.txtAnswer.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(20, 74);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 40);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.progressBar.Location = new System.Drawing.Point(20, 114);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(560, 25);
            this.progressBar.TabIndex = 4;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(20, 139);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 25);
            this.lblResult.TabIndex = 5;
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Location = new System.Drawing.Point(140, 74);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 40);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Пауза";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // FormTestMorze
            // 
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(591, 241);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblResult);
            this.Name = "FormTestMorze";
            this.Text = "Тест по азбуке Морзе";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private bool isPaused = false; // переменная для отслеживания режима паузы

        private void BtnPause_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused; // переключение состояния

            if (isPaused)
            {
                // при постановке на паузу
                MessageBox.Show("Тест поставлен на паузу");
                // Можно дополнительно отключить кнопку "Далее", чтобы запретить переход
                // или блокировать ввод, если нужно
                txtAnswer.Enabled = false;
                btnNext.Enabled = false;
                btnPause.Text = "Продолжить"; // меняем текст кнопки
            }
            else
            {
                // при продолжении
                MessageBox.Show("Тест продолжен");
                txtAnswer.Enabled = true;
                btnNext.Enabled = true;
                btnPause.Text = "Пауза"; // возвращаем исходный текст
                LoadQuestion(); // сразу показываем текущий вопрос
            }
        }
    }
}