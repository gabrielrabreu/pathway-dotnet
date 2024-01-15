using Core.Application.Interfaces;
using Something.Application.DataTransferObjects.ImportLayoutDTOs;

namespace Something.Application.Interfaces
{
    public interface IImportLayoutAppService : IAppService<ImportLayoutDto, AddImportLayoutDto> { }
}
