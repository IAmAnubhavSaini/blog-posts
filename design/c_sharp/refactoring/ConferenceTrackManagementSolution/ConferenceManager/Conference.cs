using System.Collections.Generic;

namespace ConferenceManager
{
    public class Conference
    {
        public List<Track> Tracks { get; private set; }
        public Conference()
        {
            Tracks = new List<Track>();
        }
    }
}
