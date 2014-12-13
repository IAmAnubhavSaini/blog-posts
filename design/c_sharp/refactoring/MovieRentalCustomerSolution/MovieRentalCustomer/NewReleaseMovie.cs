
namespace MovieRentalCustomer
{
    public class NewReleaseMovie : Movie, ICanBeRented
    {
        public NewReleaseMovie(string title) : base(title) { }

        public double RentFor(int daysRented)
        {
            return daysRented * 3;
        }
    }
}
