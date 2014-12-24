using Exceptions;
using Languages;
using System;

namespace GuideToGalaxy
{
    public class Factories
    {
        public class AnswerFactory<T> where T: IProvideLanguage, new ()
        {
            public static Answer<T> GenerateAnswer(QAType type, Question<T> question)
            {
                switch (type)
                {
                    case QAType.Many: return new ManyTypeAnswer<T>(question);
                    case QAType.Much: return new MuchTypeAnswer<T>(question);
                }
                throw new NotAnAnswerException("Non-conforming type of question asked. Cannot generate an answer.", new ArgumentException().ToString());
            }
        }

        public class QuestionFactory<T> where T: IProvideLanguage, new()
        {
            public static Question<T> GenerateQuestion(string input, Knowledge<T>  knowledge)
            {
                var smallLetteredInput = input.ToLower();
                if (smallLetteredInput.Contains(" much "))
                {
                    return new MuchTypeQuestion<T>(input, knowledge);
                }
                if (smallLetteredInput.Contains(" many "))
                {
                    return new ManyTypeQuestion<T>(input, knowledge);
                }
                throw new NotAQuestionException("Non-conforming type of question.", new ArgumentException().ToString());
            }
        }
    }
}
