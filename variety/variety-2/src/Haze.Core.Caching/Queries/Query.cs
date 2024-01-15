using Haze.Core.Caching.CacheRepositories;
using Haze.Core.Caching.Entities;
using Haze.Core.Caching.Models;
using Haze.Core.Caching.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Haze.Core.Caching.Queries
{
    public abstract class Query<TModel, TCacheEntity> : IQuery<TModel>
        where TModel : Model
        where TCacheEntity : CacheEntity
    {
        private readonly ICacheRepository<TCacheEntity> _cacheRepository;

        protected Query(ICacheRepository<TCacheEntity> cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public TModel GetById(Guid id)
        {
            var cacheEntity = _cacheRepository.GetById(id);

            if (cacheEntity == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<TModel>(cacheEntity.Data);
        }

        public IEnumerable<TModel> GetAll()
        {
            var cacheEntities = _cacheRepository.GetAll();

            var models = new List<TModel>();

            foreach (var cacheEntity in cacheEntities)
            {
                models.Add(JsonConvert.DeserializeObject<TModel>(cacheEntity.Data));
            }

            return models;
        }

        public IEnumerable<TModel> Search(SearchModel searchModel)
        {
            var cacheEntities = _cacheRepository.Search(searchModel);

            var models = new List<TModel>();

            foreach (var cacheEntity in cacheEntities)
            {
                models.Add(JsonConvert.DeserializeObject<TModel>(cacheEntity.Data));
            }

            return models;
        }
    }
}