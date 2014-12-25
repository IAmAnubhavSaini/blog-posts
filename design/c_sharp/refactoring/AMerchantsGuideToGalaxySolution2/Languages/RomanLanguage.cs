using System;
using System.Collections.Generic;

namespace Languages
{
    public class RomanLanguage : IProvideLanguage
    {
        public Dictionary<char, int> ConversionData { get; private set; }
        public List<SanityRule> SanityRules()
        {
            var rules = new List<SanityRule>
            {
                NonRepeatRule, NotMoreThanThreeRepeatRule, NonSubtractRule
            };
            return rules;
        }

        private static void NonRepeatRule(string input)
        {
            var nonRepeatables = new[]
            {
                "DD", "LL", "VV"
            };
            foreach (var nonRepeatable in nonRepeatables)
            {
                if (input.Contains(nonRepeatable))
                {
                    throw new Exception(nonRepeatable + " is not allowed in Roman numerals.");
                }
            }
        }

        private void NotMoreThanThreeRepeatRule(string input)
        {
            var nonRepeatables = new []
            {
                "IIII", "XXXX", "CCCC", "MMMM"
            };
            foreach (var nonRepeatable in nonRepeatables)
            {
                if(input.Contains(nonRepeatable))
                    throw new Exception(nonRepeatable + " is not allowed in Roman numerals.");
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
