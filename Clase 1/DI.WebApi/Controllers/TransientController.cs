using DI.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DI.WebApi.Controllers
{
    [ApiController]
    [Route("transients")]
    public class TransientController : ControllerBase
    {
        private readonly ITransientService _transientService1;

        private readonly ITransientService _transientService2;

        public TransientController(ITransientService transientService1, ITransientService transientService2)
        {
            _transientService1 = transientService1;
            _transientService2 = transientService2;
        }

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
