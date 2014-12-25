using System.Text.RegularExpressions;

namespace GuideToGalaxy
{
    public static class StringUtils
    {
        public static string RemoveConsecutiveSpaces(this string input)
        {
            var options = RegexOptions.Multiline;
            var regex = new Regex(@"[ ]{2,}", options);
            input = regex.Replace(input, @" ");
            return input;
        }
    }
}
