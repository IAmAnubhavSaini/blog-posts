using System.Collections.Generic;
using System.Linq;

namespace EnglishDictionaryLibrary
{
    public class Words
    {
        public Words(IEnumerable<string> allWords)
        {
            AllWords = allWords.ToList();
        }

        private List<string> AllWords { get; set; }

        private IEnumerable<string> ContainAllLetters(string letters, int minLenght, int maxLength)
        {
            var words = AllWords.Where(w => w.Length >= minLenght && w.Length <= maxLength);
            return letters.Aggregate(words, (current, l) => current.Where(w => w.Contains(l)));
        }

        public IEnumerable<string> ContainAllLettersAndNoOther(string letters, int minLenght, int maxLength)
        {
            var words = ContainAllLetters(letters, minLenght, maxLength).ToList();
            var removedWords = words.Where(word => word.Any(letter => !letters.Contains(letter))).ToList();
            words.RemoveAll(removedWords.Contains);
            return words;
        }
    }
}
