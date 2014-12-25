
using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover;

namespace MarsRoverApp
{
    class Program
    {
        private static void PrintUsageInfo()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("<app.exe> run < <input>: for running the program with indirected input file.");
            Console.WriteLine("<app.exe> test : for running self checking tests.");
        }
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                PrintUsageInfo();
                return;
            }
            RunProper(args[0]);
        }

        private static void RunProper(string filter)
        {
            if (filter.Equals("run"))
            {
                RunMission();
            }
            else if (filter.Equals("test"))
            {
                SelfTest();
            }
            else
            {
                PrintUsageInfo();
            }
        }

        private static void SelfTest()
        {
            throw new NotImplementedException();
        }

        private static void RunMission()
        {
            string input;
            var rovers = new List<Rover>();

            var plane = GetPlane();
            while (!string.IsNullOrEmpty(input = ReadLocation()))
            {
                var location = GetLocation(input);
                var command = GetCommand();

                rovers.Add(new Rover(plane, command, location));
            }

            OperateRoversAndOutput(rovers);
        }

        private static void OperateRoversAndOutput(IEnumerable<Rover> rovers)
        {
            foreach (var finalLocation in rovers.Select(rover => rover.Operate()))
            {
                Console.WriteLine(finalLocation.CurrentX + " " + finalLocation.CurrentY + " " +
                                  finalLocation.CurrentDirection.ToString()[0]);
            }
        }

        private static Plane GetPlane()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                throw new Exception("Plane's right top coordinates not received. Should be in X Y format.");
            var planeTopRightCoordinates = input.Split(' ');
            if (planeTopRightCoordinates.Count() != 2)
            {
                throw new Exception("Wrong number of plane coordinates.");
            }
            var plane = new Plane(int.Parse(planeTopRightCoordinates[0]), int.Parse(planeTopRightCoordinates[1]));
            return plane;
        }

        private static string GetCommand()
        {
            var command = Console.ReadLine();
            if (string.IsNullOrEmpty(command))
                throw new Exception("Command not received.");
            return command;
        }

        private static string ReadLocation()
        {
            return Console.ReadLine();
        }

        private static string[] GetLocationStrings(string input)
        {
            var locationStrings = input.Split(' ');
            if (locationStrings.Count() != 3)
                throw new Exception("Location string should be in X, Y, L format, where X, Y are integer and L is one of N, E, S or W.");
            return locationStrings;
        }

        private static Location GetLocation(string input)
        {
            var locationStrings = GetLocationStrings(input);
            var direction = GetDirectionFromInput(locationStrings);
            return new Location(int.Parse(locationStrings[0]),
                int.Parse(locationStrings[1]), direction);
        }

        private static CompassDirection GetDirectionFromInput(IList<string> locationStrings)
        {
            if (locationStrings == null) throw new ArgumentNullException("locationStrings");
            CompassDirection direction;
            switch (locationStrings[2].ToUpper())
            {
                case "N":
                    direction = CompassDirection.North;
                    break;
                case "E":
                    direction = CompassDirection.East;
                    break;
                case "W":
                    direction = CompassDirection.West;
                    break;
                case "S":
                    direction = CompassDirection.South;
                    break;
                default:
                    throw new Exception("Bad direction input.");
            }
            return direction;
        }
    }
}
