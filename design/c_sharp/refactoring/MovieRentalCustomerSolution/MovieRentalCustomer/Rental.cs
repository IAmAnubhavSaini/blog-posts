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
            var thisAmount = 0d;
            switch (Movie.Type)
            {
                case MovieType.Children:
                    thisAmount += 1.5;
                    if (DaysRented > 3)
                        thisAmount += (DaysRented - 3) * 1.5;
                    break;
                case MovieType.NewRelease:
                    thisAmount += DaysRented * 3;
                    break;
                case MovieType.Regular:
                    thisAmount += 2;
                    if (DaysRented > 2)
                        thisAmount += (DaysRented - 2) * 1.5;
                    break;
            }
            return thisAmount;
        }
    }
}