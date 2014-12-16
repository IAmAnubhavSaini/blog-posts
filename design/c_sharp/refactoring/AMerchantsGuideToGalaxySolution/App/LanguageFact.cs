
using System.Linq;
using System.Text.RegularExpressions;

namespace App
{
    public class LanguageFact
    {
        public string RomanNumber { get; private set; }
        public string OtherLanguageNumber { get; private set; }

        public static bool IsLanguageFact(string input)
        {
            return input.Split(' ').Count() == 3 && input.Split(' ')[1].Equals("is");
        }

        public LanguageFact(string information)
        {
            var regex = new Regex("(?<other>.*) is (?<roman>.*).*");
            foreach (Match match in regex.Matches(information))
            {
                RomanNumber = match.Groups["roman"].ToString();
                OtherLanguageNumber = match.Groups["other"].ToString();
            }
        }
    }
}
