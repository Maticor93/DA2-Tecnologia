using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using Vidly.WebApi.Services.Movies;
using Vidly.WebApi.Services.Movies.Entities;
using Vidly.WebApi.Utility;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    public sealed class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public CreateMovieResponse Create(CreateMovieRequest? request)
        {
            if (request == null)
                ThrowException("InvalidRequest", "Request can not be null");

            if(string.IsNullOrEmpty(request.PublishedOn))
                ThrowException("InvalidRequest", "PublishedOn can not be null or empty");

            var arguments = new CreateMovieArgs(
                request.Title ?? string.Empty,
                request.Description ?? string.Empty,
                VidlyDateTime.Parse(request.PublishedOn));

            var movieSaved = _movieService.Add(arguments);

            return new CreateMovieResponse(movieSaved);
        }

        [HttpGet]
        public List<MovieBasicInfoResponse> GetAll([FromQuery] MovieFiltersRequest filters)
        {
           return _movieService
                .GetAll(filters.Title, filters.MinStars, filters.PublishedOn)
                .Select(m => new MovieBasicInfoResponse(m))
                .ToList();
        }

        [HttpGet("{id}")]
        public MovieDetailInfoResponse GetById(string id)
        {
            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
                ThrowException("InvalidArgument", "The provided id is not a valid guid");

            var movie = _movieService.GetById(id);

            return new MovieDetailInfoResponse(movie);
        }

        [HttpDelete("{id}")]
        public void DeleteById(string id)
        {
            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
                ThrowException("InvalidArgument", "The provided id is not a valid guid");

            _movieService.DeleteById(id);
        }

        [HttpPut("{id}")]
        public void UpdateById(string id, UpdateMovieRequest? updatesOfMovie)
        {
            if (updatesOfMovie == null)
                ThrowException("InvalidRequest", "The request can not be null");

            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
                ThrowException("InvalidArgument", "The provided id is not a valid guid");

            _movieService.UpdateById(id, updatesOfMovie.Description);
        }

        private static void ThrowException(string code, string description) => throw new Exception($"Code:{code}, Description: {description}");
    }
}
