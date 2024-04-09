namespace Vidly.WebApi.Controllers.Movies.Models
{
    public sealed record class MovieFiltersRequest
    {
        public string? Title { get; init; }

        public int? MinStars { get; init; }

        public string? PublishedOn { get; init; }
    }
}
