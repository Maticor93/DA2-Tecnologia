using DI.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DI.WebApi.Controllers
{
    [ApiController]
    [Route("singletons")]
    public class SingletonController(
        ISingletonService _singletonService1,
        ISingletonService _singletonService2
    ) : ControllerBase
    {
        [HttpGet]
        public List<Guid> GetAll()
        {
            return new List<Guid>
            {
                _singletonService1.GetToken(),
                _singletonService2.GetToken()
            };
        }
    }
}
