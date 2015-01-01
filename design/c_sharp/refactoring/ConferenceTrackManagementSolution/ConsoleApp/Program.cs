﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ConferenceManager;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var talks = GenerateTalks();
            foreach (var talk in talks.OrderByDescending(t=>t.Duration))
            {
                Console.WriteLine(talk.Title + ", " + talk.Duration);
            }
        }

        static IEnumerable<Talk> GenerateTalks()
        {
            var talks = new List<Talk>();
            var input = "";
            while (!string.IsNullOrEmpty(input = Sanitize(Console.ReadLine())))
            {
                talks.Add(GenerateTalk(input));
            }
            return talks;
        }

        private static Talk GenerateTalk(string input)
        {
            if (input.Contains("lightning"))
            {
                return new Lightning(Sanitize(input.Replace("lightning", "")));
            }
            else
            {
                var minString = input.Split(' ')[input.Split(' ').Length - 1];
                var title = Sanitize(input.Replace(minString, ""));
                var duration = int.Parse(Regex.Match(input, @"\d+").Value);
                return new Talk(title, new TimeSpan(0, duration, 0));
            }
        }

        private static string Sanitize(string input)
        {
            return input.Trim().RemoveConsecutiveSpaces();
        }
    }
}