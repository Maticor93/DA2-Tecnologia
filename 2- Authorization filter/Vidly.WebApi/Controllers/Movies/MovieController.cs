using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Filters;
using Vidly.WebApi.Services.Movies;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    [AuthenticationFilter]
    public sealed class MovieController : VidlyControllerBase
    {
        private static readonly List<Movie> _movies = [];

        [HttpPost]
        [AuthorizationFilter]
        public void Create([FromBody] CreateMovieRequest? newMovie)
        {
            // rest of code
        }

        [HttpGet]
        public List<MovieBasicInfoResponse> GetAll()
        {
            // rest of code

            return [];
        }
    }
}
