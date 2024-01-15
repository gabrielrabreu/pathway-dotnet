using Core.Application.Interfaces;
using Something.Application.DataTransferObjects.XptoDtos;

namespace Something.Application.Interfaces
{
    public interface IXptoAppService : IAppService<XptoDto, AddXptoDto> 
    {
    }
}
