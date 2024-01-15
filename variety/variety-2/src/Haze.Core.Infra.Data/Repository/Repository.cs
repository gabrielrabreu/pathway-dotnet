using Haze.Core.Domain.Entities;
using Haze.Core.Domain.Repositories;
using Haze.Core.Domain.Uow;
using Haze.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haze.Core.Infra.Data.Repository
{
    public class Repository<TEntity> : TenantRepository, IRepository<TEntity> where TEntity : Entity
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public IUnitOfWork Uow => _dbContext;

        protected Repository(IDbContext dbContext)
            : base(dbContext.Tenant)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.Tenant = Tenant;
            entity.InsertDate = DateTime.Now;
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            entity.Tenant = Tenant;
            entity.UpdateDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            _dbSet.Remove(await GetByIdAsync(id));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Query().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            return await Query().Where(e => e.Id == id).SingleOrDefaultAsync();
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet.Where(x => x.Tenant == Tenant);
        }
    }
}