using Haze.Core.Caching.Entities;
using Haze.Core.Caching.Search;
using Haze.Core.Domain.Repositories;
using Haze.Core.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haze.Core.Caching.CacheRepositories
{
    public interface ICacheRepository<TCache> : ITenantRepository
            where TCache : CacheEntity
    {
        IUnitOfWork Uow { get; }

        Task AddAsync(Guid id);

        Task UpdateAsync(Guid id);

        Task RemoveAsync(Guid id);

        TCache GetById(Guid id);

        IEnumerable<TCache> GetAll();

        IEnumerable<TCache> Search(SearchModel searchModel);
    }
}