using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRentalCustomer.Tests
{
    [TestClass]
    public class MovieRentalCustomerTests
    {
        [TestMethod]
        public void RentForUserAnubhavNewReleaseMovieTermitatorsShouldBe6For2Days()
        {
            var newCustomer = new Customer("Anubhav");
            newCustomer.AddRental(new Rental(new NewReleaseMovie("Termitators"), 2));

            Assert.AreEqual(newCustomer.GenerateStatement(), "Rental reocord for Anubhav.\n\tTermitators\t6\nAmount owed is 6\nYou earned 2 frequent renter points");
        }

        [TestMethod]
        public void RentForUserAbcRegularMovieBbcShouldBe5For4Days()
        {
            var newCustomer = new Customer("Abc");
            newCustomer.AddRental(new Rental(new RegularMovie("Bbc"), 4));

            Assert.AreEqual(newCustomer.GenerateStatement(), "Rental reocord for Abc.\n\tBbc\t5\nAmount owed is 5\nYou earned 1 frequent renter points");
        }

        [TestMethod]
        public void RentForUserAbcChildrenMovieBbcShouldBe3For4Days()
        {
            var newCustomer = new Customer("Abc");
            newCustomer.AddRental(new Rental(new ChildrenMovie("Bbc"), 4));

            Assert.AreEqual(newCustomer.GenerateStatement(), "Rental reocord for Abc.\n\tBbc\t3\nAmount owed is 3\nYou earned 1 frequent renter points");
        }
    }
}
