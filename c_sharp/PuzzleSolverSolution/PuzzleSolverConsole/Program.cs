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
        static void Main(string[] args)
        {
            UsageDetails();
            var pathToWordListFile = args.Length != 0 ? args[0] : Console.ReadLine();
            if (!File.Exists(pathToWordListFile))
            {
                Console.WriteLine("File not found at : {0}", pathToWordListFile);
                return;
            }
            var input = ReadAllLinesFromFile(pathToWordListFile);
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
            var minLenghtOfDesiredWords = int.Parse(args.Length > 0 && args[2] != null ? args[2] : (Console.ReadLine() ?? "4"));
            var maxLenghtOfDesiredWords = int.Parse(args.Length > 0 && args[3] != null ? args[3] : (Console.ReadLine() ?? "4"));

            foreach (var word in wordType.GetWordsThatContainAllLetters(letters, minLenghtOfDesiredWords, maxLenghtOfDesiredWords))
            {
                Console.WriteLine(word);
            }
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
