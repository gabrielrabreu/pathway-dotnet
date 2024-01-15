using Haze.Authentication.Domain.Entities;
using Haze.Authentication.Domain.Uow;
using Haze.Core.Infra.Data.Accessor;
using Haze.Core.Infra.Data.Common;
using Haze.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Haze.Authentication.Infra.Data.Context
{
    public class AuthenticationDataDbContext : BaseDbContext, IAuthenticationDataUnitOfWork
    {
        public DbSet<User> User { get; set; }

        public AuthenticationDataDbContext(IDatabaseSettingsProvider databaseSettingsProvider, ITenantAccessor tenantAccessor)
            : base(databaseSettingsProvider.GetDatabaseSettings().DataConnection,
                   $"haze_{Config.Stage}_data",
                   tenantAccessor.GetTenant())
        { }

        public class DbContextFactory : DesignTimeDbContextFactory<AuthenticationDataDbContext>
        {
            protected override AuthenticationDataDbContext Create()
            {
                return new AuthenticationDataDbContext(new DatabaseSettingsProvider(Config.DatabaseSettings),
                    new CustomTenantAccessor(CustomTenantAccessor.DesignTimeTenant));
            }
        }
    }
}