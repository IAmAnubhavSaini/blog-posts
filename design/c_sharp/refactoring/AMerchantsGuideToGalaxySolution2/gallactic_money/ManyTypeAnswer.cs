using Languages;
using System.Collections.Generic;

namespace GuideToGalaxy
{
    public class ManyTypeAnswer<T> : Answer<T> where T : IProvideLanguage, new ()
    {
        public ManyTypeAnswer(Question<T> question)
        {
            Question = question;
        } 
        protected override sealed Question<T> Question { get; set; }

        internal override void MakeAnswer(IProvideQuestion question, List<Information> informations, Dictionary<string, string> dictionary)
        {
            var value = CalculateValue(question);
            AnswerString = string.Format("{0}{1} is {2} {3}", question.RawNumber,question.Information.Item, value, question.Information.Unit);
        }
    }
}
