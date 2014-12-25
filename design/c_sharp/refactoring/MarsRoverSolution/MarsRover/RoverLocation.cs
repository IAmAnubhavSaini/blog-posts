namespace MarsRover
{
    public class RoverLocation
    {
        public Point2D Coordinates { get; private set; }
        public CompassDirection Direction { get; private set; }
        public RoverLocation(Point2D point, CompassDirection direction)
        {
            Direction = direction;
            Coordinates = point;
        }
    }
}
