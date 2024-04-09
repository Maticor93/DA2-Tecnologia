namespace Vidly.WebApi.Controllers.Movies.Entities
{
    public sealed record class Movie
    {
        public string Id { get; init; }

        public string Title { get; init; } = null!;

        public string Description { get; set; } = null!;

        public int Stars { get; init; }

        public DateTimeOffset PublishedOn { get; init; }

        public DateTimeOffset CreatedOn { get; init; }

        public Movie()
        {
            Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTimeOffset.UtcNow;
        }
    }
}
