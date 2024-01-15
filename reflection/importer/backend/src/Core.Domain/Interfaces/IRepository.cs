﻿using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        IQueryable<TEntity> Query();

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
