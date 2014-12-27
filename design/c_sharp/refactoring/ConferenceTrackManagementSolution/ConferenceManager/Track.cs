namespace ConferenceManager
{
    public class Track
    {
        public TalkSession MorningSession { get; private set; }
        public TalkSession AfterNoonSession { get; private set; }
        public Lunch Lunch { get; private set; }
        public Networking NetworkingSession { get; private set; }
    }
}
