using System;
using System.Collections.Generic;
using System.Linq;

namespace gallactic_money
{
    public class Information
    {
        // This is for "glob glob Silver is 34 Credits"
        public string Number; //== II if glob == I
        public string Item; // Silver
        public int Value; // == 34
        public string Unit; // == Credits


        public virtual void MakeInfo(string input, Dictionary<string, string> dict)
        {
            string[] splitted = input.Split(' ');
            // Assumption : string input contains single spaces
            int i = 0;
            try
            {
                for (i = 0;
                    i < splitted.Count() &&
                    dict.ContainsKey(splitted[i]);
                    ++i)
                {
                    Number += dict[splitted[i]];
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
            catch (System.IndexOutOfRangeException ioore)
            {
                Console.WriteLine("Data is not provided as agreed upon specification.");
                Console.WriteLine("Message : " + ioore.Message);
            }
        }

    }
}
