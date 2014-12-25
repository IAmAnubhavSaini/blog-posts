namespace MarsRover
{
    public class Point2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
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
