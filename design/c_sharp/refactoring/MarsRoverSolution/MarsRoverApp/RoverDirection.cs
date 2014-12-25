
namespace MarsRoverApp
{
    public class RoverDirection
    {
        public RoverDirection(CompassDirection direction)
        {
            Direction = direction;
        }
        public CompassDirection Direction { get; private set; }

        public CompassDirection TurnLeft()
        {
            switch (Direction)
            {
                case CompassDirection.East: Direction = CompassDirection.North;
                    break;
                case CompassDirection.North: Direction = CompassDirection.West;
                    break;
                case CompassDirection.West: Direction = CompassDirection.South;
                    break;
                case CompassDirection.South: Direction = CompassDirection.East;
                    break;
            }
            return Direction;
        }
        public CompassDirection TurnRight()
        {
            switch (Direction)
            {
                case CompassDirection.East: Direction = CompassDirection.South;
                    break;
                case CompassDirection.North: Direction = CompassDirection.East;
                    break;
                case CompassDirection.West: Direction = CompassDirection.North;
                    break;
                case CompassDirection.South: Direction = CompassDirection.West;
                    break;
            }
            return Direction;
        }
    }
}
