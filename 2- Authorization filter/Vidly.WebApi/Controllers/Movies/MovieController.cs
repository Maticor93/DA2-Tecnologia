using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Controllers.Movies.Entities;
using Vidly.WebApi.Controllers.Movies.Models;
using Vidly.WebApi.Filters;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    [AuthenticationFilter]
    public sealed class MovieController : VidlyControllerBase
    {
        private static readonly List<Movie> _movies = [];

        public MovieController()
        {
        }

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

            return new List<MovieBasicInfoResponse>();
        }
    }
}
