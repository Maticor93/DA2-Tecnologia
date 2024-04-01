using DI.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DI.WebApi.Controllers
{
    [ApiController]
    [Route("singletons")]
    public class SingletonController : ControllerBase
    {
        private readonly ISingletonService _singletonService1;

        private readonly ISingletonService _singletonService2;

        public SingletonController(ISingletonService singletonService1, ISingletonService singletonService2)
        {
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

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
