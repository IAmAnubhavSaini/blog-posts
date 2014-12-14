using System;
using LanguageParsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LanguageParsers
{
    [TestClass]
    public class RomanLanguageParserTests
    {
        [TestMethod]
        public void BasicRomanNumeralConversionsShouldPass()
        {
            Assert.AreEqual(1, RomanLanguageParser.GetValueOfRomanNumber("I"));
            Assert.AreEqual(5, RomanLanguageParser.GetValueOfRomanNumber("V"));
            Assert.AreEqual(10, RomanLanguageParser.GetValueOfRomanNumber("X"));
            Assert.AreEqual(50, RomanLanguageParser.GetValueOfRomanNumber("L"));
            Assert.AreEqual(100, RomanLanguageParser.GetValueOfRomanNumber("C"));
            Assert.AreEqual(500, RomanLanguageParser.GetValueOfRomanNumber("D"));
            Assert.AreEqual(1000, RomanLanguageParser.GetValueOfRomanNumber("M"));
        }

        [TestMethod]
        public void AdvancedRomanNumeralConversionShouldPass()
        {
            Assert.AreEqual(2, RomanLanguageParser.GetValueOfRomanNumber("II"));
            Assert.AreEqual(3, RomanLanguageParser.GetValueOfRomanNumber("III"));
            Assert.AreEqual(4, RomanLanguageParser.GetValueOfRomanNumber("IV"));
            Assert.AreEqual(6, RomanLanguageParser.GetValueOfRomanNumber("VI"));
            Assert.AreEqual(9, RomanLanguageParser.GetValueOfRomanNumber("IX"));
            Assert.AreEqual(11, RomanLanguageParser.GetValueOfRomanNumber("XI"));
            Assert.AreEqual(2014, RomanLanguageParser.GetValueOfRomanNumber("MMXIV"));
        }

        [TestMethod]
        public void ShouldFailWhenRomanNumberStringIsEmpty()
        {
            Assert.AreEqual(new ArgumentNullException(),RomanLanguageParser.GetValueOfRomanNumber(string.Empty));
        }
    }
}
