using Haze.Anything.Domain.Entities;
using Haze.Anything.Domain.Repositories;
using Haze.Anything.Infra.Data.Context;
using Haze.Core.Infra.Data.Repository;

namespace Haze.Anything.Infra.Data.Repositories
{
    public class FulanoRepository : Repository<Fulano>, IFulanoRepository
    {
        public FulanoRepository(AnythingDataDbContext anythingDataDbContext)
            : base(anythingDataDbContext) { }
    }
}