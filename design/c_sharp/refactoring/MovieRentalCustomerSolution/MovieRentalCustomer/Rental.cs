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
            var frequentRenterPoints = 1;
            if ((Movie.Type == MovieType.NewRelease) && DaysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        public double RentalAmount()
        {
            return Movie.Rent.RentFor(DaysRented);
        }
    }
}