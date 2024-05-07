using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Controllers.Movies.Entities;
using Vidly.WebApi.Controllers.Movies.Models;
using Vidly.WebApi.Utility;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    public sealed class MovieController() : ControllerBase
    {
        private static readonly List<Movie> _movies = [];

        [HttpPost]
        public CreateMovieResponse Create(CreateMovieRequest? request)
        {
            if (request == null)
            {
                throw new Exception("Request can not be null");
            }

            if (string.IsNullOrEmpty(request.PublishedOn))
            {
                throw new ArgumentNullException("PublishedOn can not be null or empty");

            }

            var arguments = new CreateMovieArgs(
                request.Title ?? string.Empty,
                request.Description ?? string.Empty,
                VidlyDateTime.Parse(request.PublishedOn));

            var movie = new Movie
            {
                Title = arguments.Title,
                Description = arguments.Description,
                PublishedOn = arguments.PublishedOn,
            };

            _movies.Add(movie);

            return new CreateMovieResponse(movie);
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
            {
                throw new Exception("The provided id is not a valid guid");
            }

            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception("Movie dosen't exist");
            }

            return new MovieDetailInfoResponse(movie);
        }

        [HttpDelete("{id}")]
        public void DeleteById(string id)
        {
            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
            {
                throw new Exception("The provided id is not a valid guid");
            }

            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception("Movie dosen't exist");
            }

            _movies.Remove(movie);
        }

        [HttpPut("{id}")]
        public void UpdateById(string id, UpdateMovieRequest? updatesOfMovie)
        {
            if (updatesOfMovie == null)
            {
                throw new Exception("The request can not be null");
            }

            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
            {
                throw new Exception("The provided id is not a valid guid");
            }

            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception("Movie dosen't exist");
            }

            if (!string.IsNullOrEmpty(updatesOfMovie.Description))
            {
                movie.Description = updatesOfMovie.Description;
            }
        }
    }
}
