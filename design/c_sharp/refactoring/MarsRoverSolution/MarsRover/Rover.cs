using System;
using System.Globalization;
namespace MarsRover
{
    enum RoverCommand
    {
        L, R, M
    }

    public class Rover
    {
        private readonly RoverNavigation roverNavigation;
        public Plane CurrentPlane { get; private set; }
        public string CommandToFollow { get; private set; }

        public RoverLocation StartLocation { get; private set; }
        public RoverLocation EndLocation { get; private set; }

        public Rover(Plane plane, string command, RoverLocation startLocation)
        {
            StartLocation = startLocation;
            CurrentPlane = plane;
            CommandToFollow = command;
            roverNavigation = new RoverNavigation(startLocation.Direction);
        }

        public RoverLocation Operate()
        {
            var x = StartLocation.Coordinates.X;
            var y = StartLocation.Coordinates.Y;
            var direction = StartLocation.Direction;

            foreach (var command in CommandToFollow)
            {
                RoverCommand cmd;
                Enum.TryParse(command.ToString(CultureInfo.InvariantCulture), out cmd);
                switch (cmd)
                {
                    case RoverCommand.M:
                        switch (direction)
                        {
                            case CompassDirection.East:
                                x++;
                                break;
                            case CompassDirection.North:
                                y++;
                                break;
                            case CompassDirection.South:
                                y--;
                                break;
                            case CompassDirection.West:
                                x--;
                                break;
                        }
                        x = SanitizeXCoordinate(x);
                        y = SanitizeYCoordinate(y);
                        break;
                    case RoverCommand.L:
                        direction = roverNavigation.TurnLeft();
                        break;
                    case RoverCommand.R:
                        direction = roverNavigation.TurnRight();
                        break;
                    default:
                        throw new Exception("Unknown rover command");
                }
            }
            EndLocation = new RoverLocation(new Point2D(x, y), direction);
            return EndLocation;
        }

        private int SanitizeYCoordinate(int y)
        {
            y = y < 0 ? 0 : y;
            y = y > CurrentPlane.TopRightY ? CurrentPlane.TopRightY : y;
            return y;
        }

        private int SanitizeXCoordinate(int x)
        {
            x = x < 0 ? 0 : x;
            x = x > CurrentPlane.TopRightX ? CurrentPlane.TopRightX : x;
            return x;
        }
    }
}
