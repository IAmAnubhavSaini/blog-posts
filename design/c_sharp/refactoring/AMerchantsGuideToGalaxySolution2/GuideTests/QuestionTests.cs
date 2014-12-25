using Guide;
using Languages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuideTests
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void IsQuestionShouldReturnTrueWhenQuestionStartsWithHow()
        {
            var question = "how much is ABC ABC ?";
            Assert.AreEqual(true, Question<RomanLanguage>.IsQuestion(question));
        }
        [TestMethod]
        public void IsQuestionShouldReturnFalseWhenQuestionDoesNotStartWithHow()
        {
            var question = "hey mister, how much is ABC ABC ?";
            Assert.AreEqual(false, Question<RomanLanguage>.IsQuestion(question));
        }

        [TestMethod]
        public void StringsCanBeQuestionEvenWithoutQuestionMark()
        {
            var questionMarked = "how much is ABC ABC ?";
            var question = "how much is ABC ABC";
            Assert.AreEqual(Question<RomanLanguage>.IsQuestion(question), Question<RomanLanguage>.IsQuestion(questionMarked));
        }




    }
}
