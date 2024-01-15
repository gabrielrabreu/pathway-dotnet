using Haze.Core.Domain.Entities;
using Haze.Core.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haze.Core.Domain.Repositories
{
    public interface IRepository<TEntity> : ITenantRepository
        where TEntity : Entity
    {
        IUnitOfWork Uow { get; }

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        Task RemoveAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Guid id);

        IQueryable<TEntity> Query();
    }
}