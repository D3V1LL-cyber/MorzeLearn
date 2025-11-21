using System;
using System.Collections.Generic;
using System.Linq;

namespace Morze_Learn
{
    public class MorseRepository
    {
        private List<MorseSymbol> _symbols;

        public enum SymbolCategory
        {
            All,
            LatinLetters,
            Numbers,
            Punctuation,
            SpecialSignals
        }

        public MorseRepository()
        {
            _symbols = new List<MorseSymbol>();
            InitializeDefaultData();
        }

        private void InitializeDefaultData()
        {
            // Латинские буквы
            _symbols.Add(new MorseSymbol { Character = "A", MorseCode = ".-", Category = SymbolCategory.LatinLetters, Description = "Латинская буква A", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "B", MorseCode = "-...", Category = SymbolCategory.LatinLetters, Description = "Латинская буква B", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "C", MorseCode = "-.-.", Category = SymbolCategory.LatinLetters, Description = "Латинская буква C", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "D", MorseCode = "-..", Category = SymbolCategory.LatinLetters, Description = "Латинская буква D", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "E", MorseCode = ".", Category = SymbolCategory.LatinLetters, Description = "Латинская буква E", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "F", MorseCode = "..-.", Category = SymbolCategory.LatinLetters, Description = "Латинская буква F", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "G", MorseCode = "--.", Category = SymbolCategory.LatinLetters, Description = "Латинская буква G", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "H", MorseCode = "....", Category = SymbolCategory.LatinLetters, Description = "Латинская буква H", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "I", MorseCode = "..", Category = SymbolCategory.LatinLetters, Description = "Латинская буква I", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "J", MorseCode = ".---", Category = SymbolCategory.LatinLetters, Description = "Латинская буква J", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "K", MorseCode = "-.-", Category = SymbolCategory.LatinLetters, Description = "Латинская буква K", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "L", MorseCode = ".-..", Category = SymbolCategory.LatinLetters, Description = "Латинская буква L", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "M", MorseCode = "--", Category = SymbolCategory.LatinLetters, Description = "Латинская буква M", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "N", MorseCode = "-.", Category = SymbolCategory.LatinLetters, Description = "Латинская буква N", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "O", MorseCode = "---", Category = SymbolCategory.LatinLetters, Description = "Латинская буква O", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "P", MorseCode = ".--.", Category = SymbolCategory.LatinLetters, Description = "Латинская буква P", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "Q", MorseCode = "--.-", Category = SymbolCategory.LatinLetters, Description = "Латинская буква Q", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "R", MorseCode = ".-.", Category = SymbolCategory.LatinLetters, Description = "Латинская буква R", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "S", MorseCode = "...", Category = SymbolCategory.LatinLetters, Description = "Латинская буква S", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "T", MorseCode = "-", Category = SymbolCategory.LatinLetters, Description = "Латинская буква T", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "U", MorseCode = "..-", Category = SymbolCategory.LatinLetters, Description = "Латинская буква U", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "V", MorseCode = "...-", Category = SymbolCategory.LatinLetters, Description = "Латинская буква V", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "W", MorseCode = ".--", Category = SymbolCategory.LatinLetters, Description = "Латинская буква W", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "X", MorseCode = "-..-", Category = SymbolCategory.LatinLetters, Description = "Латинская буква X", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "Y", MorseCode = "-.--", Category = SymbolCategory.LatinLetters, Description = "Латинская буква Y", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "Z", MorseCode = "--..", Category = SymbolCategory.LatinLetters, Description = "Латинская буква Z", Difficulty = 3 });

            // Русские буквы
            _symbols.Add(new MorseSymbol { Character = "А", MorseCode = ".-", Category = SymbolCategory.LatinLetters, Description = "Русская буква А", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "Б", MorseCode = "-...", Category = SymbolCategory.LatinLetters, Description = "Русская буква Б", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "В", MorseCode = ".--", Category = SymbolCategory.LatinLetters, Description = "Русская буква В", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "Г", MorseCode = "--.", Category = SymbolCategory.LatinLetters, Description = "Русская буква Г", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "Д", MorseCode = "-..", Category = SymbolCategory.LatinLetters, Description = "Русская буква Д", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "Е", MorseCode = ".", Category = SymbolCategory.LatinLetters, Description = "Русская буква Е", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "Ж", MorseCode = "...-.", Category = SymbolCategory.LatinLetters, Description = "Русская буква Ж", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "З", MorseCode = "--..", Category = SymbolCategory.LatinLetters, Description = "Русская буква З", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "И", MorseCode = "..", Category = SymbolCategory.LatinLetters, Description = "Русская буква И", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "Й", MorseCode = ".---", Category = SymbolCategory.LatinLetters, Description = "Русская буква Й", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "К", MorseCode = "-.-", Category = SymbolCategory.LatinLetters, Description = "Русская буква К", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "Л", MorseCode = ".-..", Category = SymbolCategory.LatinLetters, Description = "Русская буква Л", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "М", MorseCode = "--", Category = SymbolCategory.LatinLetters, Description = "Русская буква М", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "Н", MorseCode = "-.", Category = SymbolCategory.LatinLetters, Description = "Русская буква Н", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "О", MorseCode = "---", Category = SymbolCategory.LatinLetters, Description = "Русская буква О", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "П", MorseCode = ".--.", Category = SymbolCategory.LatinLetters, Description = "Русская буква П", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "Р", MorseCode = ".-.", Category = SymbolCategory.LatinLetters, Description = "Русская буква Р", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "С", MorseCode = "...", Category = SymbolCategory.LatinLetters, Description = "Русская буква С", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "Т", MorseCode = "-", Category = SymbolCategory.LatinLetters, Description = "Русская буква Т", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "У", MorseCode = "..-", Category = SymbolCategory.LatinLetters, Description = "Русская буква У", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "Ф", MorseCode = "..-.", Category = SymbolCategory.LatinLetters, Description = "Русская буква Ф", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "Х", MorseCode = "----", Category = SymbolCategory.LatinLetters, Description = "Русская буква Х", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "Ц", MorseCode = "-.--", Category = SymbolCategory.LatinLetters, Description = "Русская буква Ц", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "Ч", MorseCode = "---.", Category = SymbolCategory.LatinLetters, Description = "Русская буква Ч", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "Ш", MorseCode = "----", Category = SymbolCategory.LatinLetters, Description = "Русская буква Ш", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "Щ", MorseCode = "----.", Category = SymbolCategory.LatinLetters, Description = "Русская буква Щ", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "Ъ", MorseCode = ".--.-", Category = SymbolCategory.LatinLetters, Description = "Русская буква Ъ", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "Ы", MorseCode = "-.--", Category = SymbolCategory.LatinLetters, Description = "Русская буква Ы", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "Ь", MorseCode = "-..-", Category = SymbolCategory.LatinLetters, Description = "Русская буква Ь", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "Э", MorseCode = "..-..", Category = SymbolCategory.LatinLetters, Description = "Русская буква Э", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "Ю", MorseCode = "..--", Category = SymbolCategory.LatinLetters, Description = "Русская буква Ю", Difficulty = 4 });
            _symbols.Add(new MorseSymbol { Character = "Я", MorseCode = ".-.-", Category = SymbolCategory.LatinLetters, Description = "Русская буква Я", Difficulty = 4 });
        
        // Цифры
        _symbols.Add(new MorseSymbol { Character = "0", MorseCode = "-----", Category = SymbolCategory.Numbers, Description = "Цифра ноль", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "1", MorseCode = ".----", Category = SymbolCategory.Numbers, Description = "Цифра один", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "2", MorseCode = "..---", Category = SymbolCategory.Numbers, Description = "Цифра два", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "3", MorseCode = "...--", Category = SymbolCategory.Numbers, Description = "Цифра три", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "4", MorseCode = "....-", Category = SymbolCategory.Numbers, Description = "Цифра четыре", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "5", MorseCode = ".....", Category = SymbolCategory.Numbers, Description = "Цифра пять", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "6", MorseCode = "-....", Category = SymbolCategory.Numbers, Description = "Цифра шесть", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "7", MorseCode = "--...", Category = SymbolCategory.Numbers, Description = "Цифра семь", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "8", MorseCode = "---..", Category = SymbolCategory.Numbers, Description = "Цифра восемь", Difficulty = 2 });
            _symbols.Add(new MorseSymbol { Character = "9", MorseCode = "----.", Category = SymbolCategory.Numbers, Description = "Цифра девять", Difficulty = 2 });

            // Знаки препинания
            _symbols.Add(new MorseSymbol { Character = ".", MorseCode = ".-.-.-", Category = SymbolCategory.Punctuation, Description = "Точка", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = ",", MorseCode = "--..--", Category = SymbolCategory.Punctuation, Description = "Запятая", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "?", MorseCode = "..--..", Category = SymbolCategory.Punctuation, Description = "Вопросительный знак", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "!", MorseCode = "-.-.--", Category = SymbolCategory.Punctuation, Description = "Восклицательный знак", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "-", MorseCode = "-....-", Category = SymbolCategory.Punctuation, Description = "Дефис", Difficulty = 3 });
            _symbols.Add(new MorseSymbol { Character = "/", MorseCode = "-..-.", Category = SymbolCategory.Punctuation, Description = "Косая черта", Difficulty = 3 });

            // Специальные сигналы
            _symbols.Add(new MorseSymbol { Character = "SOS", MorseCode = "...---...", Category = SymbolCategory.SpecialSignals, Description = "Сигнал бедствия", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "ОШИБКА", MorseCode = "........", Category = SymbolCategory.SpecialSignals, Description = "Сигнал ошибки", Difficulty = 1 });
            _symbols.Add(new MorseSymbol { Character = "ПОНЯЛ", MorseCode = ".-.-.", Category = SymbolCategory.SpecialSignals, Description = "Сигнал понимания", Difficulty = 2 });
        }

