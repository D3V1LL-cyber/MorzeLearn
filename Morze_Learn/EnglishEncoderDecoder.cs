using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morze_Learn
{
    class EnglishEncoderDecoder
    {
        private Dictionary<char, string> _englishMorseCodes;

        public EnglishEncoderDecoder(Dictionary<char, string> englishCodes)
        {
            _englishMorseCodes = englishCodes;
        }

        public string EncodeEnglish(string text)
        {
            string encoded = "";
            foreach (char ch in text.ToUpper())
            {
                if (_englishMorseCodes.ContainsKey(ch))
                {
                    encoded += _englishMorseCodes[ch] + " ";
                }
                else
                {
                    encoded += "? "; // Нераспознанный символ
                }
            }
            return encoded.Trim();
        }

        public string DecodeEnglish(string morseCode)
        {
            string decoded = "";
            string[] parts = morseCode.Split(' ');
            foreach (string part in parts)
            {
                foreach (var pair in _englishMorseCodes)
                {
                    if (pair.Value == part)
                    {
                        decoded += pair.Key;
                        break;
                    }
                }
            }
            return decoded;
        }
    }
}
