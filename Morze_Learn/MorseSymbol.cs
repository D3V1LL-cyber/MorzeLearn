using System;
using System.IO;

namespace Morze_Learn
{
    public class MorseSymbol
    {
        public string Character { get; set; }
        public string MorseCode { get; set; }
        public MorseRepository.SymbolCategory Category { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; } = 1;
        public string ImagePath { get; set; }
        public string SoundPath { get; set; }

        public int CodeLength => MorseCode?.Length ?? 0;

        public bool HasImage
        {
            get
            {
                // Для демонстрации - всегда false, так как файлов изображений нет
                return false;
            }
        }

        public bool HasSound
        {
            get
            {
                // Всегда true, так как используем генерацию звука через AudioPlayback
                return true;
            }
        }

        public override string ToString()
        {
            return $"{Character} ({MorseCode}) - {Description}";
        }
    }
}
