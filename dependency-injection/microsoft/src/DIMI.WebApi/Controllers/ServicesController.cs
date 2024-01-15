using DIMI.WebApi.Services;
using DIMI.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DIMI.WebApi.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServicesController : ControllerBase
    {
        private readonly ITransientService _transientService1;
        private readonly IScopedService _scopedService1;
        private readonly ISingletonService _singletonService1;

        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService2;

        public ServicesController(ITransientService transientService1,
                                  IScopedService scopedService1,
                                  ISingletonService singletonService1,
                                  ITransientService transientService2,
                                  IScopedService scopedService2,
                                  ISingletonService singletonService2)
        {
            _transientService1 = transientService1;
            _scopedService1 = scopedService1;
            _singletonService1 = singletonService1;
            _transientService2 = transientService2;
            _scopedService2 = scopedService2;
            _singletonService2 = singletonService2;
        }

        [HttpGet("transient")]
        public IActionResult Transient()
        {
            return Ok(new Guid[] { _transientService1.Id, _transientService2.Id });
        }

        [HttpGet("scoped")]
        public IActionResult Scoped()
        {
            return Ok(new Guid[] { _scopedService1.Id, _scopedService2.Id });
        }

        [HttpGet("singleton")]
        public IActionResult Singleton()
        {
            return Ok(new Guid[] { _singletonService1.Id, _singletonService2.Id });
        }
    }
}
