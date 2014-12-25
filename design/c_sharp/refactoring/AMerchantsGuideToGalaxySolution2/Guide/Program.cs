using Languages;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GuideToGalaxy
{
    class Program
    {
        private static void PrintUsageInfo()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("<app.exe> run < input : for running the program.");
        }

        static void Main(string[] args)
        {
            var program = new Program();
            try
            {
                if (args.Any())
                {
                    if (args[0].ToLower().Equals("run"))
                    {
                        program.Run<RomanLanguage>();
                    }
                    else
                    {
                        PrintUsageInfo();
                    }
                }
                else
                {
                    //PrintUsageInfo();
                    program.Run<RomanLanguage>();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.");
                Console.WriteLine("Message : " + ex.Message);
                Console.WriteLine("Source : " + ex.Source);
                Console.WriteLine("Stack : " + ex.StackTrace);
            }
        }

        void Run<T>() where T: IProvideLanguage, new ()
        {
            string input;
            var questions = new List<IProvideQuestion<T>>();
            var informations = new List<Information<T>>();
            var answers = new List<Answer<T>>();
            var knowledge = new Knowledge<T>();
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                input = SanitizeInput(input);

                var splitted = input.Split(' ');
                if (SimpleFact(splitted))
                {
                    knowledge.ForeignLanguageToKnownLanguageDictionary.Add(splitted[0].ToUpper(), splitted[2].ToUpper());
                }
                else
                {
                    if (Question<T>.IsQuestion(input))
                    {
                        var generateQuestion = Factories.QuestionFactory<T>.GenerateQuestion(input, knowledge );
                        if (generateQuestion != null)
                            questions.Add(generateQuestion);
                    }
                    else
                    {
                        try
                        {
                            var i = new Information<T>();
                            i.MakeInfo(input, knowledge);
                            knowledge.Informations.Add(i);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("I have no idea what you are talking about.");
                        }
                    }
                }
            }

            AnswerAllTheQuestion(questions, knowledge, answers);
        }

        private static bool SimpleFact(IEnumerable<string> splitted)
        {
            return splitted.Count() == 3;
        }

        private static string SanitizeInput(string input)
        {
            return  input.Trim().RemoveConsecutiveSpaces();
        }

        private static void AnswerAllTheQuestion<T>(IEnumerable<IProvideQuestion<T>> questions, Knowledge<T> knowledge ,
            ICollection<Answer<T>> answers) where T : IProvideLanguage, new()
        {
            foreach (var question in questions)
            {
                var answer = Factories.AnswerFactory<T>.GenerateAnswer(question.QuestionType, question as Question<T>);
                answer.MakeAnswer(question, knowledge.Informations, knowledge.ForeignLanguageToKnownLanguageDictionary);
                answers.Add(answer);
                answer.PrintAnswer();
            }
        }
    }
}
