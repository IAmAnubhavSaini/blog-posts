using System.Collections.Generic;
using Languages;
using NumeralParser;

namespace GuideToGalaxy
{
    public class Knowledge<T> where T: IProvideLanguage, new()
    {
        public Dictionary<string, string> ForeignLanguageToKnownLanguageDictionary { get; private set; }
        public RomanToDecimanlLikeNumeralParser<T> RomanToDecimalParser { get; private set; }
        public List<Information<T>> Informations { get; private set; } 
        public Knowledge()
        {
            ForeignLanguageToKnownLanguageDictionary = new Dictionary<string, string>();
            RomanToDecimalParser = new RomanToDecimanlLikeNumeralParser<T>();
            Informations  = new List<Information<T>>();
        }
    }
}
