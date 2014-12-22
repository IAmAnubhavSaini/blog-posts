using System.Collections.Generic;

namespace GuideToGalaxy
{
    public class ManyTypeQuestion : Question, IProvideQuestion
    {
        public ManyTypeQuestion(string input, Dictionary<string, string> dictionary) :
            base(input, dictionary)
        {
        }
    }
}
