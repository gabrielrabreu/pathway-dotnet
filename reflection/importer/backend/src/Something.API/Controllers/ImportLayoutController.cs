using Core.API.Controllers;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Something.Application.DataTransferObjects.ImportLayoutDTOs;
using Something.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Something.API.Controllers
{
    [Route("api/import-layout")]
    public class ImportLayoutController : BaseController
    {
        private readonly IImportLayoutAppService _importLayoutAppService;

        public ImportLayoutController(INotificationHandler<DomainNotification> notifications,
                                      IImportLayoutAppService importLayoutAppService)
            : base(notifications)
        {
            _importLayoutAppService = importLayoutAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<ImportLayoutDto>> Get()
        {
            return await _importLayoutAppService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<ImportLayoutDto> GetById(Guid id)
        {
            return await _importLayoutAppService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddImportLayoutDto addImportLayoutDto)
        {
            await _importLayoutAppService.Add(addImportLayoutDto);
            return Response();
        }
    }
}
