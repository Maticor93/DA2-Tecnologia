using Vidly.WebApi.Controllers.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies.Models
{
    public readonly struct MovieBasicInfoResponse(Movie movie)
    {
        public string Id { get; init; } = movie.Id;

        public string Title { get; init; } = movie.Title;
    }
}
