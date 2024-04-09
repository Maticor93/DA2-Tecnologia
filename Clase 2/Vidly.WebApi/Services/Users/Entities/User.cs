using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.Services.Users.Entities
{
    public sealed record class User
    {
        public string Id { get; init; }

        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string FullName { get; init; } = null!;

        public string Email { get; init; } = null!;

        public string Password { get; init; } = null!;

        public List<Movie> FavoriteMovies { get; init; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
            FavoriteMovies = new List<Movie>();
        }
    }
}
