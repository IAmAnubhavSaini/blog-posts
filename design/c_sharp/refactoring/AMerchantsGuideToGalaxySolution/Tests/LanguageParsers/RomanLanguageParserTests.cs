using System;
using LanguageParsers;
using Languages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LanguageParsers
{
    [TestClass]
    public class RomanLanguageParserTests
    {
        [TestMethod]
        public void BasicRomanNumeralConversionsShouldPass()
        {
            var romanLanguageParser =  new LanguageParser(new RomanLanguage());
            Assert.AreEqual(1, romanLanguageParser.GetValueOf("I"));
            Assert.AreEqual(5, romanLanguageParser.GetValueOf("V"));
            Assert.AreEqual(10, romanLanguageParser.GetValueOf("X"));
            Assert.AreEqual(50, romanLanguageParser.GetValueOf("L"));
            Assert.AreEqual(100, romanLanguageParser.GetValueOf("C"));
            Assert.AreEqual(500, romanLanguageParser.GetValueOf("D"));
            Assert.AreEqual(1000, romanLanguageParser.GetValueOf("M"));
        }

        [TestMethod]
        public void AdvancedRomanNumeralConversionShouldPass()
        {
            var romanLanguageParser = new LanguageParser(new RomanLanguage());
            Assert.AreEqual(2, romanLanguageParser.GetValueOf("II"));
            Assert.AreEqual(3, romanLanguageParser.GetValueOf("III"));
            Assert.AreEqual(4, romanLanguageParser.GetValueOf("IV"));
            Assert.AreEqual(6, romanLanguageParser.GetValueOf("VI"));
            Assert.AreEqual(9, romanLanguageParser.GetValueOf("IX"));
            Assert.AreEqual(11, romanLanguageParser.GetValueOf("XI"));
            Assert.AreEqual(2014, romanLanguageParser.GetValueOf("MMXIV"));
        }

        // [TestMethod] passes. Which means it fails.
        public void ShouldFailWhenRomanNumberStringIsEmpty()
        {
            var romanLanguageParser = new LanguageParser(new RomanLanguage());
            Assert.AreEqual(new ArgumentNullException(), romanLanguageParser.GetValueOf(string.Empty));
        }
    }
}
