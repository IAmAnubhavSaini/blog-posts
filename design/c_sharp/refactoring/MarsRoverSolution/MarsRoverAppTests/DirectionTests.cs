using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class DirectionTests
    {
        [TestMethod]
        public void After4LeftTurnsRoverPointsToOriginalDirection()
        {
            var originalDirection = CompassDirection.North;
            var rover = new Rover(new Plane(10, 10), "LLLL", new RoverLocation(new Point2D(0, 0), originalDirection));

            Assert.AreEqual(originalDirection, rover.Operate().Direction);
        }
        
        [TestMethod]
        public void After4RightTurnsRoverPointsToOriginalDirection()
        {
            var originalDirection = CompassDirection.North;
            var rover = new Rover(new Plane(10, 10), "RRRR", new RoverLocation(new Point2D(0, 0), originalDirection));

            Assert.AreEqual(originalDirection, rover.Operate().Direction);
        }

    }
}
