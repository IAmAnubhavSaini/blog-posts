using System;
using System.Collections.Generic;
using Exceptions;

namespace GuideToGalaxy
{
    public class Factories
    {
        public class AnswerFactory
        {
            public static Answer GenerateAnswer(QAType type)
            {
                switch (type)
                {
                    case QAType.Many: return new ManyTypeAnswer();
                    case QAType.Much: return new MuchTypeAnswer();
                }
                throw new NotAnAnswerException("Non-conforming type of question asked. Cannot generate an answer.", new ArgumentException().ToString());
            }
        }

        public class QuestionFactory
        {
            public static Question GenerateQuestion(string input, Dictionary<string, string> dictionary)
            {
                var smallLetteredInput = input.ToLower();
                if (smallLetteredInput.Contains(" much "))
                {
                    return new MuchTypeQuestion(input, dictionary);
                }
                if (smallLetteredInput.Contains(" many "))
                {
                    return new ManyTypeQuestion(input, dictionary);
                }
                throw new NotAQuestionException("Non-conforming type of question.", new ArgumentException().ToString());
            }
        }
    }
}
