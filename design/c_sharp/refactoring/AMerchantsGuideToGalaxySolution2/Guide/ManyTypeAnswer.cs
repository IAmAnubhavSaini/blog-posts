﻿using System;
using System.Collections.Generic;
using Languages;

namespace Guide
{
    public class ManyTypeAnswer<T> : Answer<T> where T : IProvideLanguage, new ()
    {
        public ManyTypeAnswer(Question<T> question)
        {
            Question = question;
            AnswerStringFormat = "{0}{1} is {2} {3}";
        } 
        protected override sealed Question<T> Question { get; set; }
        protected override sealed string AnswerStringFormat { get; set; }

        public override void MakeAnswer(IProvideQuestion<T> question, List<Information<T>> informations, Dictionary<string, string> dictionary)
        {
            try
            {
                var value = CalculateValue(question);
                AnswerString = string.Format(AnswerStringFormat, question.RawNumber, question.Information.Item, value,
                    question.Information.Unit);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
