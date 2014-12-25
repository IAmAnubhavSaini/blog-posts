using System.Collections.Generic;
using Languages;

namespace GuideToGalaxy
{
    public class MuchTypeAnswer<T> : Answer<T> where T : IProvideLanguage, new ()
    {
        public MuchTypeAnswer(Question<T> question)
        {
            Question = question;
        }
        protected override sealed Question<T> Question { get; set; }

        internal override void MakeAnswer(IProvideQuestion<T> question, List<Information<T>> informations, Dictionary<string, string> dictionary)
        {
            var value = CalculateValue(question);
            AnswerString = string.Format("{0}is {1}", question.RawNumber, value);
        }
    }
}
