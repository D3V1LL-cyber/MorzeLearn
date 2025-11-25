namespace YourNamespace
{
    partial class FormLeaderboard
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
            this._panelMain = new System.Windows.Forms.Panel();
            this._listBoxLeaderboard = new System.Windows.Forms.ListBox();
            this.controlPanel = new System.Windows.Forms.Panel();
            this._buttonClose = new System.Windows.Forms.Button();
            this._buttonRefresh = new System.Windows.Forms.Button();
            this._comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this._labelSubtitle = new System.Windows.Forms.Label();
            this._labelTitle = new System.Windows.Forms.Label();
            this._panelMain.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelMain
            // 
            this._panelMain.BackColor = System.Drawing.Color.AliceBlue;
            this._panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelMain.Controls.Add(this._listBoxLeaderboard);
            this._panelMain.Controls.Add(this.controlPanel);
            this._panelMain.Controls.Add(this._labelSubtitle);
            this._panelMain.Controls.Add(this._labelTitle);
            this._panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelMain.Location = new System.Drawing.Point(0, 0);
            this._panelMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._panelMain.Name = "_panelMain";
            this._panelMain.Padding = new System.Windows.Forms.Padding(15);
            this._panelMain.Size = new System.Drawing.Size(684, 561);
            this._panelMain.TabIndex = 0;
            // 
            // _listBoxLeaderboard
            // 
            this._listBoxLeaderboard.BackColor = System.Drawing.Color.White;
            this._listBoxLeaderboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._listBoxLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listBoxLeaderboard.Font = new System.Drawing.Font("Consolas", 10F);
            this._listBoxLeaderboard.ForeColor = System.Drawing.Color.DarkSlateGray;
            this._listBoxLeaderboard.ItemHeight = 15;
            this._listBoxLeaderboard.Location = new System.Drawing.Point(15, 145);
            this._listBoxLeaderboard.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._listBoxLeaderboard.Name = "_listBoxLeaderboard";
            this._listBoxLeaderboard.Size = new System.Drawing.Size(652, 399);
            this._listBoxLeaderboard.TabIndex = 3;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this._buttonClose);
            this.controlPanel.Controls.Add(this._buttonRefresh);
            this.controlPanel.Controls.Add(this._comboBoxFilter);
            this.controlPanel.Controls.Add(this.labelFilter);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(15, 95);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.controlPanel.Size = new System.Drawing.Size(652, 50);
            this.controlPanel.TabIndex = 2;
            // 
            // _buttonClose
            // 
            this._buttonClose.BackColor = System.Drawing.Color.Crimson;
            this._buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._buttonClose.ForeColor = System.Drawing.Color.White;
            this._buttonClose.Location = new System.Drawing.Point(350, 10);
            this._buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(100, 28);
            this._buttonClose.TabIndex = 3;
            this._buttonClose.Text = "✖ Закрыть";
            this._buttonClose.UseVisualStyleBackColor = false;
            this._buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // _buttonRefresh
            // 
            this._buttonRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this._buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._buttonRefresh.ForeColor = System.Drawing.Color.White;
            this._buttonRefresh.Location = new System.Drawing.Point(240, 10);
            this._buttonRefresh.Margin = new System.Windows.Forms.Padding(0);
            this._buttonRefresh.Name = "_buttonRefresh";
            this._buttonRefresh.Size = new System.Drawing.Size(100, 28);
            this._buttonRefresh.TabIndex = 2;
            this._buttonRefresh.Text = "🔄 Обновить";
            this._buttonRefresh.UseVisualStyleBackColor = false;
            this._buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // _comboBoxFilter
            // 
            this._comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._comboBoxFilter.FormattingEnabled = true;
            this._comboBoxFilter.Items.AddRange(new object[] {
            "Все категории",
            "Все символы",
            "Латинские буквы",
            "Русские буквы",
            "Цифры",
            "Символы"});
            this._comboBoxFilter.Location = new System.Drawing.Point(75, 10);
            this._comboBoxFilter.Margin = new System.Windows.Forms.Padding(0);
            this._comboBoxFilter.Name = "_comboBoxFilter";
            this._comboBoxFilter.Size = new System.Drawing.Size(150, 23);
            this._comboBoxFilter.TabIndex = 1;
            this._comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFilter_SelectedIndexChanged);
            // 
            // labelFilter
            // 
            this.labelFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelFilter.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelFilter.Location = new System.Drawing.Point(0, 12);
            this.labelFilter.Margin = new System.Windows.Forms.Padding(0);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(70, 25);
            this.labelFilter.TabIndex = 0;
            this.labelFilter.Text = "Категория:";
            this.labelFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelSubtitle
            // 
            this._labelSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._labelSubtitle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this._labelSubtitle.Location = new System.Drawing.Point(15, 65);
            this._labelSubtitle.Margin = new System.Windows.Forms.Padding(0);
            this._labelSubtitle.Name = "_labelSubtitle";
            this._labelSubtitle.Size = new System.Drawing.Size(652, 30);
            this._labelSubtitle.TabIndex = 1;
            this._labelSubtitle.Text = "Лучшие результаты тестирования по азбуке Морзе";
            this._labelSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _labelTitle
            // 
            this._labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this._labelTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this._labelTitle.Location = new System.Drawing.Point(15, 15);
            this._labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this._labelTitle.Name = "_labelTitle";
            this._labelTitle.Size = new System.Drawing.Size(652, 50);
            this._labelTitle.TabIndex = 0;
            this._labelTitle.Text = "🏆 ТАБЛИЦА ЛИДЕРОВ";
            this._labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormLeaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this._panelMain);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "FormLeaderboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Таблица лидеров - Тест по азбуке Морзе";
            this._panelMain.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panelMain;
        private System.Windows.Forms.ListBox _listBoxLeaderboard;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.Button _buttonRefresh;
        private System.Windows.Forms.ComboBox _comboBoxFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Label _labelSubtitle;
        private System.Windows.Forms.Label _labelTitle;
    }
}
