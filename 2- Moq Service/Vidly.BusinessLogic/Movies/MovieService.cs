using Vidly.BusinessLogic.Movies.Entities;

namespace Vidly.BusinessLogic.Movies
{
    public class MovieService(IMovieRepository movieRepository)
        : IMovieService
    {
        public Movie Add(CreateMovieArgs args)
        {
            var existMovie = movieRepository.Exists(m => m.Title == args.Title);
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

            movieRepository.Create(movieToSave);

            return movieToSave;
        }

        public List<Movie> GetAll(string? title = null, int? minStars = null, string? publishedOn = null)
        {
            return movieRepository
               .GetAll(m =>
               (string.IsNullOrEmpty(title) || m.Title.Contains(title)) &&
               (!minStars.HasValue || m.Stars >= minStars) &&
               (string.IsNullOrEmpty(publishedOn) || m.PublishedOn == DateTimeOffset.Parse(publishedOn)));
        }

        public Movie GetById(string id)
        {
            var movie = movieRepository.Get(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception("Movie dosen't exist");
            }

            return movie;
        }

        public void DeleteById(string id)
        {
            var movie = GetById(id);

            movieRepository.Delete(movie);
        }

        public void UpdateById(string id, string? description = null)
        {
            var movieSaved = GetById(id);

            if (!string.IsNullOrEmpty(description))
            {
                movieSaved.Description = description;
            }
        }
    }
}
