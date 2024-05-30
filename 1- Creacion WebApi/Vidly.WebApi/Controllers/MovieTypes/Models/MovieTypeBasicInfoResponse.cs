using Vidly.WebApi.Controllers.MovieTypes.Entities;

namespace Vidly.WebApi.Controllers.MovieTypes.Models
{
    public readonly struct MovieTypeBasicInfoResponse(MovieType movieType)
    {
        public string Id { get; init; } = movieType.Id;

        public string Name { get; init; } = movieType.Name;
    }
}
