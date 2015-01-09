
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ConferenceManager;

namespace ConsoleApp
{
    class Program
    {
        private static readonly int EndTime = 17;
        private static readonly int StartTime = 9;
        private static readonly int LunchDuration = 1;
        private static readonly int MaxTrackDuration = (EndTime - StartTime - LunchDuration)*60;
        private static readonly int MorningSessionDuration = 3;
        private static readonly int MaxEveningSessionDuration = 4;
        static void Main(string[] args)
        {
            var talks = GenerateTalks();
            var totalTime = 0;
            foreach (var talk in talks.OrderByDescending(t=>t.Duration))
            {
                totalTime += talk.Duration.Minutes;
            //    Console.WriteLine(talk.Title + ", " + talk.Duration);
            }
            var trackCount = (totalTime/MaxTrackDuration)+1;
            //Console.WriteLine("Total number of tracks: "+ trackCount);

            var conf = new Conference(trackCount, talks);
            conf.PrintTracks();
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
