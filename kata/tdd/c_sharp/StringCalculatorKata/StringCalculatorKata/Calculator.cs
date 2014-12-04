using System;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            var sum = 0;
            foreach (var s in numbers.Split(','))
            {
                sum += int.Parse(s);
            }
            return sum;
        }
    }
}