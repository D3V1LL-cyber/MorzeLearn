using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using YourNamespace;

namespace Morze_Learn
{
    public partial class Form1 : Form
    {
        private MorseRepository _morseRepository;
        private List<MorseSymbol> _currentSymbols;
        private AudioPlayback _audioPlayback;

        // Элементы управления - основные
        private Label _labelApplicationTitle;
        private TextBox _textBoxSearch;
        private ComboBox _comboBoxCategoryFilter;
        private Button _buttonShowAll;
        private DataGridView _dataGridViewSymbolsTable;

        // Элементы управления - панель деталей
        private Panel _panelSymbolDetails;
        private Label _labelDetailSectionTitle;
        private Label _labelSelectedSymbolDisplay;
        private Label _labelMorseCodeDisplay;
        private Label _labelSymbolDescription;
        private PictureBox _pictureBoxSymbolImage;
        private Button _buttonPlaySound;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

        // Элементы управления - статус
        private Label _labelStatusBar;

        // Новые элементы управления для звука
        private TrackBar _trackBarVolume;
        private TrackBar _trackBarPitch;
        private TrackBar _trackBarSpeed;
        private Label _labelVolume;
        private Label _labelPitch;
        private Label _labelSpeed;
        private Label _labelVolumeValue;
        private Label _labelPitchValue;
        private Label _labelSpeedValue;
        private Panel _panelAudioControls;

        // Константы для адаптивного дизайна
        private const int MARGIN = 20;
        private const int CONTROL_HEIGHT = 25;
        private const int BUTTON_WIDTH = 130;
        private const int SEARCH_WIDTH = 200;
        private const int COMBOBOX_WIDTH = 150;

