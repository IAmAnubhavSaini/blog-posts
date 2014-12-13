
namespace MovieRentalCustomer
{
    public class NewReleaseMovie : Movie, ICanBeRented
    {
        public NewReleaseMovie(string title)
            : base(title, MovieType.NewRelease)
        {
        }

        public double RentFor(int daysRented)
        {
            return daysRented * 3;
        }
    }
}
