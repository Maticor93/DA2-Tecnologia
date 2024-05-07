
using Vidly.WebApi.Controllers.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies.Models
{
    public readonly struct MovieBasicInfoResponse
    {
        public string Id { get; init; }

        public string Title { get; init; }

        public MovieBasicInfoResponse(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
        }
    }
}
