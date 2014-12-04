using System.Linq;

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
            var numberArray = numbers.Split(new[] {',', '\n'});
            return numberArray.Sum(num => int.Parse(num));
            //.Where(s=>!string.IsNullOrEmpty(s))
        }
    }
}