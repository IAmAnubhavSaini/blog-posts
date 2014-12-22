using System;
using System.Collections.Generic;
using Languages;

namespace roman_numerals_parser
{
    public class RomanNumeralParserTest
    {
        /* Yes I know D, L, and V cannot be repeated or subtracted and other rules regarding roman numerals
         * But these strange input string tests the parser's ability to parse whatever given if input contains only 
         * roman numerals.
         * */

        readonly List<string> numerals = new List<string>
        {
            "XXV",
            "XXIV",
            "XXIXV",
            "XXVI",
            "XIX",
            "XXX",
            "XDXCXLXV",
            "I", "V", "X", "L", "C", "D", "M",
            "III", "VVV", "XXX", "LLL", "CCC", "DDD", "MMM",
            "IXI", "VXV", "XLX", "LCL", "CDC", "DMD"

        };

        readonly Dictionary<string, int> numeralsDict = new Dictionary<string, int>{
            { "XXV", 25 },
            { "XXIV", 24 },
            { "XXIXV", 34 },
            { "XXVI", 26 },
            { "XIX", 19 },
            { "XDXCXLXV", 635 },
            { "I", 1 }, { "V", 5 }, { "X", 10 }, { "L", 50 }, { "C", 100 }, { "D", 500 }, { "M", 1000 },
            { "III", 3 }, { "VVV", 15 }, { "XXX", 30 }, { "LLL", 150 }, { "CCC", 300 }, { "DDD", 1500 }, { "MMM", 3000 },
            { "IXI", 10 }, { "VXV", 10 }, { "XLX", 50 }, { "LCL", 100 }, { "CDC", 500 }, { "DMD", 1000 }
        };

        public void Test1()
        {
            Console.WriteLine("Running RNPTest.Test1()");
            var rnpObj = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();
            foreach (var numeral in numerals)
            {
                Console.WriteLine("{0} = {1}", numeral, rnpObj.ParseNumber(numeral));
            }
            Console.WriteLine("RNPTest.Test1() finished.");
        }

        public void Test2()
        {
            Console.WriteLine("Running RNPTest.Test2()");
            var rnpObj = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();

            foreach (var numeral in numerals)
            {
                var result = rnpObj.ParseNumber(numeral);
                if (result == numeralsDict[numeral])
                {
                  //  Console.WriteLine("{0} passed the test. Value in decimal : {1}", numeral, result);
                  //  Console.WriteLine("pass");
                }
                else
                {
                    Console.WriteLine("{0} failed the test. Calculated value : {1}, should be value : {2} (in decimal)", numeral, result, numeralsDict[numeral]);
                }
            }

            Console.WriteLine("RNPTest.Test2() finished.");
        }
    }
}
