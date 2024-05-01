namespace Vidly.WebApi.Controllers.Movies.Entities
{
    public sealed record class Movie()
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Title { get; set; }

        public string Description { get; set; }

        public int Stars { get; set; }

        public DateTimeOffset PublishedOn { get; set; }

        public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;

        public Movie(
            string title,
            string description,
            DateTimeOffset publishedOn)
            : this()
        {
            Title = title;
            Description = description;
            PublishedOn = publishedOn;
        }
    }
}
