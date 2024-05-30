namespace Vidly.WebApi.Controllers.MovieTypes.Entities
{
    public sealed record class MovieType
    {
        public string Id { get; init; }

        public string Name { get; init; } = null!;

        public MovieType()
        {
            Id = Guid.NewGuid().ToString();
        }

        public MovieType(string name)
            : this()
        {
            Name = name;
        }
    }
}
