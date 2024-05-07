namespace Vidly.WebApi.Controllers.Movies
{
    public sealed record class UpdateMovieRequest
    {
        public string? Description { get; init; }
    }
}
