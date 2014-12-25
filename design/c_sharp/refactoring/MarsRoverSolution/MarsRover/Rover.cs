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
        private readonly RoverDirection roverDirection;
        public Plane CurrentPlane { get; private set; }
        public string CommandToFollow { get; private set; }

        public RoverLocation CurrentRoverLocation { get; private set; }

        public Rover(Plane plane, string command, RoverLocation currentRoverLocation)
        {
            CurrentRoverLocation = currentRoverLocation;
            CurrentPlane = plane;
            CommandToFollow = command;
            roverDirection = new RoverDirection(currentRoverLocation.Direction);
        }

        public RoverLocation Operate()
        {
            var x = CurrentRoverLocation.Coordinates.X;
            var y = CurrentRoverLocation.Coordinates.Y;
            var direction = CurrentRoverLocation.Direction;

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
                        x = x < 0 ? 0 : x;
                        x = x > CurrentPlane.TopRightX ? CurrentPlane.TopRightX : x;
                        y = y < 0 ? 0 : y;
                        y = y > CurrentPlane.TopRightY ? CurrentPlane.TopRightY : y;
                        break;
                    case RoverCommand.L:
                        direction = roverDirection.TurnLeft();
                        break;
                    case RoverCommand.R:
                        direction = roverDirection.TurnRight();
                        break;
                    default:
                        throw new Exception("Unknown rover command");
                }
            }
            return new RoverLocation(new Point2D(x, y), direction);
        }

    }
}
