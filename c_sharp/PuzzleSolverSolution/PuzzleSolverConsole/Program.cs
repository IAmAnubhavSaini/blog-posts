using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnglishDictionaryLibrary;

namespace PuzzleSolverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UsageDetails();
            var pathToOxfordEnglishDictionary = args.Length != 0 ? args[0] : Console.ReadLine();
            if (!File.Exists(pathToOxfordEnglishDictionary))
            {
                Console.WriteLine("File not found at : {0}", pathToOxfordEnglishDictionary);
                return;
            }
            var input = ReadLinesFromOEd(pathToOxfordEnglishDictionary);
            var wordsList = GetWords(input);
            var wordType = new Words(wordsList);


            var s = args.Length > 0 && args[1].Length > 0 ? args[1] : Console.ReadLine();
            char[] letters;
            if (s != null)
                letters = s.ToCharArray();
            else
            {
                Console.WriteLine("Letters not provided.");
                return;
            }
            var minLenghtOfDesiredWords = int.Parse(args.Length > 0 && args[2] != null ? args[2] : Console.ReadLine());
            var maxLenghtOfDesiredWords = int.Parse(args.Length > 0 && args[3] != null ? args[3] : Console.ReadLine());

            foreach (var word in wordType.GetWordsThatContain(letters, minLenghtOfDesiredWords, maxLenghtOfDesiredWords))
            {
                Console.WriteLine(word);
            }
        }

        private static void UsageDetails()
        {
            Console.WriteLine("If you haven't invoked the program using following style then you need to enter details.");
            Console.WriteLine("<program> <oxford_english_dict.txt> <minLength> <maxLength>");
        }

        private static IEnumerable<string> GetWords(string input)
        {
            var allLines = input.Split('\n').ToList();
            return allLines.Select(line => line.Split(' ')[0]).ToList();
        }

        private static string ReadLinesFromOEd(string pathToOxfordEnglishDictionary)
        {
            var oedReader = new StreamReader(pathToOxfordEnglishDictionary);
            var input = oedReader.ReadToEnd();
            oedReader.Close();
            oedReader.Dispose();
            return input;
        }
    }
}
