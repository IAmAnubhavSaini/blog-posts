
namespace MarsRoverApp
{
    public class Location
    {
        public int CurrentX { get; private set; }
        public int CurrentY { get; private set; }
        public CompassDirection CurrentDirection { get; private set; }

        public Location(int x, int y, CompassDirection direction)
        {
            CurrentDirection = direction;
            CurrentX = x;
            CurrentY = y;
        }
    }
}
