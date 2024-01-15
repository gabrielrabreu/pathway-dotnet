using Haze.Core.Infra.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Haze.Core.Infra.Data.Context
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        private readonly string _databaseName;
        public string Tenant { get; }
        public ConnectionInfo ConnectionInfo { get; }

        protected BaseDbContext(ConnectionInfo connectionInfo, string databaseName, string tenant)
        {
            _databaseName = databaseName;
            Tenant = tenant;
            ConnectionInfo = connectionInfo;
        }

        public async Task<bool> CommitAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString =
                $"Server={ConnectionInfo.Server};Database={_databaseName};User Id={ConnectionInfo.Username};Password={ConnectionInfo.Password};";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}