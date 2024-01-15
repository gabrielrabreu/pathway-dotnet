using Haze.Anything.Application.Interfaces;
using Haze.Anything.Caching.Interfaces;
using Haze.Anything.Caching.Models;
using Haze.Core.Caching.Search;
using Haze.Core.Domain.Notifications;
using Haze.Core.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haze.API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FulanoController : BaseController
    {
        private readonly IFulanoAppService _fulanoAppService;
        private readonly IFulanoQuery _fulanoQuery;

        public FulanoController(INotificationHandler<DomainNotification> notifications,
                                IFulanoAppService fulanoAppService,
                                IFulanoQuery fulanoQuery)
            : base(notifications)
        {
            _fulanoAppService = fulanoAppService;
            _fulanoQuery = fulanoQuery;
        }

        /// <summary>
        /// Add new Fulano
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FulanoModel model)
        {
            System.Console.WriteLine($"FulanoController/Post - FulanoAgent: {HttpContext.Request.Headers["Fulano-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            await _fulanoAppService.AddAsync(model);
            return Response();
        }

        /// <summary>
        /// Update Fulano
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FulanoModel model)
        {
            System.Console.WriteLine($"FulanoController/Put - FulanoAgent: {HttpContext.Request.Headers["Fulano-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            await _fulanoAppService.UpdateAsync(model);
            return Response();
        }

        /// <summary>
        /// Deletes Fulano
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            System.Console.WriteLine($"FulanoController/Delete - FulanoAgent: {HttpContext.Request.Headers["Fulano-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            await _fulanoAppService.RemoveAsync(id);
            return Response();
        }

        /// <summary>
        /// Get Fulano
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public FulanoModel GetById(Guid id)
        {
            System.Console.WriteLine($"FulanoController/GetById - UserAgent: {HttpContext.Request.Headers["User-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            return _fulanoQuery.GetById(id);
        }

        /// <summary>
        /// Get All Fulanos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<FulanoModel> GetAll()
        {
            System.Console.WriteLine($"FulanoController/GetAll - UserAgent: {HttpContext.Request.Headers["User-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            return _fulanoQuery.GetAll();
        }

        /// <summary>
        /// Search Fulano
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        [HttpPost("search")]
        public IEnumerable<FulanoModel> Search([FromBody] SearchModel searchModel)
        {
            System.Console.WriteLine($"FulanoController/Search - UserAgent: {HttpContext.Request.Headers["User-Agent"]} - IP: {HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");

            return _fulanoQuery.Search(searchModel);
        }
    }
}