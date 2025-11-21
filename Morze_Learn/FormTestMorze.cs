using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YourNamespace
{
    public partial class FormTestMorze : Form
    {
        private List<Question> _questions;
        private int _currentQuestionIndex = 0;
        private int _score = 0;

        public FormTestMorze()
        {
            InitializeComponent();
            InitializeQuestions();
            ShuffleQuestions(); // Перемешиваем вопросы
            LoadQuestion();
        }

        private void InitializeQuestions()
        {
            _questions = new List<Question>
            {
                // Вопросы по английским буквам
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
                new Question("Что означает код .-.- ?", "А"),
                new Question("Что означает код -...-", "Б"),
                new Question("Что означает код .--.-", "В"),
                new Question("Что означает код --.--", "Г"),
                new Question("Что означает код -..-.", "Д"),
                new Question("Что означает код .", "Е"),
                new Question("Что означает код ...-.", "Ж"),
                new Question("Что означает код --..", "З"),
                new Question("Что означает код ..", "И"),
                new Question("Что означает код .---", "Й"),
                new Question("Что означает код -.-", "К"),
                new Question("Что означает код .-..", "Л"),
                new Question("Что означает код --", "М"),
                new Question("Что означает код -.", "Н"),
                new Question("Что означает код --.-", "О"),
                new Question("Что означает код .--", "П"),
                new Question("Что означает код .-.-", "Р"),
                new Question("Что означает код ...", "С"),
                new Question("Что означает код -", "Т"),
                new Question("Что означает код ..-", "У"),
                new Question("Что означает код ...-.", "Ф"),
                new Question("Что означает код --.-", "Х"),
                new Question("Что означает код -.--", "Ц"),
                new Question("Что означает код .--.-", "Ч"),
                new Question("Что означает код ---.", "Ш"),
                new Question("Что означает код ----", "Щ"),
                new Question("Что означает код --.--", "Ъ"),
                new Question("Что означает код -.--", "Ы"),
                new Question("Что означает код -.--.", "Ь"),
                new Question("Что означает код .-...", "Э"),
                new Question("Что означает код ...-..-", "Ю"),
                new Question("Что означает код ..--", "Я"),

                // Знаки препинания и специальные сигналы
                new Question("Что означает код .-.-.- ?", "."),
                new Question("Что означает код --..-- ?", ","),
                new Question("Что означает код ..--.. ?", "?"),
                new Question("Что означает код -.-.-- ?", "!"),
                new Question("Что означает код .-...", ":"),
                new Question("Что означает код -.-.-.", ";"),
                new Question("Что означает код -..-.", "/"),
                new Question("Что означает код -.--.", "'"),
                new Question("Что означает код -.--.", "\""),
                new Question("Что означает код .-...", "="),
                new Question("Что означает код ...-..- ?", "$"),
                new Question("Что означает код .--.-. ?", "@"),
                new Question("Что означает код ...---...", "SOS"),
                new Question("Код для паузы или разделения слов — /", "/")
            };
        }

        // Метод для перемешивания вопросов
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
            if (_currentQuestionIndex < _questions.Count)
            {
                lblQuestion.Text = _questions[_currentQuestionIndex].Text;
                txtAnswer.Text = "";
                txtAnswer.Focus();
            }
            else
            {
                // Тест завершен
                ShowResults();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_currentQuestionIndex >= _questions.Count)
                return;

            string userAnswer = txtAnswer.Text.Trim().ToUpper();
            string correctAnswer = _questions[_currentQuestionIndex].Answer.ToUpper();

            if (userAnswer == correctAnswer)
            {
                _score++;
            }

            _currentQuestionIndex++;
            UpdateProgress();
            LoadQuestion();
        }

        private void UpdateProgress()
        {
            double progress = ((double)_currentQuestionIndex / _questions.Count) * 100;
            progressBar.Value = Math.Min((int)progress, 100);
        }

        private void ShowResults()
        {
            lblQuestion.Visible = false;
            txtAnswer.Visible = false;
            btnNext.Visible = false;
            progressBar.Visible = false;

            lblResult.Text = $"Тест завершен!\nВаш результат: {_score} из {_questions.Count}";
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
    }
}