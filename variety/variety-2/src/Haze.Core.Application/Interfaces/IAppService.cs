using Haze.Core.Caching.Models;
using System;
using System.Threading.Tasks;

namespace Haze.Core.Application.Interfaces
{
    public interface IAppService<TModel> where TModel : Model
    {
        Task AddAsync(TModel model);

        Task UpdateAsync(TModel model);

        Task RemoveAsync(Guid id);
    }
}