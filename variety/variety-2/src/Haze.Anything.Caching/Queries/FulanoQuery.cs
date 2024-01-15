using Haze.Anything.Caching.CacheRepositories;
using Haze.Anything.Caching.Entities;
using Haze.Anything.Caching.Interfaces;
using Haze.Anything.Caching.Models;
using Haze.Core.Caching.Queries;

namespace Haze.Anything.Caching.Queries
{
    public class FulanoQuery : Query<FulanoModel, FulanoCache>, IFulanoQuery
    {
        public FulanoQuery(IFulanoCacheRepository fulanoCacheRepository)
            : base(fulanoCacheRepository) { }
    }
}