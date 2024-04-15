namespace Vidly.WebApi.Controllers.Movies.Entities
{
    public sealed record class Movie
    {
        public string Id { get; init; }

        public string Title { get; init; }

        public string Description { get; set; }

        public int Stars { get; init; }

        public DateTimeOffset PublishedOn { get; init; }

        public DateTimeOffset CreatedOn { get; init; }

        public Movie(string title, string description, DateTimeOffset publishedOn)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            PublishedOn = publishedOn;
            CreatedOn = DateTimeOffset.UtcNow;
        }
    }
}
