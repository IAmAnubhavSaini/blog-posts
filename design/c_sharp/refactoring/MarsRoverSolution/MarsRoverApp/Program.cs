
using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover;

namespace MarsRoverApp
{
    class Program
    {
        static void Main()
        {
            var rovers = new List<Rover>();
            var input = Console.ReadLine();
            if(string.IsNullOrEmpty(input))
                throw new Exception("Input not recieved.");
            var planeTopRightCoordinates = input.Split(' ');
            if (planeTopRightCoordinates.Count() != 2)
            {
                throw new Exception("Bad input");
            }
            var plane = new Plane(int.Parse(planeTopRightCoordinates[0]), int.Parse(planeTopRightCoordinates[1]));

            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                var locationStrings = input.Split(' ');
                if(locationStrings.Count()!=3)
                    throw new Exception("Bad input");
                var direction = CompassDirection.East;
                switch (locationStrings[2].ToUpper())
                {
                    case "N": direction = CompassDirection.North; 
                        break;
                    case "E": direction = CompassDirection.East;
                        break;
                    case "W" : direction = CompassDirection.West;
                        break;
                    case "S" : direction=CompassDirection.South;
                        break;
                    default: throw new Exception("Bad direction input.");
                }
                var location = new Location(int.Parse(locationStrings[0]),
                    int.Parse(locationStrings[1]), direction);

                var command = Console.ReadLine();
                if(string.IsNullOrEmpty(command)) throw new Exception("Command not received.");

                var rover = new Rover(plane, command, location);
                rovers.Add(rover);
            }

            foreach (var rover in rovers)
            {
                var finalLocation = rover.Operate();
                Console.WriteLine(finalLocation.CurrentX + " " + finalLocation.CurrentY + " " + finalLocation.CurrentDirection.ToString()[0]);
            }
        }
    }
}
