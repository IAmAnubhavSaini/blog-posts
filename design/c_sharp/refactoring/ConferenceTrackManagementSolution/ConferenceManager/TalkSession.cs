using System;
using System.Collections.Generic;

namespace ConferenceManager
{
    public class TalkSession : Session
    {
        public List<Talk> Talks { get; private set; } 
        public TalkSession(DateTime start, DateTime end, TimeSpan duration) 
            : base(start, end, duration)
        {
            Talks = new List<Talk>();
        }
    }
}
