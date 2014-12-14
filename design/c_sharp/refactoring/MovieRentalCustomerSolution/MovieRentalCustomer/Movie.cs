namespace MovieRentalCustomer
{
    public abstract class Movie
    {
        public string Title { get; set; }
        public MovieRent Rent { get; set; }

        public virtual int FrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    public sealed class RegularMovie : Movie
    {
        public RegularMovie(string title)
        {
            Title = title;
            Rent = new RegularMovieRent();
        }
    }

    public sealed class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title)
        {
            Title = title;
            Rent = new NewReleaseMovieRent();
        }

        public override int FrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }

    public sealed class ChildrenMovie : Movie
    {
        public ChildrenMovie(string title)
        {
            Title = title;
            Rent = new ChildrenMovieRent();
        }

    }
}
