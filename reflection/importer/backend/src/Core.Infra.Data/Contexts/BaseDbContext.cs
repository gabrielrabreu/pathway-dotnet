using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Core.Infra.Data.Contexts
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        protected BaseDbContext(DbContextOptions options) : base(options) { }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
