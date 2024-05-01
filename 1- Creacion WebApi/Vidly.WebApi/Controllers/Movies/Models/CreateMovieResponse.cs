using Vidly.WebApi.Controllers.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies.Models
{
    public readonly struct CreateMovieResponse(Movie movie)
    {
        public string Id { get; init; } = movie.Id;
    }
}
