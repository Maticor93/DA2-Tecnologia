using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies
{
    public readonly struct MovieBasicInfoResponse
    {
        public string Id { get; init; }

        public string Title { get; init; }

        public MovieBasicInfoResponse(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
        }
    }
}
