using Vidly.WebApi.Controllers.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies.Models
{
    public sealed class MovieBasicInfoResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public MovieBasicInfoResponse(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
        }
    }
}