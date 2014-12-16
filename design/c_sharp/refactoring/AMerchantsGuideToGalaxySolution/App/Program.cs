
using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {

        static void Main(string[] args)
        {
            var list = new List<LanguageFact>();
            var langFact = new LanguageFact("A is I.");
            if (langFact.IsLanguageFact)
            {
                list.Add(langFact);
            }
            Console.WriteLine(list.Count);
        }
    }
}
