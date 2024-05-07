using DI.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DI.WebApi.Controllers
{
    [ApiController]
    [Route("transients")]
    public class TransientController(
        ITransientService _transientService1,
        ITransientService _transientService2
    ) : ControllerBase
    {
        [HttpGet]
        public List<Guid> GetAll()
        {
            return new List<Guid>
            {
                _transientService1.GetToken(),
                _transientService2.GetToken()
            };
        }
    }
}
