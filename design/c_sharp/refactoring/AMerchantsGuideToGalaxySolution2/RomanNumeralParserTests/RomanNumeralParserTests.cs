using Languages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumeralParser;

namespace RomanNumeralParserTests
{
    [TestClass]
    public class RomanNumeralParserTests
    {
        [TestMethod]
        public void MakeSureThatRepeatedDLVThrowAnException()
        {
            var inputWithRepeatedDs = "DDD";
            var parser = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();
            try
            {
                Assert.AreEqual(1500, parser.ParseNumber(inputWithRepeatedDs));
                Assert.Fail("Exception is thrown when a D is repeated.");
            }
            catch { }
        }

        [TestMethod]
        public void MakeSureThatNonRepeatedDLVDoNotThrowException()
        {
            var inputWithoutRepeatedDs = "MDX";
            var parser = new RomanToDecimanlLikeNumeralParser<RomanLanguage>();
            Assert.AreEqual(1510, parser.ParseNumber(inputWithoutRepeatedDs));
        }
    }
}
