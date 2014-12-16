using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.App
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void ShouldPassWhenInputIsAQuestionAndHowIsSmallLettered()
        {
            const string input = "how much is ABC ABC";
            Assert.AreEqual(true, Question.IsQuestion(input));
        }

        [TestMethod]
        public void ShouldPassWhenInputIsAQuestionAndHowIsCapitalLettered()
        {
            const string input = "HOW much is ABC ABC";
            Assert.AreEqual(true, Question.IsQuestion(input));
        }

        [TestMethod]
        public void ShouldPassWhenInputIsAQuestionAndHowIsMixedLettered()
        {

            Assert.AreEqual(true, Question.IsQuestion("HOw much is ABC ABC"));
            Assert.AreEqual(true, Question.IsQuestion("HoW much is ABC ABC"));
            Assert.AreEqual(true, Question.IsQuestion("hOW much is ABC ABC"));
        }

        [TestMethod]
        public void TestIfStringIsAQuestionA()
        {
            const string input = ".. meow   much is ABC   ABC?";
            Assert.AreEqual(false, Question.IsQuestion(input));
        }

        [TestMethod]
        public void TestIfStringIsAQuestionB()
        {
            const string input = "h ow   much is ABC   ABC ?";
            Assert.AreEqual(false, Question.IsQuestion(input));
        }

        [TestMethod]
        public void TestIfStringIsAQuestionContainsHowInMiddle()
        {
            const string input = "much is how ABC   ABC ?";
            Assert.AreEqual(false, Question.IsQuestion(input));
        }
    }
}
