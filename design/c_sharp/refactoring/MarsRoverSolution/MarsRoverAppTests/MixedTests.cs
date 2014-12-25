using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class MixedTests
    {
        [TestMethod]
        public void RoverShouldReachOriginalStateAfter4ConsecutiveWalkAndLeftTurns()
        {
            var curr = new Point2D(5, 5);
            var currLoc = CompassDirection.North;
            var rover = new Rover(new Plane(10, 10), "MLMLMLML", new RoverLocation(curr, currLoc));
            Assert.AreEqual(curr.X, rover.Operate().Coordinates.X);
            Assert.AreEqual(curr.Y, rover.Operate().Coordinates.Y);
            Assert.AreEqual(currLoc, rover.Operate().Direction);
        }

        [TestMethod]
        public void RoverShouldReachOriginalStateAfter4ConsecutiveWalkAndRightTurns()
        {
            var curr = new Point2D(5, 5);
            var currLoc = CompassDirection.North;
            var rover = new Rover(new Plane(10, 10), "MRMRMRMR", new RoverLocation(curr, currLoc));
            Assert.AreEqual(curr.X, rover.Operate().Coordinates.X);
            Assert.AreEqual(curr.Y, rover.Operate().Coordinates.Y);
            Assert.AreEqual(currLoc, rover.Operate().Direction);
        }
    }
}
