using Haze.Core.Domain.Repositories;

namespace Haze.Core.Infra.Data.Repository
{
    public abstract class TenantRepository : ITenantRepository
    {
        protected readonly string Tenant;

        protected TenantRepository(string tenant)
        {
            Tenant = tenant;
        }

        protected string GetTenantSqlFilter()
        {
            if (!string.IsNullOrEmpty(Tenant))
            {
                return $"Tenant = '{Tenant}'";
            }

            return "1=2";
        }
    }
}