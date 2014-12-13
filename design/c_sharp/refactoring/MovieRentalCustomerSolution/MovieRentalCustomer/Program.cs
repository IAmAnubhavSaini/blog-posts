
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
            var customers = new List<Customer>()
            {
                new Customer("Anubhav").AddRental(new Rental(new NewReleaseMovie("Termitators"), 2)),
                new Customer("Saini").AddRental(new Rental(new NewReleaseMovie("Termitators 2"), 1)),
                new Customer("asaini").AddRental(new Rental(new NewReleaseMovie("Termitators 3"), 3)),
                new Customer("major").AddRental(new Rental(new ChildrenMovie("Baby Termitators"), 5))
            };
            
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.GenerateStatement());
            }

        }
    }

    
}

