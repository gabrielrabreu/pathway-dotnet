using Haze.Authentication.Application.Interfaces;
using Haze.Authentication.Caching.Models;
using Haze.Core.Domain.Notifications;
using Haze.Core.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Haze.API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserAppService _userAppService;

        public UserController(INotificationHandler<DomainNotification> notifications,
                              IUserAppService userAppService)
            : base(notifications)
        {
            _userAppService = userAppService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel model)
        {
            System.Console.WriteLine($"UserController/Login - UserAgent: {HttpContext.Request.Headers["User-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            var result = _userAppService.Login(model);

            if (result is null)
            {
                return Unauthorized(new
                {
                    error = "Credenciais inválidas."
                });
            }

            return Ok(new
            {
                token = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel model)
        {
            System.Console.WriteLine($"UserController/Post - UserAgent: {HttpContext.Request.Headers["User-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            await _userAppService.AddAsync(model);
            return Response();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserModel model)
        {
            System.Console.WriteLine($"UserController/Put - UserAgent: {HttpContext.Request.Headers["User-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            await _userAppService.UpdateAsync(model);
            return Response();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            System.Console.WriteLine($"UserController/Delete - UserAgent: {HttpContext.Request.Headers["User-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            await _userAppService.RemoveAsync(id);
            return Response();
        }
    }
}