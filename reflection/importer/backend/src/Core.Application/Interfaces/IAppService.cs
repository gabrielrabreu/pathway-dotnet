using Core.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IAppService<TDTO, TAddDTO>
        where TDTO : DataTransferObject
        where TAddDTO : DataTransferObject
    {
        Task<IEnumerable<TDTO>> GetAll();
        Task<TDTO> GetById(Guid id);

        Task Add(TAddDTO addDTO);
    }
}
