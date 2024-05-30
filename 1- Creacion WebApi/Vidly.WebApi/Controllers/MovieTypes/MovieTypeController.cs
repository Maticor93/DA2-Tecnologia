using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Controllers.MovieTypes.Entities;
using Vidly.WebApi.Controllers.MovieTypes.Models;

namespace Vidly.WebApi.Controllers.MovieTypes
{
    [ApiController]
    [Route("movie-types")]
    public sealed class MovieTypeController : ControllerBase
    {
        [HttpGet]
        public List<MovieTypeBasicInfoResponse> GetAll()
        {
            return [
                new MovieTypeBasicInfoResponse(new MovieType("Action")),
                new MovieTypeBasicInfoResponse(new MovieType("Horror")),
                new MovieTypeBasicInfoResponse(new MovieType("Comedy"))
                ];
        }
    }
}
