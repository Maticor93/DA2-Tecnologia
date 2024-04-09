namespace Vidly.WebApi.Services.Movies.Entities
{
    public sealed record class Author
    {
        public string Id { get; init; }

        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string FullName { get; init; } = null!;

        public Author()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
