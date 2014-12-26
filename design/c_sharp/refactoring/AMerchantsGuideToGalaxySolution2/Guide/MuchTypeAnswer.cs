using System;
using System.Collections.Generic;
using Languages;

namespace Guide
{
    public class MuchTypeAnswer<T> : Answer<T> where T : IProvideLanguage, new ()
    {
        public MuchTypeAnswer(Question<T> question)
        {
            Question = question;
            AnswerStringFormat = "{0}is {1}";
        }
        protected override sealed Question<T> Question { get; set; }
        protected override sealed string AnswerStringFormat { get; set; }

        public override void MakeAnswer(IProvideQuestion<T> question, List<Information<T>> informations, Dictionary<string, string> dictionary)
        {
            try{
            var value = CalculateValue(question);
            AnswerString = string.Format(AnswerStringFormat, question.RawNumber, value);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
