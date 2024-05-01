using Microsoft.AspNetCore.Mvc;

namespace Vidly.WebApi.Controllers.Health
{
    [ApiController]
    [Route("", Name = "Ping")]
    [Route("health", Name = "Health")]
    public sealed class HealthController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            return new
            {
                Alive = true
            };
        }
    }
}
