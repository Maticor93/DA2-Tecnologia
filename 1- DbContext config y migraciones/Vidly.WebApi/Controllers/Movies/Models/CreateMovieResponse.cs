using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies.Models
{
    public sealed record class CreateMovieResponse
    {
        public string Id { get; init; }

        public CreateMovieResponse(Movie movie)
        {
            Id = movie.Id;
        }
    }
}
