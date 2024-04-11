using DI.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DI.WebApi.Controllers
{
    [ApiController]
    [Route("scopes")]
    public class ScopeController : ControllerBase
    {
        private readonly IScopeService _scopeService1;

        private readonly IScopeService _scopeService2;

        public ScopeController(IScopeService scopeService1, IScopeService scopeService2)
        {
            _scopeService1 = scopeService1;
            _scopeService2 = scopeService2;
        }

        [HttpGet]
        public List<Guid> GetAll()
        {
            return new List<Guid>
            {
                _scopeService1.GetToken(),
                _scopeService2.GetToken()
            };
        }
    }
}
