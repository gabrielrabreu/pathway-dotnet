using AutoMapper;
using Core.Application.Services;
using Core.Domain.Mediator;
using Something.Application.DataTransferObjects.ImportLayoutDTOs;
using Something.Application.Interfaces;
using Something.Domain.Commands.ImportLayoutCommands;
using Something.Domain.Entities;
using Something.Domain.Interfaces;
using System.Threading.Tasks;

namespace Something.Application.Services
{
    public class ImportLayoutAppService : AppService<ImportLayoutDto, AddImportLayoutDto, ImportLayout>,
        IImportLayoutAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ImportLayoutAppService(IMapper mapper,
                                      IMediatorHandler mediator,
                                      IImportLayoutRepository importLayoutRepository)
            : base(mapper, importLayoutRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task Add(AddImportLayoutDto addImportLayoutDto)
        {
            await _mediator.SendCommand(_mapper.Map<AddImportLayoutCommand>(addImportLayoutDto));
        }
    }
}
