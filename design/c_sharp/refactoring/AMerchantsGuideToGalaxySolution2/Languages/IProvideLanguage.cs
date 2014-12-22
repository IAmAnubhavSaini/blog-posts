using System.Collections.Generic;

namespace Languages
{
    public interface IProvideLanguage
    {
        Dictionary<char, int> ConversionData { get; }
    }
}
