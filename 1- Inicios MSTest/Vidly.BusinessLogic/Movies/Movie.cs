namespace Vidly.BusinessLogic.Movies
{
    public sealed record class Movie()
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Title { get; init; } = null!;

        public string Description { get; set; } = null!;

        public int Stars { get; init; }

        public DateTimeOffset PublishedOn { get; init; }

        public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;
    }
}
