namespace MovieRentalCustomer
{
    public class Movie
    {

        public MovieType Type { get; private set; }
        public string Title { get; private set; }

        public Movie(string title, MovieType type)
        {
            Type = type;
            Title = title;
        }
    }
}
