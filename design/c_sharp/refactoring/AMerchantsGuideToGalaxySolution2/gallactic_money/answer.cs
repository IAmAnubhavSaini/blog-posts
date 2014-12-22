using Languages;
using roman_numerals_parser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuideToGalaxy
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

        internal void MakeAnswer(MuchTypeQuestion muchTypeQuestion, List<Information> informations, Dictionary<string, string> dictionary)
        {
            var value = CalculateValue(muchTypeQuestion);
            AnswerString = string.Format(FormatStrings[QAType.Much], muchTypeQuestion.RawNumber, value);
        }

        internal void MakeAnswer(ManyTypeQuestion manyTypeQuestion, List<Information> informations, Dictionary<string, string> dictionary)
        {
            var value = CalculateValueForItem(manyTypeQuestion, informations, dictionary);
            AnswerString = string.Format(FormatStrings[QAType.Many], manyTypeQuestion.RawNumber, manyTypeQuestion.Information.Item, value, manyTypeQuestion.Information.Unit);
        }
      
        private int CalculateValue(Question Q)
        {
            var parser = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();
            var value = parser.ParseNumber(Q.Information.Number);
            return value;
        }

        private static int CalculateValueForItem(Question Q, IEnumerable<Information> Is, Dictionary<string, string> D)
        {

            var value = 0;
            var parser = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();
            var qNumberDecimal = parser.ParseNumber(Q.Information.Number);

            foreach (var i in Is.Where(info => info.Item.Equals(Q.Information.Item)))
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

        //internal void MakeAnswer(IProvideQuestion question, List<Information> informations, Dictionary<string, string> galacticLanguageNumeralsDict)
        //{
        //    if (question is ManyTypeQuestion)
        //    {
        //        MakeAnswer(question as ManyTypeQuestion, informations, galacticLanguageNumeralsDict);
        //    }
        //    else if(question is MuchTypeQuestion)
        //    {
        //        MakeAnswer(question as MuchTypeQuestion, informations, galacticLanguageNumeralsDict);
        //    }
        //}
    }
}
