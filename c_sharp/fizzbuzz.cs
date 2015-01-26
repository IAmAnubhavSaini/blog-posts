using System;
using System.Collections.Generic;

namespace blogposts
{
    public class Rule
    {
        public int Number { get; private set; }
        public string Say { get; private set; }
        public Rule(int forNumber, string say)
        {
            this.Number = forNumber;
            this.Say = say;
        }
    }
    public static class Sayer
    {
        public static string Say(this int number, List<Rule> Rules)
        {
            var toSay = string.Empty;
            foreach (var rule in Rules)
            {
                if (number % rule.Number == 0)
                {
                    toSay += rule.Say;
                }
            }
            return string.IsNullOrEmpty(toSay) ? number.ToString() : toSay;
        }
    }
    class Runner
    {
        static void Main()
        {
            var rules = new List<Rule>{
                new Rule(3,"fizz"),
                new Rule(5, "buzz")
            };
            
            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine(i.Say(rules));
            }
        }
    }
}