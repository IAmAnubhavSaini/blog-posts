﻿using System;
using System.Linq;
using Languages;

namespace Guide
{
    public class Information<T> where T:IProvideLanguage, new ()
    {
        // This is for "glob glob Silver is 34 Credits"
        public string Number; //== II if glob == I
        public string Item; // Silver
        public int Value; // == 34
        public string Unit; // == Credits
        
        public virtual void MakeInfo(string input, Knowledge<T> knowledge)
        {
            var splitted = input.Split(' ');
            // Assumption : string input contains single spaces
            try
            {
                int i;
                for (i = 0;
                    i < splitted.Count() &&
                    knowledge.ForeignLanguageToKnownLanguageDictionary.ContainsKey(splitted[i]);
                    ++i)
                {
                    Number += knowledge.ForeignLanguageToKnownLanguageDictionary[splitted[i]];
                }

                // by now, Number contains only the roman numerals
                Item = splitted[i];

                // Assumption : next word is "is"
                // incrementing i twice thusly to reach Value
                i += 2;
                Value = int.Parse(splitted[i]);

                // Assumption : Unit is single word
                ++i;
                Unit = splitted[i];
            }
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine("Data is not provided as agreed upon specification.");
                Console.WriteLine("Message : " + ioore.Message);
            }
        }

    }
}
