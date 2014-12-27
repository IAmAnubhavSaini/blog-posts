using System;

namespace ConferenceManager
{
    public class Talk
    {
        public string Title { get; private set; }
        public TimeSpan Duration { get; private set; }
        public Talk(string title, TimeSpan duration)
        {
            Title = title;
            Duration = duration;
        }
    }

    public class Lightning : Talk
    {
        public Lightning(string title)
            : base(title, new TimeSpan(0, 5, 0))
        {
        }
    }
}
