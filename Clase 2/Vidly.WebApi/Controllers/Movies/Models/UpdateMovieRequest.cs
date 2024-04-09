namespace Vidly.WebApi.Controllers.Movies.Models
{
    public sealed record class UpdateMovieRequest
    {
        public string? Description { get; init; }
    }
}
