using System;
using System.Collections.Generic;

namespace Languages
{
    public delegate void SanityRule(string input);

    public interface IProvideLanguage
    {
        Dictionary<char, int> ConversionData { get; }
        List<SanityRule> SanityRules();
    }
}
