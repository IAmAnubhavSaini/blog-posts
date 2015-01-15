using System.Globalization;
using EnglishDictionaryLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PuzzleSolverConsole
{
    class Program
    {
        private static string GetWordListPath(IList<string> args)
        {
            if (args == null) throw new ArgumentNullException("args");
            return args.Count != 0 ? args[0] : Console.ReadLine();
        }

        static void Main(string[] args)
        {
            UsageDetails();
            var wordListFilePath = GetWordListPath(args);
            if (wordListFilePath == null || !File.Exists(wordListFilePath))
            {
                Console.WriteLine("File not found at : {0}", wordListFilePath);
                return;
            }
            var words = InstantiateWords(wordListFilePath);

            var s = args.Length > 0 && args[1].Length > 0 ? args[1] : Console.ReadLine();
            string letters;
            if (!string.IsNullOrEmpty(s))
            {
                letters = s;
            }
            else
            {
                Console.WriteLine("Letters not provided.");
                return;
            }
            var minLenghtOfDesiredWords = GetMinLenghtOfDesiredWords(args);
            var maxLenghtOfDesiredWords = GetMaxLenghtOfDesiredWords(args);

            foreach (var word in words.ContainAllLettersAndNoOther(letters, minLenghtOfDesiredWords, maxLenghtOfDesiredWords))
            {
                Console.WriteLine(word);
            }
            var allLenghtWords = words.AllCombinationedWords(words.AllWords, letters, minLenghtOfDesiredWords,
                maxLenghtOfDesiredWords);
            var constrainedWords = words.WordsThatMustContain(allLenghtWords, letters[0].ToString(CultureInfo.InvariantCulture),
                minLenghtOfDesiredWords, maxLenghtOfDesiredWords);
            foreach (var word in constrainedWords)
            {
                Console.WriteLine(word);
            }
        }

        private static Words InstantiateWords(string wordListFilePath)
        {
            var input = ReadAllLinesFromFile(wordListFilePath);
            var wordsList = GetWords(input);
            var wordType = new Words(wordsList);
            return wordType;
        }

        private static int GetMaxLenghtOfDesiredWords(string[] args)
        {
            return int.Parse(args.Length > 0 && args[3] != null ? args[3] : (Console.ReadLine() ?? "4"));
        }

        private static int GetMinLenghtOfDesiredWords(string[] args)
        {
            return int.Parse(args.Length > 0 && args[2] != null ? args[2] : (Console.ReadLine() ?? "4"));
        }

        private static void UsageDetails()
        {
            Console.WriteLine("If you haven't invoked the program using following style then you need to enter details.");
            Console.WriteLine("<program> <word list full path> <min word len> <max word len>");
        }

        private static IEnumerable<string> GetWords(string input)
        {
            var allLines = input.Split('\n').ToList();
            return allLines.Select(line => line.Split(' ')[0]).ToList();
        }

        private static string ReadAllLinesFromFile(string pathToWordListFile)
        {
            var reader = new StreamReader(pathToWordListFile);
            var input = reader.ReadToEnd().ToLower(CultureInfo.InvariantCulture);
            reader.Close();
            reader.Dispose();
            return input;
        }
    }
}
