
using Languages;

namespace Guide
{
    public class ManyTypeQuestion<T> : Question<T> where T: IProvideLanguage, new ()
    {
        public ManyTypeQuestion(string input, Knowledge<T> knowledge) :
            base(input, knowledge)
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
