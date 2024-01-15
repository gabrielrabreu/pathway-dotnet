using AutoMapper;
using Haze.Core.Caching.CacheRepositories;
using Haze.Core.Caching.Entities;
using Haze.Core.Caching.Enums;
using Haze.Core.Caching.Models;
using Haze.Core.Caching.Search;
using Haze.Core.Domain.Entities;
using Haze.Core.Domain.Uow;
using Haze.Core.Infra.Data.Common;
using Haze.Core.Infra.Data.Context;
using Haze.Core.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haze.Core.Infra.Data.CacheRepositories
{
    public abstract class CacheRepository<TCacheEntity, TEntity, TModel> : TenantRepository, ICacheRepository<TCacheEntity>
        where TCacheEntity : CacheEntity, new()
        where TEntity : Entity
        where TModel : Model
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TCacheEntity> _dbSet;
        private readonly IMapper _mapper;
        public IUnitOfWork Uow => _dbContext;
        private string BaseSqlQuery => $"SELECT * FROM {typeof(TCacheEntity).Name} WHERE {GetTenantSqlFilter()}";

        protected CacheRepository(IDbContext dbContext,
                                  IMapper mapper)
            : base(dbContext.Tenant)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TCacheEntity>();
            _mapper = mapper;
        }

        public async Task AddAsync(Guid id)
        {
            var dbEntity = await Query().Where(c => c.Id == id).SingleOrDefaultAsync();
            var model = _mapper.Map<TModel>(dbEntity);

            var cacheEntity = new TCacheEntity
            {
                Id = dbEntity.Id,
                Tenant = Tenant,
                Data = model.ToJson(),
                Date = DateTime.Now
            };

            await _dbSet.AddAsync(cacheEntity);
            await _dbContext.CommitAsync();
        }

        public async Task UpdateAsync(Guid id)
        {
            await RemoveAsync(id);
            await AddAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var dbEntity = GetById(id);
            if (dbEntity == null)
            {
                return;
            }

            _dbSet.Remove(dbEntity);
            await _dbContext.CommitAsync();
        }

        public TCacheEntity GetById(Guid id)
        {
            return QueryCache($"{BaseSqlQuery} AND Id = '{id}'").SingleOrDefault();
        }

        public IEnumerable<TCacheEntity> GetAll()
        {
            return QueryCache(BaseSqlQuery);
        }

        public IEnumerable<TCacheEntity> Search(SearchModel searchModel)
        {
            // Sort
            var sortSql = "";
            switch (searchModel.SortModel.Direction)
            {
                case SortDirection.Desc:
                    sortSql = $"ORDER BY JSON_VALUE(Data, '$.{searchModel.SortModel.PropertyName}') DESC";
                    break;

                case SortDirection.Asc:
                    sortSql = $"ORDER BY JSON_VALUE(Data, '$.{searchModel.SortModel.PropertyName}') ASC";
                    break;
            }

            // Filter
            var whereSql = "";
            foreach (var filterModel in searchModel.FilterModels)
            {
                switch (filterModel.Operation)
                {
                    case FilterOperation.Contains:
                        whereSql += $"AND JSON_VALUE(Data, '$.{filterModel.PropertyName}') LIKE '%{filterModel.Value}%' ";
                        break;

                    case FilterOperation.Equals:
                        whereSql += $"AND JSON_VALUE(Data, '$.{filterModel.PropertyName}') = '{filterModel.Value}' ";
                        break;
                }
            }

            // Paginate
            var paginateSql = "";
            paginateSql += $"OFFSET ({searchModel.PageNumber}-1) ROWS FETCH NEXT {searchModel.PageSize} ROWS ONLY";

            return QueryCache($"{BaseSqlQuery} {whereSql} {sortSql} {paginateSql}");
        }

        public abstract IQueryable<TEntity> Query();

        private IQueryable<TCacheEntity> QueryCache(string sql, params object[] parameters)
        {
            return _dbSet.FromSqlRaw(sql, parameters);
        }
    }
}