
using System;

namespace App
{
    public class Question
    {
        public string Count { get; private set; }
        public string Unit { get; private set; }
        public string Value { get; private set; }
        public string Item { get; private set; }

        public static bool IsQuestion(string input)
        {
            return input.StartsWith("how", StringComparison.InvariantCultureIgnoreCase);
        }


    }

    public class MuchQuestion : Question
    {
        public MuchQuestion(string input)
        {
        }

    }

    public class ManyQuestion : Question
    {
        public ManyQuestion(string input)
        {
        }

    }

    public class QuestionFactory
    {
        public static Question GeneratioQuestion(string input)
        {
            if (input.Contains("much"))
                return new MuchQuestion(input);
            else if (input.Contains("many"))
                return new ManyQuestion(input);
            else
                return null;
        }
    }
}

