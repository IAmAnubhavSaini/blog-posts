using System.Collections.Generic;

namespace ConferenceManager
{
    public class AcceptanceCriteria
    {
        public delegate bool ConferenceFitness(Conference conf);
        public delegate bool TrackFitness(Track track);
        public delegate bool LunchFitness(Lunch lunch);
        public delegate bool NetworkingFitness(Networking networking);
        public delegate bool TalkSessionFitness(TalkSession talkSession);

        public List<ConferenceFitness> ConferenceFitnessCriteria { get; private set; }
        public List<TrackFitness> TrackFitnessCriteria { get; private set; }
        public List<LunchFitness> LunchFitnessCriteria { get; private set; }
        public List<NetworkingFitness> NetworkingFitnessCriteria { get; private set; }
        public List<TalkSessionFitness> TalkSessionFitnessCriteria { get; private set; }

        public AcceptanceCriteria()
        {
            ConferenceFitnessCriteria = new List<ConferenceFitness>();
            TrackFitnessCriteria = new List<TrackFitness>();
            LunchFitnessCriteria = new List<LunchFitness>();
            NetworkingFitnessCriteria = new List<NetworkingFitness>();
            TalkSessionFitnessCriteria = new List<TalkSessionFitness>();
        }
    }
}
