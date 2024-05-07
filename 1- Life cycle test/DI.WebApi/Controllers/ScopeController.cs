using DI.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DI.WebApi.Controllers
{
    [ApiController]
    [Route("scopes")]
    public class ScopeController(
        IScopeService _scopeService1,
        IScopeService _scopeService2) : ControllerBase
    {
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
