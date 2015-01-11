using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnglishDictionaryLibrary
{
    public class Words
    {
        public Words(IEnumerable<string> allWords)
        {
            AllWords = allWords;
        }

        public IEnumerable<string> AllWords { get; set; }

        public IEnumerable<string> GetWordsThatContain(IEnumerable<char> letters, int minLenght, int maxLength)
        {
            var words = AllWords.Where(w => w.Length >= minLenght && w.Length <= maxLength);
            return letters.Aggregate(words, (current, l) => current.Where(w => w.Contains(l)));
        }
    }
}
