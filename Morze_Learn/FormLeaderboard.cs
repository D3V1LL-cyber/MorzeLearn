using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace YourNamespace
{
    public partial class FormLeaderboard : Form
    {
        public FormLeaderboard()
        {
            InitializeComponent();
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            _listBoxLeaderboard.Items.Clear();

            var allResults = Leaderboard.GetAllResults();

            if (allResults.Count == 0)
            {
                _listBoxLeaderboard.Items.Add("");
                _listBoxLeaderboard.Items.Add("    Пока нет результатов для отображения.");
                _listBoxLeaderboard.Items.Add("    Пройдите тест, чтобы появиться в таблице лидеров!");
                _listBoxLeaderboard.Items.Add("");
                return;
            }

            var filteredResults = FilterResults(allResults);

            var sortedResults = filteredResults
                .OrderByDescending(r => r.Percentage)
                .ThenByDescending(r => r.Score)
                .ThenBy(r => r.Date)
                .Take(20)
                .ToList();

            // Заголовок таблицы
            _listBoxLeaderboard.Items.Add("┌─────┬──────────────────────┬────────────┬──────────┬─────────────────────┐");
            _listBoxLeaderboard.Items.Add("│ Место │ Имя пользователя      │ Результат  │ Категория │ Дата               │");
            _listBoxLeaderboard.Items.Add("├─────┼──────────────────────┼────────────┼──────────┼─────────────────────┤");

            // Данные
            for (int i = 0; i < sortedResults.Count; i++)
            {
                var entry = sortedResults[i];
                string place = GetPlaceEmoji(i + 1) + $" {i + 1,2}";
                string userName = entry.UserName.Length > 18 ? entry.UserName.Substring(0, 15) + "..." : entry.UserName.PadRight(18);
                string result = $"{entry.Score,2}/{entry.MaxScore} ({entry.Percentage:0}%)";
                string category = GetShortCategory(entry.Category);
                string date = entry.Date.ToString("dd.MM.yy HH:mm");

                _listBoxLeaderboard.Items.Add($"│ {place} │ {userName} │ {result} │ {category,-8} │ {date} │");
            }

            _listBoxLeaderboard.Items.Add("└─────┴──────────────────────┴────────────┴──────────┴─────────────────────┘");

            // Статистика
            _listBoxLeaderboard.Items.Add("");
            if (sortedResults.Count > 0)
            {
                _listBoxLeaderboard.Items.Add($"Всего результатов: {filteredResults.Count} | Лучший результат: {sortedResults.First().Percentage:0}%");
            }
        }

        private string GetPlaceEmoji(int place)
        {
            switch (place)
            {
                case 1: return "🥇";
                case 2: return "🥈";
                case 3: return "🥉";
                default: return "  ";
            }
        }

        private string GetShortCategory(string category)
        {
            switch (category.ToLower())
            {
                case "all": return "Все";
                case "latin": return "Лат.";
                case "russian": return "Рус.";
                case "numbers": return "Цифры";
                case "symbols": return "Симв.";
                default: return category;
            }
        }

        private List<LeaderboardEntry> FilterResults(List<LeaderboardEntry> results)
        {
            string selectedFilter = _comboBoxFilter.SelectedItem.ToString();

            switch (selectedFilter)
            {
                case "Все категории":
                    return results;
                case "Все символы":
                    return results.Where(r => r.Category.ToLower() == "all").ToList();
                case "Латинские буквы":
                    return results.Where(r => r.Category.ToLower() == "latin").ToList();
                case "Русские буквы":
                    return results.Where(r => r.Category.ToLower() == "russian").ToList();
                case "Цифры":
                    return results.Where(r => r.Category.ToLower() == "numbers").ToList();
                case "Символы":
                    return results.Where(r => r.Category.ToLower() == "symbols").ToList();
                default:
                    return results;
            }
        }

        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLeaderboard();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadLeaderboard();

            // Анимация обновления
            _buttonRefresh.Text = "✓ Обновлено";
            _buttonRefresh.BackColor = Color.ForestGreen;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, args) =>
            {
                _buttonRefresh.Text = "🔄 Обновить";
                _buttonRefresh.BackColor = Color.SteelBlue;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _listBoxLeaderboard.Focus();
        }
    }
}
