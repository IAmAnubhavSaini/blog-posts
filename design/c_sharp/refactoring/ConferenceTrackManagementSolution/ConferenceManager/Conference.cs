using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceManager
{
    public class Conference
    {
        public Track[] Tracks { get; private set; }
        public int TrackCount { get; private set; }
        public Conference(int count, IEnumerable<Talk> talks)
        {
            TrackCount = count;
            Tracks = new Track[TrackCount];
            SetupTracks(talks);
        }

        private void SetupTracks(IEnumerable<Talk> talks)
        {
            var allTalkArray = talks.OrderByDescending(t => t.Duration).ToArray();
            InitializeTracks();
            for (var j = 0; j < TrackCount; j++)
            {
                for (var i = j + 0; i < allTalkArray.Length && allTalkArray[i] != null; i += TrackCount)
                {
                    Tracks[j].AddTalk(allTalkArray[i]);
                }
            }
        }

        private void InitializeTracks()
        {
            for (var i = 0; i < TrackCount; i++)
            {
                Tracks[i] = new Track();
            }
        }

        public void PrintTracks()
        {
            for (var i = 0; i < TrackCount; i++)
            {
                Console.WriteLine("Track {0}", i+1);
                foreach (var talk in Tracks[i].Talks)
                {
                    Console.WriteLine(talk.Duration + ": " + talk.Title);
                }
            }
        }
    }
}
