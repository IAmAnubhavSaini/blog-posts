using System.Collections.Generic;

namespace ConferenceManager
{
    public class Track
    {
        public List<Talk> Talks { get; private set; }
        public TalkSession MorningSession { get; private set; }
        public TalkSession AfterNoonSession { get; private set; }
        public Lunch Lunch { get; private set; }
        public Networking NetworkingSession { get; private set; }

        public Track(
            TalkSession morningSession, TalkSession afterNoonSession,
            Lunch lunch, Networking networkingSession)
        {
            MorningSession = morningSession;
            AfterNoonSession = afterNoonSession;
            Lunch = lunch;
            NetworkingSession = networkingSession;
        }

        public Track()
        {
            Talks = new List<Talk>();
        }
        public void AddTalk(Talk talk)
        {
            Talks.Add(talk);
        }
    }
}
