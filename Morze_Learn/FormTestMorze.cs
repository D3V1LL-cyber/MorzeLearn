using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace YourNamespace
{
    public partial class FormTestMorze : Form
    {
        private List<Question> _questions;
        private List<Question> _allQuestions;
        private int _currentQuestionIndex = 0;
        private int _score = 0;
        private int _questionsAsked = 0;
        private const int MaxQuestions = 10;
        private bool _isPaused = false;
        private string _currentUserName;

        // Группы символов
        private Dictionary<string, bool> _selectedGroups = new Dictionary<string, bool>
        {
            { "latin", true },
            { "russian", true },
            { "numbers", true },
            { "symbols", true }
        };

        public FormTestMorze(string userName = "Аноним")
        {
            _currentUserName = userName;
            InitializeComponent();
            InitializeAllQuestions();
            InitializeQuestions();
            ShuffleQuestions();
            LoadQuestion();
            UpdateProgressBar();
            UpdateStatus();
        }

        private void InitializeAllQuestions()
        {
            _allQuestions = new List<Question>
            {
                // Латинские буквы
                new Question("Что означает код .- ?", "A", "latin"),
                new Question("Что означает код -...", "B", "latin"),
                new Question("Что означает код -.-.", "C", "latin"),
                new Question("Что означает код -..", "D", "latin"),
                new Question("Что означает код .", "E", "latin"),
                new Question("Что означает код ..-.", "F", "latin"),
                new Question("Что означает код --.", "G", "latin"),
                new Question("Что означает код ....", "H", "latin"),
                new Question("Что означает код ..", "I", "latin"),
                new Question("Что означает код .---", "J", "latin"),
                new Question("Что означает код -.-", "K", "latin"),
                new Question("Что означает код .-..", "L", "latin"),
                new Question("Что означает код --", "M", "latin"),
                new Question("Что означает код -.", "N", "latin"),
                new Question("Что означает код ---", "O", "latin"),
                new Question("Что означает код .--.", "P", "latin"),
                new Question("Что означает код --.-", "Q", "latin"),
                new Question("Что означает код .-.", "R", "latin"),
                new Question("Что означает код ...", "S", "latin"),
                new Question("Что означает код -", "T", "latin"),
                new Question("Что означает код ..-", "U", "latin"),
                new Question("Что означает код ...-", "V", "latin"),
                new Question("Что означает код .--", "W", "latin"),
                new Question("Что означает код -..-", "X", "latin"),
                new Question("Что означает код -.--", "Y", "latin"),
                new Question("Что означает код --..", "Z", "latin"),
                
                // Цифры
                new Question("Что означает код .---- ?", "1", "numbers"),
                new Question("Что означает код ..--- ?", "2", "numbers"),
                new Question("Что означает код ...-- ?", "3", "numbers"),
                new Question("Что означает код ....- ?", "4", "numbers"),
                new Question("Что означает код ..... ?", "5", "numbers"),
                new Question("Что означает код -.... ?", "6", "numbers"),
                new Question("Что означает код --... ?", "7", "numbers"),
                new Question("Что означает код ---.. ?", "8", "numbers"),
                new Question("Что означает код ----. ?", "9", "numbers"),
                new Question("Что означает код ----- ?", "0", "numbers"),
                
                // Русские буквы
                new Question("Что означает код .- ?", "А", "russian"),
                new Question("Что означает код -...", "Б", "russian"),
                new Question("Что означает код .--", "В", "russian"),
                new Question("Что означает код --.", "Г", "russian"),
                new Question("Что означает код -..", "Д", "russian"),
                new Question("Что означает код .", "Е", "russian"),
                new Question("Что означает код ...-", "Ж", "russian"),
                new Question("Что означает код --..", "З", "russian"),
                new Question("Что означает код ..", "И", "russian"),
                new Question("Что означает код .---", "Й", "russian"),
                new Question("Что означает код -.-", "К", "russian"),
                new Question("Что означает код .-..", "Л", "russian"),
                new Question("Что означает код --", "М", "russian"),
                new Question("Что означает код -.", "Н", "russian"),
                new Question("Что означает код ---", "О", "russian"),
                new Question("Что означает код .--.", "П", "russian"),
                new Question("Что означает код .-.", "Р", "russian"),
                new Question("Что означает код ...", "С", "russian"),
                new Question("Что означает код -", "Т", "russian"),
                new Question("Что означает код ..-", "У", "russian"),
                new Question("Что означает код ..-.", "Ф", "russian"),
                new Question("Что означает код ....", "Х", "russian"),
                new Question("Что означает код -.-.", "Ц", "russian"),
                new Question("Что означает код ---.", "Ч", "russian"),
                new Question("Что означает код ----", "Ш", "russian"),
                new Question("Что означает код --.-", "Щ", "russian"),
                new Question("Что означает код --.--", "Ъ", "russian"),
                new Question("Что означает код -.--", "Ы", "russian"),
                new Question("Что означает код -..-", "Ь", "russian"),
                new Question("Что означает код ..-..", "Э", "russian"),
                new Question("Что означает код ..--", "Ю", "russian"),
                new Question("Что означает код .-.-", "Я", "russian"),
                
                // Знаки препинания и специальные сигналы
                new Question("Что означает код .-.-.- ?", ".", "symbols"),
                new Question("Что означает код --..-- ?", ",", "symbols"),
                new Question("Что означает код ..--.. ?", "?", "symbols"),
                new Question("Что означает код -.-.-- ?", "!", "symbols"),
                new Question("Что означает код ---...", ":", "symbols"),
                new Question("Что означает код -.-.-.", ";", "symbols"),
                new Question("Что означает код -..-.", "/", "symbols"),
                new Question("Что означает код .----.", "'", "symbols"),
                new Question("Что означает код .-..-.", "\"", "symbols"),
                new Question("Что означает код -...-", "=", "symbols"),
                new Question("Что означает код ...-..- ?", "$", "symbols"),
                new Question("Что означает код .--.-. ?", "@", "symbols"),
                new Question("Что означает код ...---...", "SOS", "symbols"),
                new Question("Код для паузы или разделения слов", "/", "symbols")
            };
        }

        private void InitializeQuestions()
        {
            _questions = new List<Question>();

            // Фильтруем вопросы по выбранным группам
            foreach (var question in _allQuestions)
            {
                if (_selectedGroups.ContainsKey(question.Category) && _selectedGroups[question.Category])
                {
                    _questions.Add(question);
                }
            }

            // Если ничего не выбрано, используем все вопросы
            if (_questions.Count == 0)
            {
                _questions = new List<Question>(_allQuestions);
                // Сбрасываем выбор на все группы
                foreach (var key in _selectedGroups.Keys.ToList())
                {
                    _selectedGroups[key] = true;
                }
                UpdateCheckboxes();
            }
        }

        private void UpdateCheckboxes()
        {
            checkBoxLatin.Checked = _selectedGroups["latin"];
            checkBoxRussian.Checked = _selectedGroups["russian"];
            checkBoxNumbers.Checked = _selectedGroups["numbers"];
            checkBoxSymbols.Checked = _selectedGroups["symbols"];
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                string group = checkBox.Tag.ToString();
                _selectedGroups[group] = checkBox.Checked;
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var key in _selectedGroups.Keys.ToList())
            {
                _selectedGroups[key] = true;
            }
            UpdateCheckboxes();
        }

        private void BtnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (var key in _selectedGroups.Keys.ToList())
            {
                _selectedGroups[key] = false;
            }
            UpdateCheckboxes();
        }

        private void TextBoxAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnNext_Click(sender, e);
                e.Handled = true;
            }
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
                labelQuestion.Text = _questions[_currentQuestionIndex].Text;
                textBoxAnswer.Text = "";
                textBoxAnswer.Focus();
                _currentQuestionIndex++;
                _questionsAsked++;
                UpdateProgressBar();
                UpdateStatus();
            }
        }

        private void UpdateProgressBar()
        {
            progressBar.Value = _questionsAsked;
        }

        private void UpdateStatus()
        {
            int selectedGroupsCount = _selectedGroups.Count(kv => kv.Value);
            string groupsText = selectedGroupsCount == 4 ? "Все группы" : $"{selectedGroupsCount} групп";
            labelStatus.Text = $"Пользователь: {_currentUserName} | {groupsText} | Вопрос {_questionsAsked} из {MaxQuestions} | Правильных ответов: {_score}";
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_isPaused) return;

            if (_currentQuestionIndex > 0 && _currentQuestionIndex - 1 < _questions.Count)
            {
                string userAnswer = textBoxAnswer.Text.Trim().ToUpper();
                string correctAnswer = _questions[_currentQuestionIndex - 1].Answer.ToUpper();

                if (userAnswer == correctAnswer)
                {
                    _score++;
                }
            }

            LoadQuestion();
        }

        private void ShowResults()
        {
            labelQuestion.Visible = false;
            textBoxAnswer.Visible = false;
            buttonNext.Visible = false;
            buttonPause.Visible = false;
            progressBar.Visible = false;
            groupBoxSelection.Enabled = true;

            labelResult.Text = $"ТЕСТ ЗАВЕРШЕН!\n\nПользователь: {_currentUserName}\nВаш результат: {_score} из {MaxQuestions}\n\n";

            double percentage = (_score * 100.0) / MaxQuestions;
            if (percentage >= 90)
                labelResult.Text += "Отлично! Вы прекрасно знаете азбуку Морзе! 🎉";
            else if (percentage >= 70)
                labelResult.Text += "Хорошо! Продолжайте практиковаться! 👍";
            else if (percentage >= 50)
                labelResult.Text += "Удовлетворительно. Рекомендуется повторить материал. 📚";
            else
                labelResult.Text += "Нужно больше практики. Не сдавайтесь! 💪";

            labelResult.Visible = true;

            int selectedGroupsCount = _selectedGroups.Count(kv => kv.Value);
            string groupsText = selectedGroupsCount == 4 ? "Все группы" : $"{selectedGroupsCount} групп";
            labelStatus.Text = $"Тест завершен. Пользователь: {_currentUserName} | {groupsText} | Результат: {_score}/{MaxQuestions} ({percentage:0}%)";

        }



        private void BtnPause_Click(object sender, EventArgs e)
        {
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                buttonPause.BackColor = Color.ForestGreen;
                buttonPause.Text = "▶ Продолжить";
                textBoxAnswer.Enabled = false;
                buttonNext.Enabled = false;
                buttonRestart.Enabled = false;
                buttonLeaderboard.Enabled = false;
                groupBoxSelection.Enabled = false;
                labelStatus.Text = "Тест приостановлен...";
            }
            else
            {
                buttonPause.BackColor = Color.Orange;
                buttonPause.Text = "⏸ Пауза";
                textBoxAnswer.Enabled = true;
                buttonNext.Enabled = true;
                buttonRestart.Enabled = true;
                buttonLeaderboard.Enabled = true;
                groupBoxSelection.Enabled = true;
                UpdateStatus();
                textBoxAnswer.Focus();
            }
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана хотя бы одна группа
            if (!_selectedGroups.Any(kv => kv.Value))
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы одну группу символов для тестирования.", "Выбор групп",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentQuestionIndex = 0;
            _score = 0;
            _questionsAsked = 0;
            _isPaused = false;

            InitializeQuestions();
            ShuffleQuestions();

            labelQuestion.Visible = true;
            textBoxAnswer.Visible = true;
            buttonNext.Visible = true;
            buttonPause.Visible = true;
            progressBar.Visible = true;
            labelResult.Visible = false;

            buttonPause.BackColor = Color.Orange;
            buttonPause.Text = "⏸ Пауза";
            textBoxAnswer.Enabled = true;
            buttonNext.Enabled = true;
            buttonRestart.Enabled = true;
            buttonLeaderboard.Enabled = true;
            groupBoxSelection.Enabled = true;

            LoadQuestion();
            UpdateProgressBar();
            UpdateStatus();
            textBoxAnswer.Focus();
        }

         private void FormTestMorze_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private class Question
        {
            public string Text { get; }
            public string Answer { get; }
            public string Category { get; }

            public Question(string text, string answer, string category)
            {
                Text = text;
                Answer = answer;
                Category = category;
            }
        }
    }
}
