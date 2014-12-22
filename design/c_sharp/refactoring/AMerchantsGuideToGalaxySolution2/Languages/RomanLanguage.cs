using System.Collections.Generic;

namespace Languages
{
    public class RomanLanguage : IProvideLanguage
    {
        public Dictionary<char, int> ConversionData { get; private set; }


        public RomanLanguage()
        {
            ConversionData = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
        }
    }
}
