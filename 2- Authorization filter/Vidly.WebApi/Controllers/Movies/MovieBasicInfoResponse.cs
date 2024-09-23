using Vidly.WebApi.Services.Movies;

namespace Vidly.WebApi.Controllers.Movies
{
    public readonly struct MovieBasicInfoResponse(Movie movie)
    {
        public string Id { get; init; } = movie.Id;

        public string Title { get; init; } = movie.Title;
    }
}