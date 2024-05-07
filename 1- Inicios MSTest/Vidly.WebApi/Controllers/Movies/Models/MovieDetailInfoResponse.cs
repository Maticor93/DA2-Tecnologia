
using Vidly.WebApi.Controllers.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies.Models
{
    public readonly struct MovieDetailInfoResponse
    {
        public string Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }

        public int Stars { get; init; }

        public DateTimeOffset PublishedOn { get; init; }

        public DateTimeOffset CreatedOn { get; init; }

        public MovieDetailInfoResponse(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Description = movie.Description;
            Stars = movie.Stars;
            PublishedOn = movie.PublishedOn;
            CreatedOn = movie.CreatedOn;
        }
    }
}
