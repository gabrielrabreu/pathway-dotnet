using Core.API.Controllers;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Something.API.Controllers
{
    public class XptoController : BaseController
    {
        private readonly IXptoAppService _xptoAppService;

        public XptoController(INotificationHandler<DomainNotification> notifications, 
                              IXptoAppService xptoAppService) 
            : base(notifications)
        {
            _xptoAppService = xptoAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<XptoDto>> Get()
        {
            return await _xptoAppService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<XptoDto> GetById(Guid id)
        {
            return await _xptoAppService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddXptoDto addXptoDto)
        {
            await _xptoAppService.Add(addXptoDto);
            return Response();
        }
    }
}
