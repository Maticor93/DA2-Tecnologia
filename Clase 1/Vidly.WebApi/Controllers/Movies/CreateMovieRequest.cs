namespace Vidly.WebApi.Controllers.Movies
{
    public sealed record class CreateMovieRequest
    {
        public string? Title { get; init; }

        public string? Description { get; init; }

        public DateTimeOffset? PublishedOn { get; init; }
    }
}
