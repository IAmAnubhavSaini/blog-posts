using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRentalCustomer.Tests
{
    [TestClass]
    public class MovieRentalCustomerTests
    {
        [TestMethod]
        public void OutputStringTestShouldPass()
        {
            var newCustomer = new Customer("Anubhav");
            newCustomer.AddRental(new Rental(new Movie("Termitators", MovieType.NewRelease), 2));

            Assert.AreEqual(newCustomer.GenerateStatement(), "Rental reocord for Anubhav.\n\tTermitators\t6\nAmount owed is 6\nYou earned 2 frequent renter points");
        }
    }
}
