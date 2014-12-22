using roman_numerals_parser;
using System;
using System.Collections.Generic;
using System.Linq;


namespace gallactic_money
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
            Program program = new Program();
            try
            {
                if (args.Count() >= 1)
                {
                    if (args[0].ToLower().Equals("run"))
                    {
                        program.Run();
                    }
                    else if (args.Count() == 2 && args[0].ToLower().Equals("test") && args[1].ToLower().Equals("rnp"))
                    {
                        program.TestRNP();
                    }
                    else if (args.Count() == 2 && args[0].ToLower().Equals("test") && args[1].ToLower().Equals("self"))
                    {
                        program.TestSelf();
                    }
                    else if (args.Count() == 2 && args[0].ToLower().Equals("test") && args[1].ToLower().Equals("all"))
                    {
                        program.TestRNP();
                        program.TestSelf();
                    }
                    else
                    {
                        PrintUsageInfo();
                    }
                }
                else
                {
                    PrintUsageInfo();
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
            string input, tmpInput;
            string[] splitted;
            List<Question> Questions = new List<Question>();
            List<Information> Informations = new List<Information>();
            List<Answer> Answers = new List<Answer>();

            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                // input = input.ToLower(); // Assuming case insensitivity
                // we need to sanitize input/
                input = input.Trim();
                input = CommonUtils.RemoveConsecutiveSpaces(input);

                tmpInput = input;
                splitted = input.Split(' ');
                if (splitted.Count() == 3)
                {
                    try
                    {
                        // assignment information (1)
                        if (CommonUtils.GalacticLanguageNumeralsValue.ContainsKey(splitted[2].ToUpper()))
                        {
                            splitted[2] = splitted[2].ToUpper();
                        }
                        CommonUtils.GalacticLanguageNumeralsValue.Add(splitted[0], CommonUtils.GalacticLanguageNumeralsValue[splitted[2]]);
                        // I think we are not going to ever use GalacticLanguageNumeralsValue, never.
                        CommonUtils.GalacticLanguageNumeralsDict.Add(splitted[0], splitted[2]);
                        // We will always need to read string and convert it via GalactivLanguageNumeralsDict to Roman characters and then via RNP get teh value
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
                        // A question : how fortunate! (3)

                        Question q = new Question();
                        q.MakeInfo(input, CommonUtils.GalacticLanguageNumeralsDict);
                        Questions.Add(q);
                    }
                    else
                    {
                        // An informaion : how fortunate! (2)
                        try
                        {
                            Information i = new Information();
                            i.MakeInfo(input, CommonUtils.GalacticLanguageNumeralsDict);
                            Informations.Add(i);
                        }
                        catch (System.FormatException fex)
                        {
                            Console.WriteLine("Hmm. It says string is in bad format. Please conform to specification.");
                            Console.WriteLine("Exception : " + fex.Message);
                        }
                    }
                }
            } // reading of input is interrupted since no more string found

            // Now Answer all the questions.
            foreach (Question Q in Questions)
            {
                Answer A = new Answer();
                A.MakeAnswer(Q, Informations, CommonUtils.GalacticLanguageNumeralsDict);
                Answers.Add(A); // may be for future use or for self testing.
                A.PrintAnswer();
            }

        }

       
        void TestRNP()
        {
            RomanNumeralParserTest tester = new RomanNumeralParserTest();
            tester.Test1();
            tester.Test2();
        }
    }



}
