using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using Vidly.WebApi.Services.Movies;
using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    public sealed class MovieController(IMovieService _movieService) : ControllerBase
    {
        [HttpPost]
        public CreateMovieResponse Create(CreateMovieRequest? newMovie)
        {
            if (newMovie == null)
            {
                throw new Exception("Request can not be null");
            }

            if (string.IsNullOrEmpty(newMovie.Title))
            {
                throw new Exception("Title can not be null or empty");
            }

            if (string.IsNullOrEmpty(newMovie.Description))
            {
                throw new Exception("Description can not be null or empty");
            }

            if (newMovie.PublishedOn == null)
            {
                throw new Exception("PublishedOn can not be null");
            }

            var movieToSave = new Movie(
              newMovie.Title,
              newMovie.Description,
              DateTimeOffset.Parse(newMovie.PublishedOn));

            var movieSaved = _movieService.Add(movieToSave);

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
            {
                throw new Exception("The provided id is not a valid guid");
            }

            var movie = _movieService.GetById(id);

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

            _movieService.DeleteById(id);
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

            _movieService.UpdateById(id, updatesOfMovie.Description);
        }
    }
}
