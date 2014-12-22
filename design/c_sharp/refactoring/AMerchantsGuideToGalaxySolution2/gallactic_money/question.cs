using System.Collections.Generic;
using System.Linq;

namespace gallactic_money
{
    public class Question : Information
    {
        // Assumption : All input is case insensitive.
        private string Input;
        private string[] Splitted;
        public QAType QuestionType;
        public string RawNumber;

        public override void MakeInfo(string input, Dictionary<string, string> dict)
        {
            int start = 0, end = 0;
            if (!string.IsNullOrEmpty(input))
            {
                Input = input;
                Splitted = Input.Split(' ');
                if (IsQuestion())
                {
                    int count = Splitted.Count();
                    if (Input.ToLower().Contains("many"))
                    {
                        start = 4; // because first 3 are "how many Unit is"
                        // end will tackle situations : question ending or not ending in ? 
                        end = Input.EndsWith("?") ? count - 2 : count - 1;
                        bool knownWord = true;
                        for (int i = start; i < end && knownWord; ++i)
                        {
                            if (dict.ContainsKey(Splitted[i]))
                            {
                                Number += dict[Splitted[i]];
                                RawNumber += Splitted[i] + " ";
                            }
                            else
                            {
                                knownWord = false;
                            }
                        }
                        if (knownWord)
                        {
                            QuestionType = QAType.Many;
                            Unit = Splitted[2];
                            Item = Splitted[end];
                        }
                        else
                        {
                            QuestionType = QAType.NonMatching;
                        }
                    }
                    else if (input.ToLower().Contains("much"))
                    {
                        bool knownWord = true;
                        start = 3; // because first three are : how much is
                        end = Input.EndsWith("?") ? count - 1 : count;
                        for (int i = start; i < end && knownWord; ++i)
                        {
                            if (dict.ContainsKey(Splitted[i]))
                            {
                                Number += dict[Splitted[i]];
                                RawNumber += Splitted[i] + " ";
                            }
                            else
                            {
                                knownWord = false;
                            }
                        }
                        QuestionType = knownWord ? QAType.Much : QAType.NonMatching;
                    }
                    else
                    {
                        // this is the case where we cannot make any sense/
                        QuestionType = QAType.NonMatching;
                    }

                    //Console.WriteLine("received: {0} {1} {2} {3} {4} {5}", Input, Number, RawNumber, Value, Item, Unit);
                }
            }
        }

        private bool IsQuestion()
        {
            return IsQuestion(Input);
        }

        public static bool IsQuestion(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                input = input.ToLower();
                if (input.ToLower().StartsWith("how") ||
                    input.ToLower().EndsWith("?") ||
                    input.ToLower().Contains("how"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
