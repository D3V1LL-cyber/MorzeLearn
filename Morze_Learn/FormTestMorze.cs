using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace YourNamespace
{
    public partial class FormTestMorze : Form
    {
        private List<Question> _questions;
        private int _currentQuestionIndex = 0;
        private int _score = 0;
        private int _questionsAsked = 0;
        private const int MaxQuestions = 10;
        private bool _isPaused = false;

        // Элементы управления в стиле Form1
        private Label _labelTestTitle;
        private Label _labelQuestion;
        private TextBox _textBoxAnswer;
        private Button _buttonNext;
        private Button _buttonPause;
        private ProgressBar _progressBar;
        private Label _labelResult;
        private Label _labelStatus;
        private Panel _panelMain;

        public FormTestMorze()
        {
            InitializeComponent();
            InitializeQuestions();
            ShuffleQuestions();
            LoadQuestion();
            UpdateProgressBar();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Основная панель
            this._panelMain = new Panel();
            this._panelMain.BackColor = Color.AliceBlue;
            this._panelMain.BorderStyle = BorderStyle.FixedSingle;
            this._panelMain.Dock = DockStyle.Fill;

            // Заголовок теста
            this._labelTestTitle = new Label();
            this._labelTestTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this._labelTestTitle.ForeColor = Color.DarkBlue;
            this._labelTestTitle.Text = "ТЕСТ ПО АЗБУКЕ МОРЗЕ";
            this._labelTestTitle.TextAlign = ContentAlignment.MiddleCenter;
            this._labelTestTitle.Dock = DockStyle.Top;
            this._labelTestTitle.Height = 50;

            // Метка вопроса
            this._labelQuestion = new Label();
            this._labelQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this._labelQuestion.ForeColor = Color.DarkSlateGray;
            this._labelQuestion.TextAlign = ContentAlignment.MiddleLeft;
            this._labelQuestion.Dock = DockStyle.Top;
            this._labelQuestion.Height = 60;
            this._labelQuestion.Padding = new Padding(20, 10, 20, 10);

            // Поле для ответа
            this._textBoxAnswer = new TextBox();
            this._textBoxAnswer.Font = new Font("Segoe UI", 12F);
            this._textBoxAnswer.Dock = DockStyle.Top;
            this._textBoxAnswer.Height = 35;
            this._textBoxAnswer.Margin = new Padding(20, 0, 20, 10);

            // Панель для кнопок
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Top;
            buttonPanel.Height = 50;
            buttonPanel.Padding = new Padding(20, 5, 20, 5);

            // Кнопка "Далее"
            this._buttonNext = new Button();
            this._buttonNext.BackColor = Color.SteelBlue;
            this._buttonNext.FlatStyle = FlatStyle.Flat;
            this._buttonNext.ForeColor = Color.White;
            this._buttonNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this._buttonNext.Text = "Далее →";
            this._buttonNext.Size = new Size(120, 35);
            this._buttonNext.Click += new EventHandler(this.BtnNext_Click);

            // Кнопка "Пауза"
            this._buttonPause = new Button();
            this._buttonPause.BackColor = Color.Orange;
            this._buttonPause.FlatStyle = FlatStyle.Flat;
            this._buttonPause.ForeColor = Color.White;
            this._buttonPause.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this._buttonPause.Text = "⏸ Пауза";
            this._buttonPause.Size = new Size(120, 35);
            this._buttonPause.Click += new EventHandler(this.BtnPause_Click);

            // Размещаем кнопки на панели
            buttonPanel.Controls.Add(_buttonNext);
            buttonPanel.Controls.Add(_buttonPause);
            _buttonNext.Location = new Point(0, 5);
            _buttonPause.Location = new Point(130, 5);

            // Прогресс-бар
            this._progressBar = new ProgressBar();
            this._progressBar.Dock = DockStyle.Top;
            this._progressBar.Height = 25;
            this._progressBar.ForeColor = Color.CornflowerBlue;
            this._progressBar.Maximum = MaxQuestions;

            // Метка результата
            this._labelResult = new Label();
            this._labelResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this._labelResult.ForeColor = Color.DarkGreen;
            this._labelResult.TextAlign = ContentAlignment.MiddleCenter;
            this._labelResult.Dock = DockStyle.Fill;
            this._labelResult.Visible = false;

            // Статусная строка
            this._labelStatus = new Label();
            this._labelStatus.Font = new Font("Segoe UI", 9F);
            this._labelStatus.ForeColor = Color.Gray;
            this._labelStatus.TextAlign = ContentAlignment.MiddleLeft;
            this._labelStatus.Dock = DockStyle.Bottom;
            this._labelStatus.Height = 25;
            this._labelStatus.Padding = new Padding(10, 0, 0, 0);
            this._labelStatus.Text = "Готов к тестированию...";

            // Добавляем элементы на основную панель
            this._panelMain.Controls.Add(_labelResult);
            this._panelMain.Controls.Add(_progressBar);
            this._panelMain.Controls.Add(buttonPanel);
            this._panelMain.Controls.Add(_textBoxAnswer);
            this._panelMain.Controls.Add(_labelQuestion);
            this._panelMain.Controls.Add(_labelTestTitle);
            this._panelMain.Controls.Add(_labelStatus);

            // Настройка формы
            this.BackColor = Color.White;
            this.Controls.Add(_panelMain);
            this.Size = new Size(600, 400);
            this.MinimumSize = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Тест по азбуке Морзе - Обучающее Приложение";

            this.ResumeLayout(false);
        }

        private void InitializeQuestions()
        {
            _questions = new List<Question>
            {
                // Латинские буквы
                new Question("Что означает код .- ?", "A"),
                new Question("Что означает код -...", "B"),
                new Question("Что означает код -.-.", "C"),
                new Question("Что означает код -..", "D"),
                new Question("Что означает код .", "E"),
                new Question("Что означает код ..-.", "F"),
                new Question("Что означает код --.", "G"),
                new Question("Что означает код ....", "H"),
                new Question("Что означает код ..", "I"),
                new Question("Что означает код .---", "J"),
                new Question("Что означает код -.-", "K"),
                new Question("Что означает код .-..", "L"),
                new Question("Что означает код --", "M"),
                new Question("Что означает код -.", "N"),
                new Question("Что означает код ---", "O"),
                new Question("Что означает код .--.", "P"),
                new Question("Что означает код --.-", "Q"),
                new Question("Что означает код .-.", "R"),
                new Question("Что означает код ...", "S"),
                new Question("Что означает код -", "T"),
                new Question("Что означает код ..-", "U"),
                new Question("Что означает код ...-", "V"),
                new Question("Что означает код .--", "W"),
                new Question("Что означает код -..-", "X"),
                new Question("Что означает код -.--", "Y"),
                new Question("Что означает код --..", "Z"),
                
                // Цифры
                new Question("Что означает код .---- ?", "1"),
                new Question("Что означает код ..--- ?", "2"),
                new Question("Что означает код ...-- ?", "3"),
                new Question("Что означает код ....- ?", "4"),
                new Question("Что означает код ..... ?", "5"),
                new Question("Что означает код -.... ?", "6"),
                new Question("Что означает код --... ?", "7"),
                new Question("Что означает код ---.. ?", "8"),
                new Question("Что означает код ----. ?", "9"),
                new Question("Что означает код ----- ?", "0"),
                
                // Русские буквы
                new Question("Что означает код .- ?", "А"),
                new Question("Что означает код -...", "Б"),
                new Question("Что означает код .--", "В"),
                new Question("Что означает код --.", "Г"),
                new Question("Что означает код -..", "Д"),
                new Question("Что означает код .", "Е"),
                new Question("Что означает код ...-", "Ж"),
                new Question("Что означает код --..", "З"),
                new Question("Что означает код ..", "И"),
                new Question("Что означает код .---", "Й"),
                new Question("Что означает код -.-", "К"),
                new Question("Что означает код .-..", "Л"),
                new Question("Что означает код --", "М"),
                new Question("Что означает код -.", "Н"),
                new Question("Что означает код ---", "О"),
                new Question("Что означает код .--.", "П"),
                new Question("Что означает код .-.", "Р"),
                new Question("Что означает код ...", "С"),
                new Question("Что означает код -", "Т"),
                new Question("Что означает код ..-", "У"),
                new Question("Что означает код ..-.", "Ф"),
                new Question("Что означает код ....", "Х"),
                new Question("Что означает код -.-.", "Ц"),
                new Question("Что означает код ---.", "Ч"),
                new Question("Что означает код ----", "Ш"),
                new Question("Что означает код --.-", "Щ"),
                new Question("Что означает код --.--", "Ъ"),
                new Question("Что означает код -.--", "Ы"),
                new Question("Что означает код -..-", "Ь"),
                new Question("Что означает код ..-..", "Э"),
                new Question("Что означает код ..--", "Ю"),
                new Question("Что означает код .-.-", "Я"),
                
                // Знаки препинания и специальные сигналы
                new Question("Что означает код .-.-.- ?", "."),
                new Question("Что означает код --..-- ?", ","),
                new Question("Что означает код ..--.. ?", "?"),
                new Question("Что означает код -.-.-- ?", "!"),
                new Question("Что означает код ---...", ":"),
                new Question("Что означает код -.-.-.", ";"),
                new Question("Что означает код -..-.", "/"),
                new Question("Что означает код .----.", "'"),
                new Question("Что означает код .-..-.", "\""),
                new Question("Что означает код -...-", "="),
                new Question("Что означает код ...-..- ?", "$"),
                new Question("Что означает код .--.-. ?", "@"),
                new Question("Что означает код ...---...", "SOS"),
                new Question("Код для паузы или разделения слов", "/")
            };
        }

        private void ShuffleQuestions()
        {
            Random rnd = new Random();
            int n = _questions.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int j = rnd.Next(i, n);
                var temp = _questions[i];
                _questions[i] = _questions[j];
                _questions[j] = temp;
            }
        }

        private void LoadQuestion()
        {
            if (_questionsAsked >= MaxQuestions || _currentQuestionIndex >= _questions.Count)
            {
                ShowResults();
                return;
            }

            if (_currentQuestionIndex < _questions.Count)
            {
                _labelQuestion.Text = _questions[_currentQuestionIndex].Text;
                _textBoxAnswer.Text = "";
                _textBoxAnswer.Focus();
                _currentQuestionIndex++;
                _questionsAsked++;
                UpdateProgressBar();
                UpdateStatus();
            }
        }

        private void UpdateProgressBar()
        {
            _progressBar.Value = _questionsAsked;
        }

        private void UpdateStatus()
        {
            _labelStatus.Text = $"Вопрос {_questionsAsked} из {MaxQuestions} | Правильных ответов: {_score}";
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_isPaused) return;

            string userAnswer = _textBoxAnswer.Text.Trim().ToUpper();
            string correctAnswer = _questions[_currentQuestionIndex - 1].Answer.ToUpper();

            if (userAnswer == correctAnswer)
            {
                _score++;
            }

            LoadQuestion();
        }

        private void ShowResults()
        {
            _labelQuestion.Visible = false;
            _textBoxAnswer.Visible = false;
            _buttonNext.Visible = false;
            _buttonPause.Visible = false;
            _progressBar.Visible = false;

            _labelResult.Text = $"ТЕСТ ЗАВЕРШЕН!\n\nВаш результат: {_score} из {MaxQuestions}\n\n";

            double percentage = (_score * 100.0) / MaxQuestions;
            if (percentage >= 90)
                _labelResult.Text += "Отлично! Вы прекрасно знаете азбуку Морзе! 🎉";
            else if (percentage >= 70)
                _labelResult.Text += "Хорошо! Продолжайте практиковаться! 👍";
            else if (percentage >= 50)
                _labelResult.Text += "Удовлетворительно. Рекомендуется повторить материал. 📚";
            else
                _labelResult.Text += "Нужно больше практики. Не сдавайтесь! 💪";

            _labelResult.Visible = true;
            _labelStatus.Text = $"Тест завершен. Результат: {_score}/{MaxQuestions} ({percentage:0}%)";
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                _buttonPause.BackColor = Color.ForestGreen;
                _buttonPause.Text = "▶ Продолжить";
                _textBoxAnswer.Enabled = false;
                _buttonNext.Enabled = false;
                _labelStatus.Text = "Тест приостановлен...";
            }
            else
            {
                _buttonPause.BackColor = Color.Orange;
                _buttonPause.Text = "⏸ Пауза";
                _textBoxAnswer.Enabled = true;
                _buttonNext.Enabled = true;
                UpdateStatus();
                _textBoxAnswer.Focus();
            }
        }

        private class Question
        {
            public string Text { get; }
            public string Answer { get; }

            public Question(string text, string answer)
            {
                Text = text;
                Answer = answer;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (_questionsAsked < MaxQuestions && _questionsAsked > 0)
            {
                var result = MessageBox.Show("Тест еще не завершен. Вы действительно хотите выйти?",
                                           "Подтверждение выхода",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
