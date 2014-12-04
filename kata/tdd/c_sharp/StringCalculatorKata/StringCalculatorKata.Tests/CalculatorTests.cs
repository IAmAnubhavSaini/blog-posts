using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorKata.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void ShouldReturnZeroWhenInputNumberStringIsEmpty()
        {
            var numbers = string.Empty;

            Assert.IsTrue(0 == Calculator.Add(numbers));
        }

        [TestMethod]
        public void ShouldReturnSumOfTwoNumbers()
        {
            const string numbers = "1, 2";

            Assert.IsTrue(3 == Calculator.Add(numbers));
        }

        [TestMethod]
        public void ShouldReturnSumOfThreeNumbers()
        {
            const string numbers = "1, 2, 3";

            Assert.IsTrue(6 == Calculator.Add(numbers));
        }
        
        [TestMethod]
        public void ShouldReturnSumOfThreeNumbersWithDifferentDelimeters()
        {
            const string numbers = "1\n2, 3";

            Assert.IsTrue(6 == Calculator.Add(numbers));
        }
        
        [TestMethod]
        public void ShouldFailSumOfThreeNumbersWithWrongDelimeters()
        {
            const string numbers = "1,\n";

            Assert.IsFalse(1 == Calculator.Add(numbers));
        }


    }
}
