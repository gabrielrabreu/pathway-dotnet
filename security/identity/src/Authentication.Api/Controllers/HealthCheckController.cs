using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult HealthCheck()
        {
            return Ok();
        }
    }
}
