using System;
using System.Collections.Generic;
using System.Globalization;

namespace LanguageParsers
{
    public class RomanLanguageParser
    {
        private static Dictionary<string, int> RomanToDecimalDictionary { get; set; }

        static RomanLanguageParser()
        {
            RomanToDecimalDictionary = new Dictionary<string, int>
            {
                {"I", 1},
                {"V", 5},
                {"X", 10},
                {"L", 50},
                {"C", 100},
                {"D", 500},
                {"M", 1000}
            };
        }
        public static int GetValueOfRomanNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException();

            if (RomanToDecimalDictionary.ContainsKey(number))
            {
                return RomanToDecimalDictionary[number];
            }
            if (number.Length > 1)
            {
                return Parse(number);
            }
            throw new Exception("Value not found for " + number);
        }

        private static int Parse(string number)
        {
            var totalValue = 0;

            for (var i = 0; i < number.Length; ++i)
            {
                var curr = number[i].ToString(CultureInfo.InvariantCulture);
                if (NextExists(i, number))
                {
                    if (NextIsBigger(i, number))
                    {
                        totalValue += GetValueOfRomanNumber(Next(i, number)) - GetValueOfRomanNumber(curr);
                        i++;
                    }
                    else
                    {
                        totalValue += GetValueOfRomanNumber(curr);
                    }
                }
                else
                {
                    totalValue += GetValueOfRomanNumber(curr);
                }
            }
            return totalValue;
        }

        private static bool NextExists(int currentIndex, string number)
        {
            return number.Length > currentIndex + 1;
        }

        private static string Next(int currentIndex, string number)
        {
            return number[currentIndex + 1].ToString(CultureInfo.InvariantCulture);
        }

        private static bool NextIsBigger(int currentIndex, string number)
        {
            return currentIndex + 1 < number.Length &&
                   GetValueOfRomanNumber(number[currentIndex].ToString(CultureInfo.InvariantCulture))
                   <
                   GetValueOfRomanNumber(number[currentIndex + 1].ToString(CultureInfo.InvariantCulture));
        }
    }
}
