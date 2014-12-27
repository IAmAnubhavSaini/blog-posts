using System;

namespace ConferenceManager
{
    public class Session
    {
        public DateTime StartsAt { get; private set; }
        public DateTime EndsAt { get; private set; }
        public TimeSpan Duration { get; private set; }

        public Session(DateTime start, DateTime end, TimeSpan duration)
        {
            StartsAt = start;
            EndsAt = end;
            Duration = duration;
        }
    }
}
