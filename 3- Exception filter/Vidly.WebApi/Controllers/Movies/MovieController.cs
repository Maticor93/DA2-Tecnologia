using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Controllers.Movies.Entities;
using Vidly.WebApi.Controllers.Movies.Models;
using Vidly.WebApi.Filters;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    public sealed class MovieController : ControllerBase
    {
        private static readonly List<Movie> _movies = [];

        public MovieController()
        {
        }

        [HttpPost]
        public CreateMovieResponse Create([FromBody] CreateMovieRequest? newMovie)
        {
            ArgumentNullException.ThrowIfNull(newMovie,"request");

            if (string.IsNullOrEmpty(newMovie.Title))
                throw new ArgumentNullException(nameof(CreateMovieRequest.Title));

            if (string.IsNullOrEmpty(newMovie.Description))
                throw new ArgumentNullException(nameof(CreateMovieRequest.Description));

            if (newMovie.PublishedOn == null)
                throw new ArgumentNullException(nameof(CreateMovieRequest.PublishedOn));

            var existMovie = _movies.Any(m => m.Title == newMovie.Title);
            if (existMovie)
                throw new Exception("Duplicated movie");

            var movieToSave = new Movie(
              newMovie.Title,
              newMovie.Description,
              DateTimeOffset.Parse(newMovie.PublishedOn));

            _movies.Add(movieToSave);

            return new CreateMovieResponse(movieToSave);
        }

        [HttpGet]
        public List<MovieBasicInfoResponse> GetAll([FromQuery] MovieFiltersRequest filters)
        {
            return _movies
                .Where(m =>
                (string.IsNullOrEmpty(filters.Title) || m.Title.Contains(filters.Title)) &&
                (!filters.MinStars.HasValue || m.Stars >= filters.MinStars) &&
                (string.IsNullOrEmpty(filters.PublishedOn) || m.PublishedOn == DateTimeOffset.Parse(filters.PublishedOn)))
                .Select(m => new MovieBasicInfoResponse(m))
                .ToList();
        }

        [HttpGet("{id}")]
        public MovieDetailInfoResponse GetById(string id)
        {
            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
                throw new Exception($"Invalid id {id}");

            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                throw new Exception("Movie not found");

            return new MovieDetailInfoResponse(movie);
        }

        [HttpDelete("{id}")]
        public void DeleteById(string id)
        {
            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
                throw new Exception($"Invalid id {id}");

            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                throw new Exception("Movie not found");

            _movies.Remove(movie);
        }

        [HttpPut("{id}")]
        public void UpdateById(string id, UpdateMovieRequest? updatesOfMovie)
        {
            ArgumentNullException.ThrowIfNull(updatesOfMovie);

            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
                throw new Exception($"Invalid id {id}");

            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                throw new Exception("Movie not found");

            if (!string.IsNullOrEmpty(updatesOfMovie.Description))
                movie.Description = updatesOfMovie.Description;
        }
    }
}
