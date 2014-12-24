using Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using NumeralParser;


namespace GuideToGalaxy
{
    class Program
    {
        private static void PrintUsageInfo()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("<app.exe> run : for running the program.");
            Console.WriteLine("<app.exe> test [rnp | self | all] :");
            Console.WriteLine("\trnp: tests roman numeral convesion, roman to decimal.");
            Console.WriteLine("\tself: tests whole program. Very verbose, but effective.");
            Console.WriteLine("\tall: rnp followed by self. Why not?");
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
                        program.Run();
                    }
                    else if (args.Count() == 2 && args[0].ToLower().Equals("test") && args[1].ToLower().Equals("rnp"))
                    {
                        TestRomanNumeralParser();
                    }
                    else if (args.Count() == 2 && args[0].ToLower().Equals("test") && args[1].ToLower().Equals("self"))
                    {
                        program.TestSelf();
                    }
                    else if (args.Count() == 2 && args[0].ToLower().Equals("test") && args[1].ToLower().Equals("all"))
                    {
                        TestRomanNumeralParser();
                        program.TestSelf();
                    }
                    else
                    {
                        PrintUsageInfo();
                    }
                }
                else
                {
                    //PrintUsageInfo();
                    program.Run();
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

        private void TestSelf()
        {
            Console.WriteLine("Self test not implemented yet.");
        }

        void Run()
        {
            string input;
            var questions = new List<IProvideQuestion>();
            var informations = new List<Information>();
            var answers = new List<Answer>();
            var knowledge = new Knowledge<RomanLanguage>();
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
                    if (Question.IsQuestion(input))
                    {
                        var generateQuestion = Factories.QuestionFactory.GenerateQuestion(input, knowledge.ForeignLanguageToKnownLanguageDictionary);
                        if (generateQuestion != null)
                            questions.Add(generateQuestion);
                    }
                    else
                    {
                        try
                        {
                            var i = new Information();
                            i.MakeInfo(input, knowledge.ForeignLanguageToKnownLanguageDictionary);
                            informations.Add(i);
                        }
                        catch (FormatException fex)
                        {
                            Console.WriteLine("Hmm. It says string is in bad format. Please conform to specification.");
                            Console.WriteLine("Exception : " + fex.Message);
                        }
                    }
                }
            }

            AnswerAllTheQuestion(questions, informations, knowledge.ForeignLanguageToKnownLanguageDictionary, answers);
        }

        private static bool SimpleFact(IEnumerable<string> splitted)
        {
            return splitted.Count() == 3;
        }

        private string SanitizeInput(string input)
        {
            return  input.Trim().RemoveConsecutiveSpaces();
        }

        private static void AnswerAllTheQuestion(IEnumerable<IProvideQuestion> questions, List<Information> informations, Dictionary<string, string> galacticLanguageNumeralsDict,
            ICollection<Answer> answers)
        {
            foreach (var question in questions)
            {
                var answer = Factories.AnswerFactory.GenerateAnswer(question.QuestionType, question as Question);
                answer.MakeAnswer(question, informations, galacticLanguageNumeralsDict);
                answers.Add(answer);
                answer.PrintAnswer();
            }
        }


        static void TestRomanNumeralParser()
        {
            var tester = new RomanNumeralParserTest();
            tester.Test1();
            tester.Test2();
        }
    }



}
