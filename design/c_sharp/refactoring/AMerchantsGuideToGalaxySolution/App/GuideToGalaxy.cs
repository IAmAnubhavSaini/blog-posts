
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace App
{
    public class GuideToGalaxy
    {
        List<Answer> Answers { get; set; }
        List<Question> Questions { get; set; }
        List<BusinessFact> BusinessFacts { get; set; }

        List<LanguageFact> LanguageFacts { get; set; }

        public void Fatory()
        {
            var input = Console.ReadLine();
            input = SanitizeInput(input);
            if (LanguageFact.IsLanguageFact(input))
            {
                LanguageFacts.Add(new LanguageFact(input));
            }
            else if (Question.IsQuestion(input))
            {
                Questions.Add(QuestionFactory.GeneratioQuestion(input));
            }
        }

        public static string SanitizeInput(string input)
        {
            var regex = new Regex(@"[ ]{2,}");
            input = regex.Replace(input, @" ").Trim(new[] { ' ', ',', '.' });
            return input;
        }
    }

}
