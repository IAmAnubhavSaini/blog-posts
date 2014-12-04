using System.Linq;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Split(',').Length > 3)
                return 0;
            return string.IsNullOrEmpty(numbers) ? 0 : numbers.Split(',').Sum(num => int.Parse(num));
        }
    }
}