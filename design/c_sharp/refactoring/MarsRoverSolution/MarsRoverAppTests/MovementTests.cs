using MarsRoverApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverAppTests
{
    [TestClass]
    public class MovementTests
    {
        [TestMethod]
        public void RoverDoesNotFallOffTheGridToNorth()
        {
            var rover = new Rover(new Plane(10, 10), "MMMMMMMMMMMM", new Location(0,0, CompassDirection.North) );

            Assert.AreEqual(10, rover.Operate().CurrentY);
        }
        
        [TestMethod]
        public void RoverDoesNotFallOffTheGridToSouth()
        {
            var rover = new Rover(new Plane(10, 10), "MMMMMMMMMMMM", new Location(0,0, CompassDirection.South) );

            Assert.AreEqual(0, rover.Operate().CurrentY);
        }
        [TestMethod]
        public void RoverDoesNotFallOffTheGridToEast()
        {
            var rover = new Rover(new Plane(10, 10), "MMMMMMMMMMMM", new Location(0,0, CompassDirection.East) );

            Assert.AreEqual(10, rover.Operate().CurrentX);
        }

        [TestMethod]
        public void RoverDoesNotFallOffTheGridToWest()
        {
            var rover = new Rover(new Plane(10, 10), "MMMMMMMMMMMM", new Location(0,0, CompassDirection.West) );

            Assert.AreEqual(0, rover.Operate().CurrentX);
        }

        [TestMethod]
        public void RoverWalksOneStepAtATimeInNorthSouthDirection()
        {
            var rover = new Rover(new Plane(10, 10), "M", new Location(0, 0, CompassDirection.North));
            Assert.AreEqual(1, rover.Operate().CurrentY);
        }

        [TestMethod]
        public void RoverWalksOneStepAtATimeInEastWestDirection()
        {
            var rover = new Rover(new Plane(10, 10), "M", new Location(0, 0, CompassDirection.East));
            Assert.AreEqual(1, rover.Operate().CurrentX);
        }
    }
}
