using System.Collections.Generic;
using System.Linq;

namespace GuideToGalaxy
{
    public interface IProvideQuestion
    {

    }
    public class Question : IProvideQuestion
    {
        public Information Information = new Information();

        public Question(string input, Dictionary<string, string> dictionary)
        {
            Input = input;
            CurrentConversionDictionary = dictionary;
            MakeInfo();
        }
        // Assumption : All input is case insensitive.
        private readonly string Input;
        private string[] Splitted;
        public QAType QuestionType;
        public string RawNumber;
        private readonly Dictionary<string, string> CurrentConversionDictionary;
        public void MakeInfo()
        {
            if (!string.IsNullOrEmpty(Input))
            {
                Splitted = Input.Split(' ');
                if (IsQuestion())
                {
                    var count = Splitted.Count();
                    int start;
                    int end;
                    if (Input.ToLower().Contains("many"))
                    {
                        start = 4; // because first 3 are "how many Unit is"
                        // end will tackle situations : question ending or not ending in ? 
                        end = Input.EndsWith("?") ? count - 2 : count - 1;
                        var knownWord = true;
                        for (var i = start; i < end && knownWord; ++i)
                        {
                            if (CurrentConversionDictionary.ContainsKey(Splitted[i]))
                            {
                                Information.Number += CurrentConversionDictionary[Splitted[i]];
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
                            Information.Unit = Splitted[2];
                            Information.Item = Splitted[end];
                        }
                        else
                        {
                            QuestionType = QAType.NonMatching;
                        }
                    }
                    else if (Input.ToLower().Contains("much"))
                    {
                        var knownWord = true;
                        start = 3; // start at fourth, because first three are : how much is
                        end = Input.EndsWith("?") ? count - 1 : count;
                        for (var i = start; i < end && knownWord; ++i)
                        {
                            if (CurrentConversionDictionary.ContainsKey(Splitted[i]))
                            {
                                Information.Number += CurrentConversionDictionary[Splitted[i]];
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
                }
            }
        }

        private bool IsQuestion()
        {
            return IsQuestion(Input);
        }

        public static bool IsQuestion(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            input = input.ToLower();
            return input.ToLower().StartsWith("how") ||
                   input.ToLower().EndsWith("?") ||
                   input.ToLower().Contains("how");
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
                return new Question(input, dictionary);
            }
        }
    }
}
