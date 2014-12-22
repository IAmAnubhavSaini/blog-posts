using Languages;
using roman_numerals_parser;
using System;
using System.Collections.Generic;

namespace GuideToGalaxy
{
    public abstract class Answer
    {
        protected string AnswerString;

        internal abstract void MakeAnswer(IProvideQuestion question, List<Information> informations, Dictionary<string, string> dictionary);

        protected int CalculateValue(IProvideQuestion Q)
        {
            var parser = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();
            var value = parser.ParseNumber(Q.Information.Number);
            return value;
        }

        internal void PrintAnswer()
        {
            Console.WriteLine(AnswerString);
        }
    }

    
}
