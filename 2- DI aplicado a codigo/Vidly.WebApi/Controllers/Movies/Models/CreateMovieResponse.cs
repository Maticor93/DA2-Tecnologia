using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies
{
    public readonly struct CreateMovieResponse
    {
        public string Id { get; init; }

        public CreateMovieResponse(Movie movie)
        {
            this.Id = movie.Id;
        }
    }
}
