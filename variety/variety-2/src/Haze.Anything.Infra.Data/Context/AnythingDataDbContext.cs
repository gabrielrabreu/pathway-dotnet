using Haze.Anything.Domain.Entities;
using Haze.Anything.Domain.Uow;
using Haze.Core.Infra.Data.Accessor;
using Haze.Core.Infra.Data.Common;
using Haze.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Haze.Anything.Infra.Data.Context
{
    public class AnythingDataDbContext : BaseDbContext, IAnythingDataUnitOfWork
    {
        public DbSet<Fulano> Fulano { get; set; }

        public AnythingDataDbContext(IDatabaseSettingsProvider databaseSettingsProvider, ITenantAccessor tenantAccessor)
            : base(databaseSettingsProvider.GetDatabaseSettings().DataConnection,
                   $"haze_{Config.Stage}_data",
                   tenantAccessor.GetTenant())
        { }

        public class DbContextFactory : DesignTimeDbContextFactory<AnythingDataDbContext>
        {
            protected override AnythingDataDbContext Create()
            {
                return new AnythingDataDbContext(new DatabaseSettingsProvider(Config.DatabaseSettings),
                    new CustomTenantAccessor(CustomTenantAccessor.DesignTimeTenant));
            }
        }
    }
}