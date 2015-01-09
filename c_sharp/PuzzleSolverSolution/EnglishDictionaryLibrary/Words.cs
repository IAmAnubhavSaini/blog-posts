using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnglishDictionaryLibrary
{
    public class Words
    {
        private const string OxfordEnglishDictionary = "oxford_english_dictionary.txt";

        public IEnumerable<string> GetWords(string folderPath, string fileName = OxfordEnglishDictionary)
        {
            var words = new List<string>();
            if (Directory.Exists(folderPath))
            {
                if (File.Exists(folderPath + fileName))
                {
                    
                }
            }
            return words;
        }
    }
}
