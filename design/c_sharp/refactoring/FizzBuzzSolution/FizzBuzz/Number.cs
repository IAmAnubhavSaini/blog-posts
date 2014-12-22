
namespace FizzBuzzFizzBuzz
{
    public class Number:ISaySomething
    {
        public int Value { get; private set; }
        public Number(int number)
        {
            Value = number;
        }
        public string Say()
        {
            return Value.ToString();
        }
    }
}
