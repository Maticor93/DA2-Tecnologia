using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Controllers.Movies.Entities;
using Vidly.WebApi.Controllers.Movies.Models;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    public sealed class MovieController() : ControllerBase
    {
        private readonly List<Movie> _movies = [];

        [HttpPost]
        public CreateMovieResponse Create(CreateMovieRequest? request)
        {
            if (request == null)
            {
                throw new Exception("Request can not be null");
            }

            if (string.IsNullOrEmpty(request.Title))
            {
                throw new Exception("Title can not be null or empty");
            }

            if (string.IsNullOrEmpty(request.Description))
            {
                throw new Exception("Description can not be null or empty");
            }

            if (request.PublishedOn == null)
            {
                throw new Exception("PublishedOn can not be null");
            }

            var existMovie = _movies.Any(m => m.Title == request.Title);
            if (existMovie)
            {
                throw new Exception($"Movie with prop: Title and value: {request.Title} exist");
            }

            var movieToSave = new Movie(request.Title, request.Description, request.PublishedOn.Value);

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
                (filters.PublishedOn == null || m.PublishedOn == filters.PublishedOn))
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

            var movie = _movies.Find(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception($"Movie with id: {id} does not exist");
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

            var movie = _movies.Find(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception($"Movie with id: {id} does not exist");
            }

            _movies.Remove(movie);
        }

        [HttpPut("{id}")]
        public void UpdateById(string id, UpdateMovieRequest? request)
        {
            if (request == null)
            {
                throw new Exception("The request can not be null");
            }

            var isValidId = Guid.TryParse(id, out var movieId);
            if (!isValidId)
            {
                throw new Exception("The provided id is not a valid guid");
            }

            var movie = _movies.Find(m => m.Id == id);

            if (movie == null)
            {
                throw new Exception($"Movie with id: {id} does not exist");
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                movie.Description = request.Description;
            }
        }
    }
}
