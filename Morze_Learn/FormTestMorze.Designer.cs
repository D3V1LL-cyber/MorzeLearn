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
            this.SuspendLayout();

            // lblQuestion
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(20, 20);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(200, 25);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Вопрос будет здесь";

            // txtAnswer
            this.txtAnswer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAnswer.Location = new System.Drawing.Point(20, this.lblQuestion.Bottom + 20);
            this.txtAnswer.Size = new System.Drawing.Size(400, 29);
            this.txtAnswer.TabIndex = 1;

            // btnNext
            this.btnNext.Location = new System.Drawing.Point(20, this.txtAnswer.Bottom + 20);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 40);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.BackColor = Color.FromArgb(100, 149, 237);
            this.btnNext.ForeColor = Color.White;
            this.btnNext.FlatStyle = FlatStyle.Flat;

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(20, this.btnNext.Bottom + 30);
            this.progressBar.Size = new System.Drawing.Size(560, 25);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
            this.progressBar.Value = 0;
            this.progressBar.ForeColor = Color.CornflowerBlue;

            // lblResult
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(20, this.progressBar.Bottom + 30);
            this.lblResult.Size = new System.Drawing.Size(0, 25);
            this.lblResult.TabIndex = 4;

            // Общие настройки формы
            this.ClientSize = new System.Drawing.Size(620, 400);
            this.BackColor = Color.AliceBlue;

            // Добавление элементов
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblResult);

            this.Name = "FormTestMorze";
            this.Text = "Тест по азбуке Морзе";

            // Обработчик события
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}