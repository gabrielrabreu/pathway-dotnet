using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string error)
        {
            _errors.Add(error);
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new
            {
                errors = _errors
            });
        }
    }
}
