using System.Collections.Generic;

namespace Languages
{
    public interface IAmLanguage
    {
        Dictionary<string, int> LanguageToDecimalDictionary { get; set; }
        int Parse(string number);
    }
}
