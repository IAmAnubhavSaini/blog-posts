using System.Collections.Generic;

namespace GuideToGalaxy
{
    public class ManyTypeQuestion : Question
    {
        public ManyTypeQuestion(string input, Dictionary<string, string> dictionary) :
            base(input, dictionary)
        {
        }

        protected override int ItemIndex(int count)
        {
            return Input.EndsWith("?") ? count - 2 : count - 1;
        }

        protected override int StartFrom()
        {
            return 4; // starts at 5th place because first 4 are "how many Unit is"
        }
    }
}
