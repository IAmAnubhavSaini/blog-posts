namespace MovieRentalCustomer
{
    public class Rental
    {
        public Movie Movie { get; private set; }
        public int DaysRented { get; private set; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public int FrequentRenterPoints()
        {
            return Movie.FrequentRenterPoints(DaysRented);
        }

        public double RentalAmount()
        {
            return Movie.Rent.RentFor(DaysRented);
        }
    }
}