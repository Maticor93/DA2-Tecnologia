namespace Vidly.BusinessLogic.Movies
{
    public sealed class MovieService()
        : IMovieService
    {
        private readonly static List<Movie> _movies = [];

        public Movie Create(CreateMovieArgs args)
        {
            var existMovie = _movies.Any(m => m.Title == args.Title);
            if (existMovie)
            {
                throw new Exception("Movie duplicated");
            }

            var movieToSave = new Movie
            {
                Title = args.Title,
                Description = args.Description,
                PublishedOn = args.PublishedOn,
            };

            _movies.Add(movieToSave);

            return movieToSave;
        }
    }
}
