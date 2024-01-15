﻿using DotNetSearch.API.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetSearch.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected new IActionResult Response(ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity(new UnprocessableEntityResponse()
                {
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage)
                });
            }
        }
    }
}
