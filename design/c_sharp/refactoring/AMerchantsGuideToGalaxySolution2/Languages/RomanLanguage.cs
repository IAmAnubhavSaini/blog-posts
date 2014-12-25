using System;
using System.Collections.Generic;
using System.Linq;

namespace Languages
{
    public class RomanLanguage : IProvideLanguage
    {
        public Dictionary<char, int> ConversionData { get; private set; }
        public List<SanityRule> SanityRules()
        {
            var delegates = new List<SanityRule>
            {
                NonRepeatRule, NotMoreThanThreeRepeatRule, NonSubtractRule
            };

            return delegates;
        }

        private static void NonRepeatRule(string input)
        {
            var nonRepeatable = "DLV";
            for (var i = 0; i < input.Length - 1; ++i)
            {
                var next = i + 1;
                var curr = i;
                foreach (var ch in nonRepeatable.Where(ch => input[curr] == ch && input[curr] == input[next]))
                {
                    throw new Exception(ch + " cannot be repeated in Roman numerals.");
                }
            }
        }

        private void NotMoreThanThreeRepeatRule(string input)
        {
            var repeatableUpto3Times = "IXCM";
            for (var i = 0; i < input.Length - 3; i++)
            {
                foreach (var ch in repeatableUpto3Times)
                {
                    if (ch == input[i] && ch == input[i + 1] && ch == input[i + 2] && ch == input[i + 3])
                    {
                        throw new Exception(ch + " cannot be repeated more than 3 times.");
                    }
                }
            }
        }

        private void NonSubtractRule(string input)
        {
            var nonSubtractables = new[]
            {
                "VX", "VL", "VC", "VD", "VM",
                "LC", "LM", "LD", "LM",
                "DM"
            };
            foreach (var nonSubtractable in nonSubtractables)
            {
                if(input.Contains(nonSubtractable))
                    throw new Exception(nonSubtractable + " is not a allowd in Roman numerals.");
            }
            
        }
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
