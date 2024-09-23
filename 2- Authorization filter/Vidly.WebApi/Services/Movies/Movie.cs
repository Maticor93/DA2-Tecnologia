namespace Vidly.WebApi.Services.Movies
{
    public sealed record class Movie
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Title { get; init; }

        public string Description { get; set; }

        public int Stars { get; init; }

        public DateTimeOffset PublishedOn { get; init; }

        public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;

        public Movie(
            string title,
            string description,
            DateTimeOffset publishedOn)
        {
            Title = title;
            Description = description;
            PublishedOn = publishedOn;
        }
    }
}
