using System;
using System.Collections.Generic;
using System.Text;

namespace BlogPosts.Stringology
{
    public class PatternMatching
    {
        public bool NaiveMatching(string pattern, string text)
        {
            return text.Contains(pattern);
        }

        public List<int> NaiveMatching(char[] pattern, char[] text)
        {
            var positions = new List<int>();
            for (var i = 0; i < text.Length; i++)
            {
                var j = 0;
                for (j = 0; j < pattern.Length; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }
                if (j == pattern.Length)
                {
                    positions.Add(i);
                    i += j;
                }
            }
            return positions;
        }
    }

    class Runner
    {
        static void Main()
        {
            PatternMatching pm = new PatternMatching();
            var pattern = "pat";
            var texts = new List<string>{
                "parta parta pat pat pattatap tap tap pat pat parta",
                "rat rattat paat ratpttp part ppt"
            };
            foreach (var text in texts)
            {
                if (pm.NaiveMatching(pattern, text))
                {
                    foreach (var position in pm.NaiveMatching(pattern.ToCharArray(), text.ToCharArray()))
                    {
                        Console.WriteLine("{0} found at {1}", pattern, position);
                    }
                }
                else
                {
                    Console.WriteLine("{0} not found in {1}", pattern, text);
                }
            }
        }
    }
}