        public List<MorseSymbol> GetAllSymbols() => _symbols;

        public MorseSymbol GetSymbolByCharacter(string character)
        {
            return _symbols.FirstOrDefault(s =>
                string.Equals(s.Character, character, StringComparison.OrdinalIgnoreCase));
        }

        public List<MorseSymbol> SearchSymbols(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return _symbols;

            string searchLower = searchText.ToLowerInvariant();

            var result = _symbols.Where(s =>
                s.Character.ToLowerInvariant().Contains(searchLower) ||
                s.MorseCode.ToLowerInvariant().Contains(searchLower) ||
                s.Description.ToLowerInvariant().Contains(searchLower)
            ).ToList();

            return result;
        }

        public List<MorseSymbol> GetSymbolsByCategory(SymbolCategory category)
        {
            if (category == SymbolCategory.All)
                return _symbols;

            var result = _symbols.Where(s => s.Category == category).ToList();
            return result;
        }

        public List<MorseSymbol> GetSymbolsByDifficulty(int difficulty)
        {
            return _symbols.Where(s => s.Difficulty == difficulty).ToList();
        }

        public MorseSymbol GetRandomSymbol()
        {
            var random = new Random();
            return _symbols[random.Next(_symbols.Count)];
        }

        // Метод для получения статистики
        public Dictionary<string, int> GetStatistics()
        {
            return new Dictionary<string, int>
            {
                ["Всего символов"] = _symbols.Count,
                ["Латинские буквы"] = _symbols.Count(s => s.Category == SymbolCategory.LatinLetters),
                ["Цифры"] = _symbols.Count(s => s.Category == SymbolCategory.Numbers),
                ["Знаки препинания"] = _symbols.Count(s => s.Category == SymbolCategory.Punctuation),
                ["Специальные сигналы"] = _symbols.Count(s => s.Category == SymbolCategory.SpecialSignals)
            };
        }
    }
}
