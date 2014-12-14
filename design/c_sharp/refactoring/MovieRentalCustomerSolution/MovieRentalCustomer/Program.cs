
using System;
using System.Collections.Generic;

namespace MovieRentalCustomer
{
    class Program
    {
        static void Main()
        {
            Setup();
        }

        private static void Setup()
        {
            var customers = new List<Customer>()
            {
                new Customer("Anubhav").AddRental(new Rental(new Movie("Termitators", MovieType.NewRelease), 2)),
                new Customer("Saini").AddRental(new Rental(new Movie("Termitators 2", MovieType.NewRelease), 1)),
                new Customer("asaini").AddRental(new Rental(new Movie("Termitators 3", MovieType.NewRelease), 3)),
                new Customer("major").AddRental(new Rental(new Movie("Baby Termitators", MovieType.Children), 5))
            };
            
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.GenerateStatement());
            }

        }
    }

    
}

