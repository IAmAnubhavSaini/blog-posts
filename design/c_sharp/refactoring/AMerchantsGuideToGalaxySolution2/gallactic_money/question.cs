using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;

namespace GuideToGalaxy
{
    public interface IProvideQuestion
    {
        Information Information { get; set; }
        string RawNumber { get; set; }
        QAType QuestionType { get; set; }
    }
    public abstract class Question : IProvideQuestion
    {
        public Information Information { get; set; }
        public string RawNumber { get; set; }
        public QAType QuestionType { get; set; }

        protected Question(string input, Dictionary<string, string> dictionary)
        {
            Input = input;
            CurrentConversionDictionary = dictionary;
            Information = new Information();
            MakeInfo();
        }
        
        protected readonly string Input;
        private string[] Splitted;
        private readonly Dictionary<string, string> CurrentConversionDictionary;
        private void MakeInfo()
        {
            if (!string.IsNullOrEmpty(Input))
            {
                Splitted = Input.Split(' ');
                if (IsQuestion(Input))
                {
                    var count = Splitted.Count();
                    if (Input.ToLower().Contains(" many "))
                    {
                        GenerateManyQuestion(count);
                    }
                    else if (Input.ToLower().Contains(" much "))
                    {
                        GenerateMuchQuestion(count);
                    }
                    else
                    {
                        throw new NotAQuestionException("Non-conforming type of question.", new ArgumentException().ToString());
                    }
                }
            }
        }

        private void GenerateMuchQuestion(int count)
        {
            var knownWord = true;
            var start = StartFrom();
            var end = ItemIndex(count);
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

        private void GenerateManyQuestion(int count)
        {
            var start = StartFrom();
            var itemIndex = ItemIndex(count);
            var knownWord = true;
            for (var i = start; i < itemIndex && knownWord; ++i)
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
                Information.Item = Splitted[itemIndex];
            }
            else
            {
                QuestionType = QAType.NonMatching;
            }
        }

        protected abstract int ItemIndex(int count);

        protected abstract int StartFrom();

        public static bool IsQuestion(string input)
        {
            return !string.IsNullOrEmpty(input) && input.ToLower().Contains("how ");
        }
    }


}
