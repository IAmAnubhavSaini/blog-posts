using System.Collections.Generic;

namespace GuideToGalaxy
{
    public class MuchTypeQuestion : Question, IProvideQuestion
    {
        public MuchTypeQuestion(string input, Dictionary<string, string> dictionary) :
            base(input, dictionary)
        {
        }
    }
}
