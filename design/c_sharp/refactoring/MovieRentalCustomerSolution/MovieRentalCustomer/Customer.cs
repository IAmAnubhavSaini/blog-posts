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
            var result = "Rental reocord for " + Name + ".\n";
            foreach (var rental in Rentals)
            {
                var thisAmount = 0d;
                switch (rental.Movie.Type)
                {
                    case MovieType.Children:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3)*1.5;
                        break;
                    case MovieType.NewRelease:
                        thisAmount += rental.DaysRented*3;
                        break;
                    case MovieType.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                            thisAmount += (rental.DaysRented - 2)*1.5;
                        break;
                }

                frequentRenterPoints++;

                if ((rental.Movie.Type == MovieType.NewRelease) && rental.DaysRented > 1)
                    frequentRenterPoints++;


                result += "\t" + rental.Movie.Title + "\t" + thisAmount + "\n";

                totalAmount += thisAmount;
            }
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}