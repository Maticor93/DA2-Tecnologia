using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Vidly.WebApi.Controllers.Users.Entities;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    public sealed class MovieController() : VidlyControllerBase
    {
        private static readonly List<Movie> _movies = [];

        [HttpPost]
        public CreateMovieResponse Create([FromBody]CreateMovieRequest? newMovie, [FromHeader] string? authorization)
        {
            if (string.IsNullOrEmpty(authorization))
                ThrowException("Unauthenticated", "Needs to be authenticated");

            var userLogged = base.GetUserLogged(authorization);

            var isForbbiden = !userLogged.Role.HasPermission(PermissionKey.CreateMovie);
            if (isForbbiden)
                ThrowException("Forbbiden", $"Missing permission {PermissionKey.CreateMovie.ToString()}");

            if (newMovie == null)
                ThrowException("InvalidRequest", "Request can not be null");

            if (string.IsNullOrEmpty(newMovie.Title))
                ThrowException("InvalidRequest", "Title can not be null or empty");

            if (string.IsNullOrEmpty(newMovie.Description))
                ThrowException("InvalidRequest", "Description can not be null or empty");

            if (newMovie.PublishedOn == null)
                ThrowException("InvalidRequest", "PublishedOn can not be null");

            var existMovie = _movies.Any(m => m.Title == newMovie.Title);
            if (existMovie)
                ThrowException("DuplicatedResource", $"Movie with prop: Title and value: {newMovie.Title} exist");

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
                ThrowException("InvalidArgument", "The provided id is not a valid guid");

            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                ThrowException("ResourceNotFound", $"Movie with id: {id} does not exist");

            return new MovieDetailInfoResponse(movie);
        }

        [HttpDelete("{id}")]
        public void DeleteById(string id)
        {
            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
                ThrowException("InvalidArgument", "The provided id is not a valid guid");

            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                ThrowException("ResourceNotFound", $"Movie with id: {id} does not exist");

            _movies.Remove(movie);
        }

        [HttpPut("{id}")]
        public void UpdateById(string id, UpdateMovieRequest? updatesOfMovie)
        {
            if (updatesOfMovie == null)
                ThrowException("InvalidRequest", "The request can not be null");

            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
                ThrowException("InvalidArgument", "The provided id is not a valid guid");

            var movie = _movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                ThrowException("ResourceNotFound", $"Movie with id: {id} does not exist");

            if (!string.IsNullOrEmpty(updatesOfMovie.Description))
                movie.Description = updatesOfMovie.Description;
        }

        private static void ThrowException(string code, string description) => throw new Exception($"Code:{code}, Description: {description}");
    }
}
