using System.Collections.Generic;
using System.Globalization;

namespace Languages
{
    public class RomanLanguage : IAmLanguage
    {
        public Dictionary<string, int> LanguageToDecimalDictionary { get; set; }
        public int Parse(string number)
        {
            var totalValue = 0;

            for (var i = 0; i < number.Length; ++i)
            {
                var curr = number[i].ToString(CultureInfo.InvariantCulture);
                if (NextExists(i, number))
                {
                    if (NextIsBigger(i, number))
                    {
                        totalValue += LanguageToDecimalDictionary[Next(i, number)] - LanguageToDecimalDictionary[curr];
                        i++;
                    }
                    else
                    {
                        totalValue += LanguageToDecimalDictionary[curr];
                    }
                }
                else
                {
                    totalValue += LanguageToDecimalDictionary[curr];
                }
            }
            return totalValue;
        }

        public RomanLanguage()
        {
            LanguageToDecimalDictionary = new Dictionary<string, int>
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
        private static bool NextExists(int currentIndex, string number)
        {
            return number.Length > currentIndex + 1;
        }

        private static string Next(int currentIndex, string number)
        {
            return number[currentIndex + 1].ToString(CultureInfo.InvariantCulture);
        }

        private bool NextIsBigger(int currentIndex, string number)
        {
            return currentIndex + 1 < number.Length &&
                   LanguageToDecimalDictionary[number[currentIndex].ToString(CultureInfo.InvariantCulture)]
                   <
                   LanguageToDecimalDictionary[number[currentIndex + 1].ToString(CultureInfo.InvariantCulture)];
        }

    }
}