        public Form1()
        {
            InitializeComponent();
            InitializeApplication();
            this.Resize += Form1_Resize;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this._labelApplicationTitle = new System.Windows.Forms.Label();
            this._textBoxSearch = new System.Windows.Forms.TextBox();
            this._comboBoxCategoryFilter = new System.Windows.Forms.ComboBox();
            this._buttonShowAll = new System.Windows.Forms.Button();
            this._dataGridViewSymbolsTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._panelSymbolDetails = new System.Windows.Forms.Panel();
            this._labelDetailSectionTitle = new System.Windows.Forms.Label();
            this._labelSelectedSymbolDisplay = new System.Windows.Forms.Label();
            this._labelMorseCodeDisplay = new System.Windows.Forms.Label();
            this._labelSymbolDescription = new System.Windows.Forms.Label();
            this._pictureBoxSymbolImage = new System.Windows.Forms.PictureBox();
            this._buttonPlaySound = new System.Windows.Forms.Button();
            this._labelStatusBar = new System.Windows.Forms.Label();
            this._buttonOpenMorzeTest = new System.Windows.Forms.Button();

            // Новые элементы управления для звука
            this._panelAudioControls = new System.Windows.Forms.Panel();
            this._trackBarVolume = new System.Windows.Forms.TrackBar();
            this._trackBarPitch = new System.Windows.Forms.TrackBar();
            this._trackBarSpeed = new System.Windows.Forms.TrackBar();
            this._labelVolume = new System.Windows.Forms.Label();
            this._labelPitch = new System.Windows.Forms.Label();
            this._labelSpeed = new System.Windows.Forms.Label();
            this._labelVolumeValue = new System.Windows.Forms.Label();
            this._labelPitchValue = new System.Windows.Forms.Label();
            this._labelSpeedValue = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewSymbolsTable)).BeginInit();
            this._panelSymbolDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxSymbolImage)).BeginInit();
            this._panelAudioControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarSpeed)).BeginInit();
            this.SuspendLayout();

            // 
            // _labelApplicationTitle
            // 
            this._labelApplicationTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this._labelApplicationTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this._labelApplicationTitle.Location = new System.Drawing.Point(MARGIN, 15);
            this._labelApplicationTitle.Name = "_labelApplicationTitle";
            this._labelApplicationTitle.Size = new System.Drawing.Size(500, 35);
            this._labelApplicationTitle.TabIndex = 0;
            this._labelApplicationTitle.Text = "АЗБУКА МОРЗЕ - ОБУЧАЮЩАЯ ПРОГРАММА";
            this._labelApplicationTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _textBoxSearch
            // 
            this._textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            this._textBoxSearch.Location = new System.Drawing.Point(MARGIN, 60);
            this._textBoxSearch.Name = "_textBoxSearch";
            this._textBoxSearch.Size = new System.Drawing.Size(SEARCH_WIDTH, CONTROL_HEIGHT);
            this._textBoxSearch.TabIndex = 1;
            this._textBoxSearch.Text = "Поиск символа...";
            this._textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            this._textBoxSearch.Enter += new System.EventHandler(this.TextBoxSearch_Enter);
            this._textBoxSearch.Leave += new System.EventHandler(this.TextBoxSearch_Leave);
            this._textBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _comboBoxCategoryFilter
            // 
            this._comboBoxCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxCategoryFilter.FormattingEnabled = true;
            this._comboBoxCategoryFilter.Items.AddRange(new object[] {
            "Все символы",
            "Латинские буквы",
            "Цифры",
            "Знаки препинания",
            "Специальные сигналы"});
            this._comboBoxCategoryFilter.Location = new System.Drawing.Point(MARGIN + SEARCH_WIDTH + 10, 60);
            this._comboBoxCategoryFilter.Name = "_comboBoxCategoryFilter";
            this._comboBoxCategoryFilter.Size = new System.Drawing.Size(COMBOBOX_WIDTH, CONTROL_HEIGHT);
            this._comboBoxCategoryFilter.TabIndex = 2;
            this._comboBoxCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategoryFilter_SelectedIndexChanged);
            this._comboBoxCategoryFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _buttonShowAll
            // 
            this._buttonShowAll.BackColor = System.Drawing.Color.SteelBlue;
            this._buttonShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonShowAll.ForeColor = System.Drawing.Color.White;
            this._buttonShowAll.Location = new System.Drawing.Point(MARGIN + SEARCH_WIDTH + COMBOBOX_WIDTH + 20, 60);
            this._buttonShowAll.Name = "_buttonShowAll";
            this._buttonShowAll.Size = new System.Drawing.Size(BUTTON_WIDTH, CONTROL_HEIGHT);
            this._buttonShowAll.TabIndex = 3;
            this._buttonShowAll.Text = "Показать все символы";
            this._buttonShowAll.UseVisualStyleBackColor = false;
            this._buttonShowAll.Click += new System.EventHandler(this.ButtonShowAll_Click);
            this._buttonShowAll.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _dataGridViewSymbolsTable
            // 
            this._dataGridViewSymbolsTable.AllowUserToAddRows = false;
            this._dataGridViewSymbolsTable.AllowUserToDeleteRows = false;
            this._dataGridViewSymbolsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridViewSymbolsTable.BackgroundColor = System.Drawing.Color.White;
            this._dataGridViewSymbolsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewSymbolsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this._dataGridViewSymbolsTable.GridColor = System.Drawing.Color.LightGray;
            this._dataGridViewSymbolsTable.Location = new System.Drawing.Point(MARGIN, 100);
            this._dataGridViewSymbolsTable.Name = "_dataGridViewSymbolsTable";
            this._dataGridViewSymbolsTable.ReadOnly = true;
            this._dataGridViewSymbolsTable.RowHeadersVisible = false;
            this._dataGridViewSymbolsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewSymbolsTable.Size = new System.Drawing.Size(500, 350);
            this._dataGridViewSymbolsTable.TabIndex = 4;
            this._dataGridViewSymbolsTable.SelectionChanged += new System.EventHandler(this.DataGridViewSymbolsTable_SelectionChanged);
            this._dataGridViewSymbolsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Символ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Код Морзе";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // _panelSymbolDetails
            // 
            this._panelSymbolDetails.BackColor = System.Drawing.Color.AliceBlue;
            this._panelSymbolDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelSymbolDetails.Controls.Add(this._labelDetailSectionTitle);
            this._panelSymbolDetails.Controls.Add(this._labelSelectedSymbolDisplay);
            this._panelSymbolDetails.Controls.Add(this._labelMorseCodeDisplay);
            this._panelSymbolDetails.Controls.Add(this._labelSymbolDescription);
            this._panelSymbolDetails.Controls.Add(this._pictureBoxSymbolImage);
            this._panelSymbolDetails.Controls.Add(this._buttonPlaySound);
            this._panelSymbolDetails.Location = new System.Drawing.Point(540, 100);
            this._panelSymbolDetails.Name = "_panelSymbolDetails";
            this._panelSymbolDetails.Size = new System.Drawing.Size(330, 350);
            this._panelSymbolDetails.TabIndex = 5;
            this._panelSymbolDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // _labelDetailSectionTitle
            // 
            this._labelDetailSectionTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._labelDetailSectionTitle.Location = new System.Drawing.Point(10, 15);
            this._labelDetailSectionTitle.Name = "_labelDetailSectionTitle";
            this._labelDetailSectionTitle.Size = new System.Drawing.Size(300, 20);
            this._labelDetailSectionTitle.TabIndex = 0;
            this._labelDetailSectionTitle.Text = "Информация о выбранном символе:";
            this._labelDetailSectionTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // _labelSelectedSymbolDisplay
            // 
            this._labelSelectedSymbolDisplay.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this._labelSelectedSymbolDisplay.ForeColor = System.Drawing.Color.DarkBlue;
            this._labelSelectedSymbolDisplay.Location = new System.Drawing.Point(10, 50);
            this._labelSelectedSymbolDisplay.Name = "_labelSelectedSymbolDisplay";
            this._labelSelectedSymbolDisplay.Size = new System.Drawing.Size(300, 70);
            this._labelSelectedSymbolDisplay.TabIndex = 1;
            this._labelSelectedSymbolDisplay.Text = "—";
            this._labelSelectedSymbolDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._labelSelectedSymbolDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // _labelMorseCodeDisplay
            // 
            this._labelMorseCodeDisplay.Font = new System.Drawing.Font("Segoe UI", 24F);
            this._labelMorseCodeDisplay.ForeColor = System.Drawing.Color.DarkRed;
            this._labelMorseCodeDisplay.Location = new System.Drawing.Point(10, 130);
            this._labelMorseCodeDisplay.Name = "_labelMorseCodeDisplay";
            this._labelMorseCodeDisplay.Size = new System.Drawing.Size(300, 40);
            this._labelMorseCodeDisplay.TabIndex = 2;
            this._labelMorseCodeDisplay.Text = "—";
            this._labelMorseCodeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._labelMorseCodeDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // _labelSymbolDescription
            // 
            this._labelSymbolDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._labelSymbolDescription.ForeColor = System.Drawing.Color.DarkSlateGray;
            this._labelSymbolDescription.Location = new System.Drawing.Point(10, 190);
            this._labelSymbolDescription.Name = "_labelSymbolDescription";
            this._labelSymbolDescription.Size = new System.Drawing.Size(300, 40);
            this._labelSymbolDescription.TabIndex = 3;
            this._labelSymbolDescription.Text = "Выберите символ из таблицы для просмотра подробной информации";
            this._labelSymbolDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._labelSymbolDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // _pictureBoxSymbolImage
            // 
            this._pictureBoxSymbolImage.BackColor = System.Drawing.Color.White;
            this._pictureBoxSymbolImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pictureBoxSymbolImage.Location = new System.Drawing.Point(10, 240);
            this._pictureBoxSymbolImage.Name = "_pictureBoxSymbolImage";
            this._pictureBoxSymbolImage.Size = new System.Drawing.Size(120, 90);
            this._pictureBoxSymbolImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._pictureBoxSymbolImage.TabIndex = 4;
            this._pictureBoxSymbolImage.TabStop = false;
            this._pictureBoxSymbolImage.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _buttonPlaySound
            // 
            this._buttonPlaySound.BackColor = System.Drawing.Color.ForestGreen;
            this._buttonPlaySound.Enabled = false;
            this._buttonPlaySound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonPlaySound.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._buttonPlaySound.ForeColor = System.Drawing.Color.White;
            this._buttonPlaySound.Location = new System.Drawing.Point(140, 240);
            this._buttonPlaySound.Name = "_buttonPlaySound";
            this._buttonPlaySound.Size = new System.Drawing.Size(170, 40);
            this._buttonPlaySound.TabIndex = 5;
            this._buttonPlaySound.Text = "▶ Воспроизвести";
            this._buttonPlaySound.UseVisualStyleBackColor = false;
            this._buttonPlaySound.Click += new System.EventHandler(this.ButtonPlaySound_Click);
            this._buttonPlaySound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // 
            // _labelStatusBar
            // 
            this._labelStatusBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._labelStatusBar.ForeColor = System.Drawing.Color.Gray;
            this._labelStatusBar.Location = new System.Drawing.Point(MARGIN, 510);
            this._labelStatusBar.Name = "_labelStatusBar";
            this._labelStatusBar.Size = new System.Drawing.Size(850, 20);
            this._labelStatusBar.TabIndex = 6;
            this._labelStatusBar.Text = "Приложение готово к работе. Выберите символ для изучения.";
            this._labelStatusBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // _buttonOpenMorzeTest
            // 
            this._buttonOpenMorzeTest.BackColor = System.Drawing.Color.Indigo;
            this._buttonOpenMorzeTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonOpenMorzeTest.ForeColor = System.Drawing.Color.White;
            this._buttonOpenMorzeTest.Location = new System.Drawing.Point(691, 12);
            this._buttonOpenMorzeTest.Name = "_buttonOpenMorzeTest";
            this._buttonOpenMorzeTest.Size = new System.Drawing.Size(190, 73);
            this._buttonOpenMorzeTest.TabIndex = 7;
            this._buttonOpenMorzeTest.Text = "Тесты по Морзе";
            this._buttonOpenMorzeTest.UseVisualStyleBackColor = false;
            this._buttonOpenMorzeTest.Click += new System.EventHandler(this._buttonOpenMorzeTest_Click);
            this._buttonOpenMorzeTest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // 
            // _panelAudioControls
            // 
            this._panelAudioControls.BackColor = System.Drawing.Color.Lavender;
            this._panelAudioControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelAudioControls.Controls.Add(this._labelSpeed);
            this._panelAudioControls.Controls.Add(this._labelPitch);
            this._panelAudioControls.Controls.Add(this._labelVolume);
            this._panelAudioControls.Controls.Add(this._trackBarSpeed);
            this._panelAudioControls.Controls.Add(this._trackBarPitch);
            this._panelAudioControls.Controls.Add(this._trackBarVolume);
            this._panelAudioControls.Controls.Add(this._labelSpeedValue);
            this._panelAudioControls.Controls.Add(this._labelPitchValue);
            this._panelAudioControls.Controls.Add(this._labelVolumeValue);
            this._panelAudioControls.Location = new System.Drawing.Point(MARGIN, 460);
            this._panelAudioControls.Name = "_panelAudioControls";
            this._panelAudioControls.Size = new System.Drawing.Size(850, 40);
            this._panelAudioControls.TabIndex = 8;
            this._panelAudioControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // _trackBarVolume
            // 
            this._trackBarVolume.Location = new System.Drawing.Point(70, 10);
            this._trackBarVolume.Maximum = 100;
            this._trackBarVolume.Minimum = 1;
            this._trackBarVolume.Name = "_trackBarVolume";
            this._trackBarVolume.Size = new System.Drawing.Size(150, 45);
            this._trackBarVolume.TabIndex = 0;
            this._trackBarVolume.Value = 80;
            this._trackBarVolume.Scroll += new System.EventHandler(this.TrackBarVolume_Scroll);
            this._trackBarVolume.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _trackBarPitch
            // 
            this._trackBarPitch.Location = new System.Drawing.Point(320, 10);
            this._trackBarPitch.Maximum = 1500;
            this._trackBarPitch.Minimum = 300;
            this._trackBarPitch.Name = "_trackBarPitch";
            this._trackBarPitch.Size = new System.Drawing.Size(150, 45);
            this._trackBarPitch.TabIndex = 1;
            this._trackBarPitch.Value = 800;
            this._trackBarPitch.Scroll += new System.EventHandler(this.TrackBarPitch_Scroll);
            this._trackBarPitch.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _trackBarSpeed
            // 
            this._trackBarSpeed.Location = new System.Drawing.Point(570, 10);
            this._trackBarSpeed.Maximum = 200;
            this._trackBarSpeed.Minimum = 50;
            this._trackBarSpeed.Name = "_trackBarSpeed";
            this._trackBarSpeed.Size = new System.Drawing.Size(150, 45);
            this._trackBarSpeed.TabIndex = 2;
            this._trackBarSpeed.Value = 100;
            this._trackBarSpeed.Scroll += new System.EventHandler(this.TrackBarSpeed_Scroll);
            this._trackBarSpeed.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _labelVolume
            // 
            this._labelVolume.AutoSize = true;
            this._labelVolume.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelVolume.Location = new System.Drawing.Point(10, 12);
            this._labelVolume.Name = "_labelVolume";
            this._labelVolume.Size = new System.Drawing.Size(54, 15);
            this._labelVolume.TabIndex = 3;
            this._labelVolume.Text = "Громкость:";
            this._labelVolume.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _labelPitch
            // 
            this._labelPitch.AutoSize = true;
            this._labelPitch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelPitch.Location = new System.Drawing.Point(260, 12);
            this._labelPitch.Name = "_labelPitch";
            this._labelPitch.Size = new System.Drawing.Size(54, 15);
            this._labelPitch.TabIndex = 4;
            this._labelPitch.Text = "Тональность:";
            this._labelPitch.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _labelSpeed
            // 
            this._labelSpeed.AutoSize = true;
            this._labelSpeed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._labelSpeed.Location = new System.Drawing.Point(510, 12);
            this._labelSpeed.Name = "_labelSpeed";
            this._labelSpeed.Size = new System.Drawing.Size(54, 15);
            this._labelSpeed.TabIndex = 5;
            this._labelSpeed.Text = "Скорость:";
            this._labelSpeed.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _labelVolumeValue
            // 
            this._labelVolumeValue.AutoSize = true;
            this._labelVolumeValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._labelVolumeValue.Location = new System.Drawing.Point(230, 12);
            this._labelVolumeValue.Name = "_labelVolumeValue";
            this._labelVolumeValue.Size = new System.Drawing.Size(25, 13);
            this._labelVolumeValue.TabIndex = 6;
            this._labelVolumeValue.Text = "80%";
            this._labelVolumeValue.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _labelPitchValue
            // 
            this._labelPitchValue.AutoSize = true;
            this._labelPitchValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._labelPitchValue.Location = new System.Drawing.Point(480, 12);
            this._labelPitchValue.Name = "_labelPitchValue";
            this._labelPitchValue.Size = new System.Drawing.Size(25, 13);
            this._labelPitchValue.TabIndex = 7;
            this._labelPitchValue.Text = "800Hz";
            this._labelPitchValue.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // _labelSpeedValue
            // 
            this._labelSpeedValue.AutoSize = true;
            this._labelSpeedValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._labelSpeedValue.Location = new System.Drawing.Point(730, 12);
            this._labelSpeedValue.Name = "_labelSpeedValue";
            this._labelSpeedValue.Size = new System.Drawing.Size(31, 13);
            this._labelSpeedValue.TabIndex = 8;
            this._labelSpeedValue.Text = "100%";
            this._labelSpeedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(893, 561);
            this.Controls.Add(this._panelAudioControls);
            this.Controls.Add(this._buttonOpenMorzeTest);
            this.Controls.Add(this._labelApplicationTitle);
            this.Controls.Add(this._textBoxSearch);
            this.Controls.Add(this._comboBoxCategoryFilter);
            this.Controls.Add(this._buttonShowAll);
            this.Controls.Add(this._dataGridViewSymbolsTable);
            this.Controls.Add(this._panelSymbolDetails);
            this.Controls.Add(this._labelStatusBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(909, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изучение Азбуки Морзе - Обучающее Приложение";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewSymbolsTable)).EndInit();
            this._panelSymbolDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxSymbolImage)).EndInit();
            this._panelAudioControls.ResumeLayout(false);
            this._panelAudioControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            int clientWidth = this.ClientSize.Width;
            int clientHeight = this.ClientSize.Height;

            // Обновляем размеры основных элементов
            if (clientWidth > 900)
            {
                // Адаптивная ширина таблицы (40% от ширины окна)
                int tableWidth = (int)(clientWidth * 0.4) - MARGIN * 2;
                _dataGridViewSymbolsTable.Width = Math.Max(400, tableWidth);

                // Позиция панели деталей
                _panelSymbolDetails.Left = _dataGridViewSymbolsTable.Right + MARGIN;
                _panelSymbolDetails.Width = clientWidth - _panelSymbolDetails.Left - MARGIN;

                // Высота элементов
                int availableHeight = clientHeight - 160; // 160px - отступы сверху и снизу
                _dataGridViewSymbolsTable.Height = availableHeight;
                _panelSymbolDetails.Height = availableHeight;

                // Позиция панели аудио-контролов
                _panelAudioControls.Top = clientHeight - 70;
                _panelAudioControls.Width = clientWidth - MARGIN * 2;

                // Позиция статусной строки
                _labelStatusBar.Top = clientHeight - 30;
                _labelStatusBar.Width = clientWidth - MARGIN * 2;

                // Позиция кнопки тестов
                _buttonOpenMorzeTest.Left = clientWidth - 210;
            }

            // Обновляем размеры внутренних элементов панели деталей
            if (_panelSymbolDetails.Width > 0)
            {
                _labelDetailSectionTitle.Width = _panelSymbolDetails.Width - 20;
                _labelSelectedSymbolDisplay.Width = _panelSymbolDetails.Width - 20;
                _labelMorseCodeDisplay.Width = _panelSymbolDetails.Width - 20;
                _labelSymbolDescription.Width = _panelSymbolDetails.Width - 20;

                // Адаптивное позиционирование кнопки воспроизведения
                if (_panelSymbolDetails.Width > 250)
                {
                    _buttonPlaySound.Left = _panelSymbolDetails.Width - 180;
                }
            }

            // Адаптивное распределение ползунков на панели аудио-контролов
            if (_panelAudioControls.Width > 600)
            {
                int availableWidth = _panelAudioControls.Width - 40;
                int sectionWidth = availableWidth / 3;

                _trackBarVolume.Width = sectionWidth - 80;
                _trackBarPitch.Width = sectionWidth - 80;
                _trackBarSpeed.Width = sectionWidth - 80;

                _trackBarPitch.Left = sectionWidth + 20;
                _labelPitch.Left = _trackBarPitch.Left - 60;
                _labelPitchValue.Left = _trackBarPitch.Right + 5;

                _trackBarSpeed.Left = sectionWidth * 2 + 20;
                _labelSpeed.Left = _trackBarSpeed.Left - 60;
                _labelSpeedValue.Left = _trackBarSpeed.Right + 5;

                _labelVolumeValue.Left = _trackBarVolume.Right + 5;
            }
        }

        private void _buttonOpenMorzeTest_Click(object sender, EventArgs e)
        {
            var formTestMorze = new FormTestMorze();
            formTestMorze.ShowDialog(); // открывает модально
        }

        private void InitializeApplication()
        {
            _morseRepository = new MorseRepository();
            _audioPlayback = new AudioPlayback();
            _currentSymbols = _morseRepository.GetAllSymbols();

            // Установка начального значения комбобокса
            _comboBoxCategoryFilter.SelectedIndex = 0;

            // Инициализация значений ползунков
            UpdateAudioSettings();

            // Первоначальное обновление layout
            UpdateLayout();

            RefreshSymbolsTable();
        }

        private void UpdateAudioSettings()
        {
            _audioPlayback.Volume = _trackBarVolume.Value / 100f;
            _audioPlayback.BaseFrequency = _trackBarPitch.Value;
            _audioPlayback.SpeedMultiplier = _trackBarSpeed.Value / 100f;

            _labelVolumeValue.Text = $"{_trackBarVolume.Value}%";
            _labelPitchValue.Text = $"{_trackBarPitch.Value}Hz";
            _labelSpeedValue.Text = $"{_trackBarSpeed.Value}%";
        }

        private void RefreshSymbolsTable()
        {
            _dataGridViewSymbolsTable.Rows.Clear();

            foreach (var symbol in _currentSymbols)
            {
                _dataGridViewSymbolsTable.Rows.Add(
                    symbol.Character,
                    symbol.MorseCode,
                    symbol.Description
                );
            }

            UpdateStatusBar($"Загружено символов для изучения: {_currentSymbols.Count}");
        }

        private void UpdateStatusBar(string statusMessage)
        {
            _labelStatusBar.Text = statusMessage;
        }

        // ОБРАБОТЧИКИ СОБЫТИЙ ЭЛЕМЕНТОВ УПРАВЛЕНИЯ

        private void TextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (_textBoxSearch.Text == "Поиск символа...")
            {
                _textBoxSearch.Text = "";
                _textBoxSearch.ForeColor = Color.Black;
            }
        }

        private void TextBoxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_textBoxSearch.Text))
            {
                _textBoxSearch.Text = "Поиск символа...";
                _textBoxSearch.ForeColor = Color.Gray;
            }
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (_textBoxSearch.Text != "Поиск символа..." && !string.IsNullOrEmpty(_textBoxSearch.Text))
            {
                _currentSymbols = _morseRepository.SearchSymbols(_textBoxSearch.Text);
                RefreshSymbolsTable();
                UpdateStatusBar($"Результаты поиска: найдено {_currentSymbols.Count} символов");
            }
            else if (string.IsNullOrEmpty(_textBoxSearch.Text) || _textBoxSearch.Text == "Поиск символа...")
            {
                // Если поиск очищен, показываем все символы текущей категории
                var selectedCategory = (MorseRepository.SymbolCategory)_comboBoxCategoryFilter.SelectedIndex;
                _currentSymbols = _morseRepository.GetSymbolsByCategory(selectedCategory);
                RefreshSymbolsTable();
                UpdateStatusBar($"Отображены символы категории: {_comboBoxCategoryFilter.SelectedItem}");
            }
        }

        private void ComboBoxCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_comboBoxCategoryFilter.SelectedIndex >= 0)
            {
                var selectedCategory = (MorseRepository.SymbolCategory)_comboBoxCategoryFilter.SelectedIndex;
                _currentSymbols = _morseRepository.GetSymbolsByCategory(selectedCategory);
                RefreshSymbolsTable();
                UpdateStatusBar($"Отображены символы категории: {_comboBoxCategoryFilter.SelectedItem}");
            }
        }

        private void ButtonShowAll_Click(object sender, EventArgs e)
        {
            _currentSymbols = _morseRepository.GetAllSymbols();
            RefreshSymbolsTable();

            _textBoxSearch.Text = "Поиск символа...";
            _textBoxSearch.ForeColor = Color.Gray;
            _comboBoxCategoryFilter.SelectedIndex = 0;

            UpdateStatusBar("Загружены все доступные символы азбуки Морзе");
        }

        private void DataGridViewSymbolsTable_SelectionChanged(object sender, EventArgs e)
        {
            if (_dataGridViewSymbolsTable.SelectedRows.Count > 0)
            {
                var selectedRow = _dataGridViewSymbolsTable.SelectedRows[0];
                // Используем правильное имя колонки
                var selectedCharacter = selectedRow.Cells["dataGridViewTextBoxColumn1"].Value?.ToString();

                if (!string.IsNullOrEmpty(selectedCharacter))
                {
                    var selectedSymbol = _morseRepository.GetSymbolByCharacter(selectedCharacter);
                    if (selectedSymbol != null)
                    {
                        UpdateSymbolDetailsDisplay(selectedSymbol);
                    }
                }
            }
        }

        private void UpdateSymbolDetailsDisplay(MorseSymbol symbol)
        {
            _labelSelectedSymbolDisplay.Text = symbol.Character;
            _labelMorseCodeDisplay.Text = symbol.MorseCode;
            _labelSymbolDescription.Text = symbol.Description;

            // Загрузка и отображение изображения символа
            try
            {
                if (symbol.HasImage && !string.IsNullOrEmpty(symbol.ImagePath))
                {
                    _pictureBoxSymbolImage.Image = Image.FromFile(symbol.ImagePath);
                }
                else
                {
                    _pictureBoxSymbolImage.Image = null;
                }
            }
            catch (Exception ex)
            {
                _pictureBoxSymbolImage.Image = null;
                UpdateStatusBar($"Ошибка загрузки изображения: {ex.Message}");
            }

            // Настройка доступности кнопки воспроизведения звука
            _buttonPlaySound.Enabled = symbol.HasSound;
            _buttonPlaySound.BackColor = symbol.HasSound ? Color.ForestGreen : Color.Gray;

            UpdateStatusBar($"Выбран символ: {symbol.Character} → Код Морзе: {symbol.MorseCode}");
        }

        private async void ButtonPlaySound_Click(object sender, EventArgs e)
        {
            if (_dataGridViewSymbolsTable.SelectedRows.Count > 0)
            {
                var selectedRow = _dataGridViewSymbolsTable.SelectedRows[0];
                // Используем правильное имя колонки
                var selectedCharacter = selectedRow.Cells["dataGridViewTextBoxColumn1"].Value?.ToString();

                if (!string.IsNullOrEmpty(selectedCharacter))
                {
                    var selectedSymbol = _morseRepository.GetSymbolByCharacter(selectedCharacter);
                    if (selectedSymbol != null && selectedSymbol.HasSound)
                    {
                        try
                        {
                            _buttonPlaySound.Enabled = false;
                            _buttonPlaySound.Text = "⏸ Воспроизведение...";
                            _buttonPlaySound.BackColor = Color.Orange;

                            UpdateStatusBar($"Воспроизведение кода Морзе: {selectedSymbol.MorseCode}");

                            await _audioPlayback.PlayMorseSequenceAsync(selectedSymbol.MorseCode);

                            _buttonPlaySound.Text = "▶ Воспроизвести";
                            _buttonPlaySound.BackColor = Color.ForestGreen;
                            UpdateStatusBar($"Воспроизведение завершено: {selectedSymbol.Character}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка воспроизведения звукового сигнала: {ex.Message}",
                                          "Ошибка аудиовоспроизведения",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                            _buttonPlaySound.Text = "❌ Ошибка воспроизведения";
                            _buttonPlaySound.BackColor = Color.Red;
                            UpdateStatusBar("Ошибка при воспроизведении звукового сигнала");
                        }
                        finally
                        {
                            _buttonPlaySound.Enabled = selectedSymbol.HasSound;

                            // Восстановление нормального вида кнопки через 2 секунды
                            await Task.Delay(2000);
                            if (_buttonPlaySound.Text == "❌ Ошибка воспроизведения")
                            {
                                _buttonPlaySound.Text = "▶ Воспроизвести";
                                _buttonPlaySound.BackColor = selectedSymbol.HasSound ? Color.ForestGreen : Color.Gray;
                            }
                        }
                    }
                }
            }
        }

        // Новые обработчики событий для ползунков
        private void TrackBarVolume_Scroll(object sender, EventArgs e)
        {
            UpdateAudioSettings();
            UpdateStatusBar($"Громкость установлена: {_trackBarVolume.Value}%");
        }

        private void TrackBarPitch_Scroll(object sender, EventArgs e)
        {
            UpdateAudioSettings();
            UpdateStatusBar($"Тональность установлена: {_trackBarPitch.Value}Hz");
        }

        private void TrackBarSpeed_Scroll(object sender, EventArgs e)
        {
            UpdateAudioSettings();
            UpdateStatusBar($"Скорость установлена: {_trackBarSpeed.Value}%");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Безопасное освобождение ресурсов
            if (_audioPlayback != null)
            {
                _audioPlayback.Dispose();
                _audioPlayback = null;
            }

            UpdateStatusBar("Завершение работы приложения...");
        }
    }
}
