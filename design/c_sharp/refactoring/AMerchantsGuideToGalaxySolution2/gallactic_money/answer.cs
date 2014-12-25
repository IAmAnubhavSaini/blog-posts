﻿using Languages;
using NumeralParser;
using System;
using System.Collections.Generic;

namespace GuideToGalaxy
{
    public abstract class Answer<T> where T : IProvideLanguage, new ()
    {
        protected  abstract Question<T> Question { get; set; }
        protected string AnswerString;

        internal abstract void MakeAnswer(IProvideQuestion<T> question, List<Information<T>> informations, Dictionary<string, string> dictionary);

        protected int CalculateValue(IProvideQuestion<T> q)
        {
            var parser = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();
            var value = parser.ParseNumber(q.Information.Number);
            return value;
        }

        internal void PrintAnswer()
        {
            Console.WriteLine(AnswerString);
        }
    }

    
}
