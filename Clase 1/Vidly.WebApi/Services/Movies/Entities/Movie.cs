using Vidly.WebApi.Services.Users.Entities;

namespace Vidly.WebApi.Services.Movies.Entities
{
    public sealed record class Movie
    {
        public string Id { get; init; }

        public string Title { get; init; } = null!;

        public string Description { get; set; } = null!;

        public int Stars { get; init; }

        public DateTimeOffset PublishedOn { get; init; }

        public DateTimeOffset CreatedOn { get; init; }

        public List<User> Users { get; init; }

        public List<string> Platforms { get; init; }

        public Movie()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTimeOffset.UtcNow;
            Users = new List<User>();
            Platforms = new List<string>();
        }
    }
}
