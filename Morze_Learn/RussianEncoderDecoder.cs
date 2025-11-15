using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morze_Learn
{
    class RussianEncoderDecoder
    {
        private Dictionary<char, string> _russianMorseCodes;

        public RussianEncoderDecoder(Dictionary<char, string> russianCodes)
        {
            _russianMorseCodes = russianCodes;
        }

        public string EncodeRussian(string text)
        {
            string encoded = "";
            foreach (char ch in text.ToUpper())
            {
                if (_russianMorseCodes.ContainsKey(ch))
                {
                    encoded += _russianMorseCodes[ch] + " ";
                }
                else
                {
                    encoded += "? "; // Нераспознанный символ
                }
            }
            return encoded.Trim();
        }

        public string DecodeRussian(string morseCode)
        {
            string decoded = "";
            string[] parts = morseCode.Split(' ');
            foreach (string part in parts)
            {
                foreach (var pair in _russianMorseCodes)
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
