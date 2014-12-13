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
            if ((Movie is NewReleaseMovie) && DaysRented > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        public double RentalAmount()
        {
            var canBeRented = (Movie as ICanBeRented);
            return canBeRented != null ? canBeRented.RentFor(DaysRented) : -1d;
        }
    }
}