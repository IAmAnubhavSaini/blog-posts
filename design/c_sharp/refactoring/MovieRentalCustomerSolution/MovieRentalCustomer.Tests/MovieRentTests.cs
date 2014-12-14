using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRentalCustomer.Tests
{
    [TestClass]
    public class MovieRentTests
    {
        [TestMethod]
        public void RentOfChildrenMovieFor10DaysShouldBe12()
        {
            var rent = new ChildrenMovieRent();
            Assert.AreEqual(12, rent.RentFor(10));
        }
        [TestMethod]
        public void RentOfNewReleaseMovieFor10DaysShouldBe30()
        {
            var rent = new NewReleaseMovieRent();
            Assert.AreEqual(30, rent.RentFor(10));
        }
        [TestMethod]
        public void RentOfRegularMovieFor10DaysShouldBe14()
        {
            var rent = new RegularMovieRent();
            Assert.AreEqual(14, rent.RentFor(10));
        }
    }
}
