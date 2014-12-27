using System;

namespace ConferenceManager
{
    public class Networking:Session
    {
        public Networking(DateTime start, DateTime end, TimeSpan duration) 
            : base(start, end, duration)
        {
        }
    }
}
