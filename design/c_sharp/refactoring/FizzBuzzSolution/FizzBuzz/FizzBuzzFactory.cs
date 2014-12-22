
namespace FizzBuzzFizzBuzz
{
    public static class FizzBuzzFactory
    {
        public static ISaySomething Generate(int number)
        {
            if (number % 15 == 0) return new FizzBuzz();
            if (number % 5 == 0) return new Buzz();
            if (number % 3 == 0) return new Fizz();
            return new Number(number);
        }
    }
}
