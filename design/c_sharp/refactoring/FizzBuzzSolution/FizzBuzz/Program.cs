
using System;
using System.Collections.Generic;

namespace FizzBuzzFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfSays = new List<ISaySomething>();
            for (var i = 1; i < 100; i++)
            {
                listOfSays.Add(FizzBuzzFactory.Generate(i));
            }
            foreach (var say in listOfSays)
            {
                Console.WriteLine(say.Say());
            }
        }
    }
}
