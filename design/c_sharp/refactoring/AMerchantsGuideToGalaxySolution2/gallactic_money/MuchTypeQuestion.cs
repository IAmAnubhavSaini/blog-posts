using System.Collections.Generic;

namespace GuideToGalaxy
{
    public class MuchTypeQuestion : Question
    {
        public MuchTypeQuestion(string input, Dictionary<string, string> dictionary)
            : base(input, dictionary)
        {
        }

        protected override int ItemIndex(int count)
        {
            return Input.EndsWith("?") ? count - 1 : count;
        }

        protected override int StartFrom()
        {
            return 3; // start at fourth place, because first three are : how much is
        }
    }
}
