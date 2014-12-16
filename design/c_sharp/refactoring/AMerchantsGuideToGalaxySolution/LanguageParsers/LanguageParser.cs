using Languages;
using System;

namespace LanguageParsers
{
    public class LanguageParser
    {
        static IAmLanguage Language { get; set; }

        public LanguageParser(IAmLanguage language)
        {
            Language = language;
        }

        public int GetValueOf(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException();

            if (Language.LanguageToDecimalDictionary.ContainsKey(number))
            {
                return Language.LanguageToDecimalDictionary[number];
            }
            if (number.Length > 1)
            {
                return Language.Parse(number);
            }
            throw new Exception("Value not found for " + number);
        }
    }
}
