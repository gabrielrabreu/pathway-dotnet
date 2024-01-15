using Core.Application.Interfaces;
using Something.Application.DataTransferObjects.ImportDTOs;

namespace Something.Application.Interfaces
{
    public interface IImportAppService : IAppService<ImportDto, AddImportDto> { }
}
