using System;
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

        public List<string> AllWords { get; private set; }

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

        public IEnumerable<string> WordsThatMustContain(IEnumerable<string> words, string mustContain, int minLen, int maxLen)
        {
            return words.Where(word => word.Length >= minLen && word.Length <= maxLen && word.Contains(mustContain)).ToList();
        }

        public List<string> AllCombinationedWords(List<string> words, string input, int minLen, int maxLen)
        {
            var outputList = new List<string>();
            if (minLen > maxLen)
                return null;
            
            var allCombinationedWords = AllCombinationedWords(words, input.Substring(0, 4), minLen, maxLen - 1);
            if (allCombinationedWords != null) outputList.AddRange(allCombinationedWords);
            allCombinationedWords = AllCombinationedWords(words, input.Substring(0, 4), minLen+1, maxLen);
            if (allCombinationedWords != null) outputList.AddRange(allCombinationedWords);
            allCombinationedWords = AllCombinationedWords(words, input.Substring(0, 4), minLen + 1, maxLen-1);
            if (allCombinationedWords != null) outputList.AddRange(allCombinationedWords);
            
            var NewWords = words.Where(w => w.Length >= minLen && w.Length <= maxLen).ToList();
            input.Aggregate(NewWords, (w, l) => w.Where(t => t.Contains(l)).ToList());
            outputList.AddRange(NewWords);

            return outputList;
        }
    }
}
