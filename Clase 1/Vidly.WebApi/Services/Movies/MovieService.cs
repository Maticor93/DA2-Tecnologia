using Vidly.WebApi.Controllers.Movies;
using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.Services.Movies
{
    public class MovieService : IMovieService
    {
        private static readonly List<Movie> _movies = [];


        public Movie Add(CreateMovieArgs movie)
        {
            var existMovie = _movies.Any(m => m.Title == movie.Title);
            if (existMovie)
                throw new Exception("Movie duplicated");

            var movieToSave = new Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                PublishedOn = movie.PublishedOn,
            };

            _movies.Add(movieToSave);

            return movieToSave;
        }

        public List<Movie> GetAll(string? title = null, int? minStars = null, string? publishedOn = null)
        {
            return _movies
               .Where(m =>
               (string.IsNullOrEmpty(title) || m.Title.Contains(title)) &&
               (!minStars.HasValue || m.Stars >= minStars) &&
               (string.IsNullOrEmpty(publishedOn) || m.PublishedOn == DateTimeOffset.Parse(publishedOn)))
               .ToList();
        }

        public Movie GetById(string id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                throw new Exception("Movie dosen't exist");

            return movie;
        }

        public void DeleteById(string id)
        {
            var movie = GetById(id);

            _movies.Remove(movie);
        }

        public void UpdateById(string id, string? description = null)
        {
            var movieSaved = GetById(id);

            if (!string.IsNullOrEmpty(description))
                movieSaved.Description = description;
        }
    }
}
