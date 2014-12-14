namespace MovieRentalCustomer
{
    public abstract class MovieRent
    {
        public abstract double RentFor(int daysRented);
    }

    public class ChildrenMovieRent : MovieRent
    {
        public override sealed double RentFor(int daysRented)
        {
            var amount = 1.5;
            if (daysRented > 3)
                amount += (daysRented - 3)*1.5;
            return amount;
        }
    }

    public class RegularMovieRent : MovieRent
    {
        public override sealed double RentFor(int daysRented)
        {
            var amount = 2d;
            if (daysRented > 2)
                amount += (daysRented - 2)*1.5;
            return amount;
        }
    }

    public sealed class NewReleaseMovieRent : MovieRent
    {
        public override double RentFor(int daysRented)
        {
            return daysRented*3;
        }
    }

    public static class MovieRentFactory
    {
        public static MovieRent Rent(MovieType type)
        {
            switch (type)
            {
                case MovieType.Children:
                    return new ChildrenMovieRent();
                case MovieType.NewRelease:
                    return new NewReleaseMovieRent();
                case MovieType.Regular:
                    return new RegularMovieRent();
                default:
                    return new RegularMovieRent();
            }
        }
    }
}
