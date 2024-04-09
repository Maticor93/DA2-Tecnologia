using Vidly.WebApi.DataAccess.Repositories;
using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _repository;

        public MovieService(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public Movie Add(CreateMovieArgs movie)
        {
            var existMovie = _repository.Exist(m => m.Title == movie.Title);
            if (existMovie)
                throw new Exception("Movie duplicated");

            var movieToSave = new Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                PublishedOn = movie.PublishedOn,
            };

            _repository.Add(movieToSave);

            return movieToSave;
        }

        public List<Movie> GetAll(string? title = null, int? minStars = null, string? publishedOn = null)
        {
            return _repository
               .GetAll(m =>
               (string.IsNullOrEmpty(title) || m.Title.Contains(title)) &&
               (!minStars.HasValue || m.Stars >= minStars) &&
               (string.IsNullOrEmpty(publishedOn) || m.PublishedOn == DateTimeOffset.Parse(publishedOn)));
        }

        public Movie GetById(string id)
        {
            var movie = _repository.Get(m => m.Id == id);

            if (movie == null)
                throw new Exception("Movie dosen't exist");

            return movie;
        }

        public void DeleteById(string id)
        {
            var movie = GetById(id);

            _repository.Remove(movie);
        }

        public void UpdateById(string id, string? description = null)
        {
            var movieSaved = GetById(id);

            if (!string.IsNullOrEmpty(description))
                movieSaved.Description = description;

            _repository.Update(movieSaved);
        }
    }
}
