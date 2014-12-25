using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverAppTests
{
    [TestClass]
    public class MixedTests
    {
        [TestMethod]
        public void RoverShouldReachOriginalStateAfter4ConsecutiveWalkAndLeftTurns()
        {
            var currX = 5;
            var currY = 5;
            var currLoc = CompassDirection.North;
            var rover = new Rover(new Plane(10, 10), "MLMLMLML", new Location(currX, currY, currLoc));
            Assert.AreEqual(currX, rover.Operate().CurrentX);
            Assert.AreEqual(currY, rover.Operate().CurrentY);
            Assert.AreEqual(currLoc, rover.Operate().CurrentDirection);
        }

        [TestMethod]
        public void RoverShouldReachOriginalStateAfter4ConsecutiveWalkAndRightTurns()
        {
            var currX = 5;
            var currY = 5;
            var currLoc = CompassDirection.North;
            var rover = new Rover(new Plane(10, 10), "MRMRMRMR", new Location(currX, currY, currLoc));
            Assert.AreEqual(currX, rover.Operate().CurrentX);
            Assert.AreEqual(currY, rover.Operate().CurrentY);
            Assert.AreEqual(currLoc, rover.Operate().CurrentDirection);
        }
    }
}
