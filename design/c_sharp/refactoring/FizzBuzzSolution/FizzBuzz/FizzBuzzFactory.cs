
namespace FizzBuzzFizzBuzz
{
    public static class FizzBuzzFactory
    {
        public static ISaySomething Generate(int number)
        {
            if (number%15 == 0) return new FizzBuzz();
            else if (number%5 == 0) return new Buzz();
            else return new Fizz();
        }
    }
}
