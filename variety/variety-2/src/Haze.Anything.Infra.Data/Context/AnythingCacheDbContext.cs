using Haze.Anything.Caching.Entities;
using Haze.Anything.Domain.Uow;
using Haze.Core.Infra.Data.Accessor;
using Haze.Core.Infra.Data.Common;
using Haze.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Haze.Anything.Infra.Data.Context
{
    public class AnythingCacheDbContext : BaseDbContext, IAnythingCacheUnitOfWork
    {
        public DbSet<FulanoCache> FulanoCache { get; set; }

        public AnythingCacheDbContext(IDatabaseSettingsProvider databaseSettingsProvider, ITenantAccessor tenantAccessor)
            : base(databaseSettingsProvider.GetDatabaseSettings().CacheConnection,
                   $"haze_{Config.Stage}_cache",
                   tenantAccessor.GetTenant())
        { }

        public class DbContextFactory : DesignTimeDbContextFactory<AnythingCacheDbContext>
        {
            protected override AnythingCacheDbContext Create()
            {
                return new AnythingCacheDbContext(new DatabaseSettingsProvider(Config.DatabaseSettings),
                    new CustomTenantAccessor(CustomTenantAccessor.DesignTimeTenant));
            }
        }
    }
}