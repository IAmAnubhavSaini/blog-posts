﻿using System.Collections.Generic;

namespace GuideToGalaxy
{
    public class MuchTypeAnswer : Answer
    {
        internal override void MakeAnswer(IProvideQuestion question, List<Information> informations, Dictionary<string, string> dictionary)
        {
            var value = CalculateValue(question);
            AnswerString = string.Format("{0}is {1}", question.RawNumber, value);
        }
    }
}