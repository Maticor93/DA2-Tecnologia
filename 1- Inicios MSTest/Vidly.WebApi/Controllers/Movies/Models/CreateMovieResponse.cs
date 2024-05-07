
using Vidly.WebApi.Controllers.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies.Models
{
    public readonly struct CreateMovieResponse
    {
        public string Id { get; init; }

        public CreateMovieResponse(Movie movie)
        {
            Id = movie.Id;
        }
    }
}
