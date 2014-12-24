using System.Collections.Generic;

namespace GuideToGalaxy
{
    public class ManyTypeAnswer : Answer
    {
        public ManyTypeAnswer(Question question)
        {
            Question = question;
        } 
        protected override sealed Question Question { get; set; }

        internal override void MakeAnswer(IProvideQuestion question, List<Information> informations, Dictionary<string, string> dictionary)
        {
            var value = CalculateValue(question);
            AnswerString = string.Format("{0}{1} is {2} {3}", question.RawNumber,question.Information.Item, value, question.Information.Unit);
        }
    }
}
