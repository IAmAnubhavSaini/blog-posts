using roman_numerals_parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


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
                        program.TestRomanNumeralParser();
                    }
                    else if (args.Count() == 2 && args[0].ToLower().Equals("test") && args[1].ToLower().Equals("self"))
                    {
                        program.TestSelf();
                    }
                    else if (args.Count() == 2 && args[0].ToLower().Equals("test") && args[1].ToLower().Equals("all"))
                    {
                        program.TestRomanNumeralParser();
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

        string RemoveConsecutiveSpaces(string input)
        {
            var options = RegexOptions.Multiline;
            var regex = new Regex(@"[ ]{2,}", options);
            input = regex.Replace(input, @" ");
            return input;
        }

        void Run()
        {
            string input;
            var questions = new List<IProvideQuestion>();
            var informations = new List<Information>();
            var answers = new List<Answer>();
            var galacticLanguageNumeralsValue = new Dictionary<string, int>
            {
                {"I", 1},
                {"V", 5},
                {"X", 10},
                {"L", 50},
                {"C", 100},
                {"D", 500},
                {"M", 1000}
            };
            var galacticLanguageNumeralsDict = new Dictionary<string, string>();

            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                // input = input.ToLower(); // Assuming case insensitivity
                // we need to sanitize input/
                input = input.Trim();
                input = RemoveConsecutiveSpaces(input);

                var splitted = input.Split(' ');
                if (splitted.Count() == 3)
                {
                    try
                    {
                        // assignment information (1)
                        if (galacticLanguageNumeralsDict.ContainsKey(splitted[2].ToUpper()))
                        {
                            splitted[2] = splitted[2].ToUpper();
                        }
                        galacticLanguageNumeralsDict.Add(splitted[0], splitted[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not found {0} in our records. Do you know what you are doing?", splitted[2]);
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                }
                else
                {
                    // here, either it's a question(3) or information(2).

                    if (Question.IsQuestion(input))
                    {
                        var generateQuestion = Factories.QuestionFactory.GenerateQuestion(input, galacticLanguageNumeralsDict);
                        if (generateQuestion != null)
                            questions.Add(generateQuestion);
                    }
                    else
                    {
                        // An informaion : how fortunate! (2)
                        try
                        {
                            var i = new Information();
                            i.MakeInfo(input, galacticLanguageNumeralsDict);
                            informations.Add(i);
                        }
                        catch (FormatException fex)
                        {
                            Console.WriteLine("Hmm. It says string is in bad format. Please conform to specification.");
                            Console.WriteLine("Exception : " + fex.Message);
                        }
                    }
                }
            } // reading of input is interrupted since no more string found

            // Now Answer all the questions.
            foreach (var question in questions)
            {
                var answer = Factories.AnswerFactory.GenerateAnswer(question.QuestionType);
                answer.MakeAnswer(question, informations, galacticLanguageNumeralsDict);
                answers.Add(answer); // may be for future use or for self testing.
                answer.PrintAnswer();
            }
        }


        void TestRomanNumeralParser()
        {
            var tester = new RomanNumeralParserTest();
            tester.Test1();
            tester.Test2();
        }
    }



}
