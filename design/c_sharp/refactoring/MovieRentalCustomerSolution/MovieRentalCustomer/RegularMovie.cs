
namespace MovieRentalCustomer
{
    public class RegularMovie : Movie, ICanBeRented
    {
        public RegularMovie(string title) : base(title, MovieType.Regular) { }

        public double RentFor(int daysRented)
        {
            var amount = 2d;
            if (daysRented > 2)
                amount += (daysRented - 2) * 1.5;
            return amount;
        }
    }
}
