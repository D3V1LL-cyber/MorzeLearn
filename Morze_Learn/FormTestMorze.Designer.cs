namespace YourNamespace
{
    partial class FormTestMorze
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelResult = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.buttonLeaderboard = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.groupBoxSelection = new System.Windows.Forms.GroupBox();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.checkBoxSymbols = new System.Windows.Forms.CheckBox();
            this.checkBoxNumbers = new System.Windows.Forms.CheckBox();
            this.checkBoxRussian = new System.Windows.Forms.CheckBox();
            this.checkBoxLatin = new System.Windows.Forms.CheckBox();
            this.labelTestTitle = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.groupBoxSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.AliceBlue;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.labelResult);
            this.panelMain.Controls.Add(this.progressBar);
            this.panelMain.Controls.Add(this.buttonPanel);
            this.panelMain.Controls.Add(this.textBoxAnswer);
            this.panelMain.Controls.Add(this.labelQuestion);
            this.panelMain.Controls.Add(this.groupBoxSelection);
            this.panelMain.Controls.Add(this.labelTestTitle);
            this.panelMain.Controls.Add(this.labelStatus);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(700, 500);
            this.panelMain.TabIndex = 0;
            // 
            // labelResult
            // 
            this.labelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelResult.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelResult.Location = new System.Drawing.Point(0, 225);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(698, 248);
            this.labelResult.TabIndex = 7;
            this.labelResult.Text = "labelResult";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.progressBar.Location = new System.Drawing.Point(0, 200);
            this.progressBar.Maximum = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(698, 25);
            this.progressBar.TabIndex = 6;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.buttonLeaderboard);
            this.buttonPanel.Controls.Add(this.buttonRestart);
            this.buttonPanel.Controls.Add(this.buttonPause);
            this.buttonPanel.Controls.Add(this.buttonNext);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.Location = new System.Drawing.Point(0, 165);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.buttonPanel.Size = new System.Drawing.Size(698, 35);
            this.buttonPanel.TabIndex = 5;
            // 
            // buttonLeaderboard
            // 
            this.buttonLeaderboard.BackColor = System.Drawing.Color.Gold;
            this.buttonLeaderboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeaderboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonLeaderboard.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonLeaderboard.Location = new System.Drawing.Point(300, 5);
            this.buttonLeaderboard.Name = "buttonLeaderboard";
            this.buttonLeaderboard.Size = new System.Drawing.Size(90, 25);
            this.buttonLeaderboard.TabIndex = 3;
            this.buttonLeaderboard.Text = "🏆 Лидеры";
            this.buttonLeaderboard.UseVisualStyleBackColor = false;
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonRestart.ForeColor = System.Drawing.Color.White;
            this.buttonRestart.Location = new System.Drawing.Point(200, 5);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(90, 25);
            this.buttonRestart.TabIndex = 2;
            this.buttonRestart.Text = "🔄 Заново";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.BackColor = System.Drawing.Color.Orange;
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonPause.ForeColor = System.Drawing.Color.White;
            this.buttonPause.Location = new System.Drawing.Point(100, 5);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(90, 25);
            this.buttonPause.TabIndex = 1;
            this.buttonPause.Text = "⏸ Пауза";
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.Location = new System.Drawing.Point(0, 5);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(90, 25);
            this.buttonNext.TabIndex = 0;
            this.buttonNext.Text = "Далее →";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxAnswer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxAnswer.Location = new System.Drawing.Point(0, 145);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(698, 20);
            this.textBoxAnswer.TabIndex = 4;
            this.textBoxAnswer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAnswer_KeyPress);
            // 
            // labelQuestion
            // 
            this.labelQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelQuestion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelQuestion.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelQuestion.Location = new System.Drawing.Point(0, 105);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.labelQuestion.Size = new System.Drawing.Size(698, 40);
            this.labelQuestion.TabIndex = 3;
            this.labelQuestion.Text = "labelQuestion";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxSelection
            // 
            this.groupBoxSelection.Controls.Add(this.btnDeselectAll);
            this.groupBoxSelection.Controls.Add(this.btnSelectAll);
            this.groupBoxSelection.Controls.Add(this.checkBoxSymbols);
            this.groupBoxSelection.Controls.Add(this.checkBoxNumbers);
            this.groupBoxSelection.Controls.Add(this.checkBoxRussian);
            this.groupBoxSelection.Controls.Add(this.checkBoxLatin);
            this.groupBoxSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSelection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxSelection.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBoxSelection.Location = new System.Drawing.Point(0, 50);
            this.groupBoxSelection.Name = "groupBoxSelection";
            this.groupBoxSelection.Size = new System.Drawing.Size(698, 55);
            this.groupBoxSelection.TabIndex = 2;
            this.groupBoxSelection.TabStop = false;
            this.groupBoxSelection.Text = "Выберите группы символов для тестирования:";
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectAll.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnDeselectAll.ForeColor = System.Drawing.Color.White;
            this.btnDeselectAll.Location = new System.Drawing.Point(600, 20);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(80, 25);
            this.btnDeselectAll.TabIndex = 5;
            this.btnDeselectAll.Text = "Снять все";
            this.btnDeselectAll.UseVisualStyleBackColor = false;
            this.btnDeselectAll.Click += new System.EventHandler(this.BtnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.Color.LightGreen;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnSelectAll.ForeColor = System.Drawing.Color.White;
            this.btnSelectAll.Location = new System.Drawing.Point(510, 20);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(80, 25);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "Выбрать все";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // checkBoxSymbols
            // 
            this.checkBoxSymbols.AutoSize = true;
            this.checkBoxSymbols.Checked = true;
            this.checkBoxSymbols.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSymbols.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBoxSymbols.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxSymbols.Location = new System.Drawing.Point(380, 25);
            this.checkBoxSymbols.Name = "checkBoxSymbols";
            this.checkBoxSymbols.Size = new System.Drawing.Size(124, 19);
            this.checkBoxSymbols.TabIndex = 3;
            this.checkBoxSymbols.Tag = "symbols";
            this.checkBoxSymbols.Text = "Символы и знаки";
            this.checkBoxSymbols.UseVisualStyleBackColor = true;
            this.checkBoxSymbols.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxNumbers
            // 
            this.checkBoxNumbers.AutoSize = true;
            this.checkBoxNumbers.Checked = true;
            this.checkBoxNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNumbers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBoxNumbers.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxNumbers.Location = new System.Drawing.Point(280, 25);
            this.checkBoxNumbers.Name = "checkBoxNumbers";
            this.checkBoxNumbers.Size = new System.Drawing.Size(94, 19);
            this.checkBoxNumbers.TabIndex = 2;
            this.checkBoxNumbers.Tag = "numbers";
            this.checkBoxNumbers.Text = "Цифры (0-9)";
            this.checkBoxNumbers.UseVisualStyleBackColor = true;
            this.checkBoxNumbers.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxRussian
            // 
            this.checkBoxRussian.AutoSize = true;
            this.checkBoxRussian.Checked = true;
            this.checkBoxRussian.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRussian.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBoxRussian.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxRussian.Location = new System.Drawing.Point(140, 25);
            this.checkBoxRussian.Name = "checkBoxRussian";
            this.checkBoxRussian.Size = new System.Drawing.Size(134, 19);
            this.checkBoxRussian.TabIndex = 1;
            this.checkBoxRussian.Tag = "russian";
            this.checkBoxRussian.Text = "Русские буквы (А-Я)";
            this.checkBoxRussian.UseVisualStyleBackColor = true;
            this.checkBoxRussian.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxLatin
            // 
            this.checkBoxLatin.AutoSize = true;
            this.checkBoxLatin.Checked = true;
            this.checkBoxLatin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLatin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBoxLatin.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxLatin.Location = new System.Drawing.Point(20, 25);
            this.checkBoxLatin.Name = "checkBoxLatin";
            this.checkBoxLatin.Size = new System.Drawing.Size(114, 19);
            this.checkBoxLatin.TabIndex = 0;
            this.checkBoxLatin.Tag = "latin";
            this.checkBoxLatin.Text = "Латинские (A-Z)";
            this.checkBoxLatin.UseVisualStyleBackColor = true;
            this.checkBoxLatin.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // labelTestTitle
            // 
            this.labelTestTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTestTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTestTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelTestTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTestTitle.Name = "labelTestTitle";
            this.labelTestTitle.Size = new System.Drawing.Size(698, 50);
            this.labelTestTitle.TabIndex = 1;
            this.labelTestTitle.Text = "ТЕСТ ПО АЗБУКЕ МОРЗЕ";
            this.labelTestTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatus
            // 
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelStatus.ForeColor = System.Drawing.Color.Gray;
            this.labelStatus.Location = new System.Drawing.Point(0, 473);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelStatus.Size = new System.Drawing.Size(698, 27);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Готов к тестированию...";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormTestMorze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.panelMain);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "FormTestMorze";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тест по азбуке Морзе - Обучающее Приложение";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTestMorze_FormClosing);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.groupBoxSelection.ResumeLayout(false);
            this.groupBoxSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button buttonLeaderboard;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.GroupBox groupBoxSelection;
        private System.Windows.Forms.CheckBox checkBoxSymbols;
        private System.Windows.Forms.CheckBox checkBoxNumbers;
        private System.Windows.Forms.CheckBox checkBoxRussian;
        private System.Windows.Forms.CheckBox checkBoxLatin;
        private System.Windows.Forms.Label labelTestTitle;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnSelectAll;
    }
}
