
namespace MovieRentalCustomer
{
    public class ChildrenMovie : Movie, ICanBeRented
    {
        public ChildrenMovie(string title) : base(title) { }

        public double RentFor(int daysRented)
        {
            var amount = 1.5;
            if (daysRented > 3)
                amount += (daysRented - 3) * 1.5;
            return amount;
        }
    }
}
