using System;

namespace ConferenceManager
{
    public class Talk : Session
    {
        public string Title { get; private set; }
        public Talk(string title, DateTime start, DateTime end, TimeSpan duration)
            : base(start, end, duration)
        {
            Title = title;
        }
    }
}
