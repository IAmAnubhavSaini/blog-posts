using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverApp
{
    public class Plane
    {
        public Plane(int topRightX, int topRightY)
        {
            TopRightX = topRightX;
            TopRightY = topRightY;
        }

        public int TopRightX { get; private set; }

        public int TopRightY { get; private set; }
    }

    public enum CompassDirection
    {
        North, East, South, West
    }

    enum RoverCommand
    {
        L, R, M
    }

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

    public class Rover
    {
        
        private RoverDirection roverDirection;
        public Plane CurrentPlane { get; private set; }
        public string CommandToFollow { get; private set; }

        public Location CurrentLocation { get; private set; }
        public Rover(Plane plane, string command, Location currentLocation)
        {
            CurrentLocation = currentLocation;
            CurrentPlane = plane;
            CommandToFollow = command;
            roverDirection = new RoverDirection(currentLocation.CurrentDirection);
        }

        public Location Operate()
        {
            var x = CurrentLocation.CurrentX;
            var y = CurrentLocation.CurrentY;
            var direction = CurrentLocation.CurrentDirection;

            foreach (var command in CommandToFollow)
            {
                RoverCommand cmd;
                Enum.TryParse(command.ToString(), out cmd);
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
                                x--; break;
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
                    default: throw new Exception("Unknown command");
                }
            }
            return new Location(x, y, direction);
        }

    }
}
