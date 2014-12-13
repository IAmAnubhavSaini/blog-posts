using System;
using System.Collections.Generic;

namespace MovieRentalCustomer
{
    public class Customer
    {
        public string Name { get; private set; }
        public List<Rental> Rentals { get; private set; }

        public Customer AddRental(Rental rental)
        {
            Rentals.Add(rental);
            return this;
        }

        public Customer(string name)
        {
            Name = name;
            Rentals = new List<Rental>();
        }

        public String GenerateStatement()
        {
            var totalAmount = 0d;
            var frequentRenterPoints = 0;
            var result = CustomerInformation();
            foreach (var rental in Rentals)
            {
                frequentRenterPoints += rental.FrequentRenterPoints();
                result += MovieRentalInformation(rental);
                totalAmount += rental.RentalAmount();
            }
            result += CustomerTotalAmountInformation(totalAmount);
            result += CustomerFrequentRenterPointInformation(frequentRenterPoints);
            return result;
        }

        private string CustomerInformation()
        {
            return "Rental reocord for " + Name + ".\n";
        }

        private static string CustomerFrequentRenterPointInformation(int frequentRenterPoints)
        {
            return "You earned " + frequentRenterPoints + " frequent renter points";
        }

        private static string CustomerTotalAmountInformation(double totalAmount)
        {
            return "Amount owed is " + totalAmount + "\n";
        }

        private static string MovieRentalInformation(Rental rental)
        {
            return "\t" + rental.Movie.Title + "\t" + rental.RentalAmount() + "\n";
        }
    }
}
