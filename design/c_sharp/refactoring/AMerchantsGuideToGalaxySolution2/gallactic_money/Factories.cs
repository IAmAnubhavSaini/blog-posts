using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return null;
            }
        }

        public class QuestionFactory
        {
            public static Question GenerateQuestion(string input, Dictionary<string, string> dictionary)
            {
                if (input.Contains("much"))
                {
                    return new MuchTypeQuestion(input, dictionary);
                }
                else if (input.Contains("many"))
                {
                    return new ManyTypeQuestion(input, dictionary);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
