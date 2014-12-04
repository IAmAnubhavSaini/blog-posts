using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorKata.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturnZeroWhenInputNumberStringIsEmpty()
        {
            var numbers = string.Empty;

            Assert.IsTrue(0 == Calculator.Add(numbers));
        }


    }
}
