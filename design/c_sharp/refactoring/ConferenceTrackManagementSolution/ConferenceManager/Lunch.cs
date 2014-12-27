using System;

namespace ConferenceManager
{
    public class Lunch : Session {
        public Lunch(DateTime start, DateTime end, TimeSpan duration) 
            : base(start, end, duration)
        {
        }
    }
}
