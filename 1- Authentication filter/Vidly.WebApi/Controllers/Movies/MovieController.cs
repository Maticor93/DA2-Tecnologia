using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Filters;
using Vidly.WebApi.Services.Movies;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    [AuthenticationFilter]
    public sealed class MovieController
        : VidlyControllerBase
    {
        private static readonly List<Movie> _movies = [];

        public MovieController()
        {
        }

        [HttpPost]
        public void Create([FromBody] CreateMovieRequest? newMovie)
        {
            var userLogged = base.GetUserLogged();

            // rest of code
        }
    }
}
