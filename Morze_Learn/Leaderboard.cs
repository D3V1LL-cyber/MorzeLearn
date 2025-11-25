using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YourNamespace
{
    public static class Leaderboard
    {
        private static List<LeaderboardEntry> _entries = new List<LeaderboardEntry>();
        private static string _dataFile = "leaderboard.dat";

        static Leaderboard()
        {
            LoadFromFile();
        }

        public static void AddResult(string userName, int score, int maxScore, double percentage, string category, DateTime date)
        {
            _entries.Add(new LeaderboardEntry
            {
                UserName = userName,
                Score = score,
                MaxScore = maxScore,
                Percentage = percentage,
                Category = category,
                Date = date
            });

            SaveToFile();

            _entries.Sort((a, b) => b.Percentage.CompareTo(a.Percentage));
        }

        public static List<LeaderboardEntry> GetTopResults(int count = 20)
        {
            return _entries
                .OrderByDescending(e => e.Percentage)
                .ThenByDescending(e => e.Score)
                .Take(count)
                .ToList();
        }

        public static List<LeaderboardEntry> GetAllResults()
        {
            return new List<LeaderboardEntry>(_entries);
        }

        public static List<LeaderboardEntry> GetResultsByUser(string userName)
        {
            return _entries
                .Where(e => e.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(e => e.Date)
                .ToList();
        }

        public static void ClearAllResults()
        {
            var result = MessageBox.Show("Вы уверены, что хотите очистить всю таблицу лидеров?",
                                       "Подтверждение очистки",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _entries.Clear();
                SaveToFile();
            }
        }

        private static void SaveToFile()
        {
            try
            {
                using (var writer = new StreamWriter(_dataFile, false, Encoding.UTF8))
                {
                    foreach (var entry in _entries)
                    {
                        writer.WriteLine($"{entry.UserName}|{entry.Score}|{entry.MaxScore}|{entry.Percentage}|{entry.Category}|{entry.Date:yyyy-MM-dd HH:mm:ss}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении таблицы лидеров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void LoadFromFile()
        {
            if (!File.Exists(_dataFile))
                return;

            try
            {
                _entries.Clear();
                using (var reader = new StreamReader(_dataFile, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 6)
                        {
                            _entries.Add(new LeaderboardEntry
                            {
                                UserName = parts[0],
                                Score = int.Parse(parts[1]),
                                MaxScore = int.Parse(parts[2]),
                                Percentage = double.Parse(parts[3]),
                                Category = parts[4],
                                Date = DateTime.ParseExact(parts[5], "yyyy-MM-dd HH:mm:ss", null)
                            });
                        }
                    }
                }

                _entries.Sort((a, b) => b.Percentage.CompareTo(a.Percentage));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке таблицы лидеров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class LeaderboardEntry
    {
        public string UserName { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public double Percentage { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{UserName}: {Score}/{MaxScore} ({Percentage:0}%) - {Category} - {Date:dd.MM.yyyy HH:mm}";
        }
    }
}
