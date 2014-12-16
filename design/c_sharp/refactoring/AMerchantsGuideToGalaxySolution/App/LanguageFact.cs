
using System.Text.RegularExpressions;

namespace App
{
    public class LanguageFact
    {
        public string RomanNumber { get; private set; }
        public string OtherLanguageNumber { get; private set; }

        public bool IsLanguageFact { get; private set; }

        public LanguageFact(string information)
        {
            var regex = new Regex("(?<other>.*) is (?<roman>.*).*");
            var matchCollection = regex.Matches(information.Trim(new[] { ',', '.', ' ' }));
            if (matchCollection.Count > 0)
            {
                foreach (Match match in matchCollection)
                {
                    RomanNumber = match.Groups["roman"].ToString();
                    OtherLanguageNumber = match.Groups["other"].ToString();
                }
                IsLanguageFact = true;
            }
            else
            {
                IsLanguageFact = false;
            }
        }
    }
}
