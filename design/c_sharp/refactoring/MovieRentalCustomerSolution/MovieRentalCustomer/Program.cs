
using System;
using System.Collections.Generic;

namespace MovieRentalCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
        }

        private static void Setup()
        {
            List<Customer> customers = new List<Customer>();
            Customer newCustomer = new Customer("Anubhav"); customers.Add(newCustomer);
            newCustomer.AddRental(new Rental(new Movie("Termitators", MovieType.NewRelease), 2));
            newCustomer = new Customer("Saini"); customers.Add(newCustomer);
            newCustomer.AddRental(new Rental(new Movie("Termitators 2", MovieType.NewRelease), 1));
            newCustomer = new Customer("asaini"); customers.Add(newCustomer);
            newCustomer.AddRental(new Rental(new Movie("Termitators 3", MovieType.NewRelease), 3));
            newCustomer = new Customer("major"); customers.Add(newCustomer);
            newCustomer.AddRental(new Rental(new Movie("Baby Termitators", MovieType.Children), 5));

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.GenerateStatement());
            }

        }
    }


    public class Movie
    {
        public MovieType Type { get; private set; }
        public string Title { get; private set; }

        public Movie(string title, MovieType type)
        {
            Type = type;
            Title = title;
        }
    }

    public class Rental
    {
        public Movie Movie { get; private set; }
        public int DaysRented { get; private set; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }
    }

    public class Customer
    {
        public string Name { get; private set; }
        public List<Rental> Rentals { get; private set; }

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }

        public Customer(string name)
        {
            Name = name;
            Rentals = new List<Rental>();
        }

        public String GenerateStatement()
        {
            double totalAmount = 0d;
            int frequentRenterPoints = 0;
            string result = "Rental reocord for " + Name + ".\n";
            foreach (Rental rental in Rentals)
            {
                double thisAmount = 0d;
                switch (rental.Movie.Type)
                {
                    case MovieType.Children:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3) * 1.5;
                        break;
                    case MovieType.NewRelease:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case MovieType.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                            thisAmount += (rental.DaysRented - 2) * 1.5;
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

