using AutoMapper;
using Haze.Anything.Caching.CacheRepositories;
using Haze.Anything.Caching.Entities;
using Haze.Anything.Caching.Models;
using Haze.Anything.Domain.Entities;
using Haze.Anything.Domain.Repositories;
using Haze.Anything.Infra.Data.Context;
using Haze.Core.Infra.Data.CacheRepositories;
using System.Linq;

namespace Haze.Anything.Infra.Data.Caching.CacheRepositories
{
    public class FulanoCacheRepository : CacheRepository<FulanoCache, Fulano, FulanoModel>, IFulanoCacheRepository
    {
        private readonly IFulanoRepository _fulanoRepository;

        public FulanoCacheRepository(AnythingCacheDbContext anythingCacheDbContext,
                                     IFulanoRepository fulanoRepository,
                                     IMapper mapper)
            : base(anythingCacheDbContext, mapper)
        {
            _fulanoRepository = fulanoRepository;
        }

        public override IQueryable<Fulano> Query()
        {
            return _fulanoRepository.Query();
        }
    }
}