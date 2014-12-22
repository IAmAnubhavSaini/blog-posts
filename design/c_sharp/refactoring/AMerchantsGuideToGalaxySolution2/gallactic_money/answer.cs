using Languages;
using roman_numerals_parser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gallactic_money
{
    public class Answer
    {
        readonly string[] NonMatchResponses = {
            "You don't mess with Zohan",
            "Yu no waet yu toing",
            "Twinkle twinkle little, wait what",
            "Aye crumba! Even Homer can answer that.",
            "42",
            "Hi. I am Dory. Hello. ... Hi. I am Dory. Hello. ...",
            "When life gives you lemonade, you make lemons.",
            "I have no idea what you are talking about."
        };


        readonly Dictionary<QAType, string> FormatStrings = new Dictionary<QAType, string>{
            { QAType.Many, "{0}{1} is {2} {3}" },
            { QAType.Much, "{0}is {1}" },
            { QAType.NonMatching, "{0}" }
        };

        string AnswerString;

        internal void MakeAnswer(Question Q, List<Information> Informations, Dictionary<string, string> Dictionary)
        {
            var rnd = new Random();
            var value = 0;
            switch (Q.QuestionType)
            {
                case QAType.NonMatching:
                    AnswerString = NonMatchResponses[rnd.Next(0, NonMatchResponses.Count())];
                    break;
                case QAType.Many:
                    value = CalculateValueForItem(Q, Informations, Dictionary);
                    AnswerString = string.Format(FormatStrings[QAType.Many], Q.RawNumber, Q.Item, value, Q.Unit);
                    break;
                case QAType.Much:
                    value = CalculateValue(Q);
                    AnswerString = string.Format(FormatStrings[QAType.Much], Q.RawNumber, value);
                    break;
            }
        }

        private int CalculateValue(Question Q)
        {
            var parser = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();
            var value = parser.ParseNumber(Q.Number);
            return value;
        }

        private static int CalculateValueForItem(Question Q, IEnumerable<Information> Is, Dictionary<string, string> D)
        {

            var value = 0;
            var parser = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();
            var qNumberDecimal = parser.ParseNumber(Q.Number);

            foreach (var i in Is.Where(info => info.Item.Equals(Q.Item)))
            {
                var iNumberDecimal = parser.ParseNumber(i.Number);
                var perItem = i.Value / (double)iNumberDecimal;
                value = int.Parse((perItem * qNumberDecimal).ToString());
                break;
            }

            return value;
        }

        internal void PrintAnswer()
        {
            Console.WriteLine(AnswerString);
        }
    }
}
