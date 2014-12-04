using System.Linq;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            return string.IsNullOrEmpty(numbers) ? 0 : numbers.Split(',').Sum(num => int.Parse(num));
        }
    }
}