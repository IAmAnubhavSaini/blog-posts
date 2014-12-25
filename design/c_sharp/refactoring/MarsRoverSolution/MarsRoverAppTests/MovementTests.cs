using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class MovementTests
    {
        [TestMethod]
        public void RoverDoesNotFallOffTheGridToNorth()
        {
            var rover = new Rover(new Plane(10, 10), "MMMMMMMMMMMM", new RoverLocation(new Point2D(0, 0), CompassDirection.North) );

            Assert.AreEqual(10, rover.Operate().Coordinates.Y);
        }
        
        [TestMethod]
        public void RoverDoesNotFallOffTheGridToSouth()
        {
            var rover = new Rover(new Plane(10, 10), "MMMMMMMMMMMM", new RoverLocation(new Point2D(0, 0), CompassDirection.South));

            Assert.AreEqual(0, rover.Operate().Coordinates.Y);
        }
        [TestMethod]
        public void RoverDoesNotFallOffTheGridToEast()
        {
            var rover = new Rover(new Plane(10, 10), "MMMMMMMMMMMM", new RoverLocation(new Point2D(0, 0), CompassDirection.East));

            Assert.AreEqual(10, rover.Operate().Coordinates.X);
        }

        [TestMethod]
        public void RoverDoesNotFallOffTheGridToWest()
        {
            var rover = new Rover(new Plane(10, 10), "MMMMMMMMMMMM", new RoverLocation(new Point2D(0, 0), CompassDirection.West));

            Assert.AreEqual(0, rover.Operate().Coordinates.X);
        }

        [TestMethod]
        public void RoverWalksOneStepAtATimeInNorthSouthDirection()
        {
            var rover = new Rover(new Plane(10, 10), "M", new RoverLocation(new Point2D(0, 0), CompassDirection.North));
            Assert.AreEqual(1, rover.Operate().Coordinates.Y);
        }

        [TestMethod]
        public void RoverWalksOneStepAtATimeInEastWestDirection()
        {
            var rover = new Rover(new Plane(10, 10), "M", new RoverLocation(new Point2D(0, 0), CompassDirection.East));
            Assert.AreEqual(1, rover.Operate().Coordinates.X);
        }
    }
}
