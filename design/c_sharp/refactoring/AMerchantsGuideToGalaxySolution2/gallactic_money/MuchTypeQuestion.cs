using System.Collections.Generic;
using Languages;

namespace GuideToGalaxy
{
    public class MuchTypeQuestion<T> : Question<T> where T : IProvideLanguage, new()
    {
        public MuchTypeQuestion(string input, Knowledge<T> knowledge )
            : base(input, knowledge)
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
