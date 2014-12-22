using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace gallactic_money
{
    public enum QAType
    {
        NonMatching,
        Many,
        Much
    }
    /*
    enum RomanValues
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }
    */
    public class CommonUtils
    {
        public static Dictionary<string, int> GalacticLanguageNumeralsValue = new Dictionary<string, int>{
            { "I", 1 },
            { "V", 5},
            { "X", 10 },
            { "L", 50},
            { "C", 100},
            { "D", 500},
            { "M", 1000}
        };

        public static Dictionary<string, string> GalacticLanguageNumeralsDict = new Dictionary<string, string>();

        public static string RemoveConsecutiveSpaces(string input)
        {
            RegexOptions options = RegexOptions.Multiline;
            Regex regex = new Regex(@"[ ]{2,}", options);
            input = regex.Replace(input, @" ");
            return input;
        }


        /*
        public static Dictionary<char, int> RomanValuesDictChar = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5},
            { 'X', 10 },
            { 'L', 50},
            { 'C', 100},
            { 'D', 500},
            { 'M', 1000}
        };
        */

    }
}
