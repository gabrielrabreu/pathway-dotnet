using Microsoft.EntityFrameworkCore.Design;

namespace Haze.Core.Infra.Data.Context
{
    public abstract class DesignTimeDbContextFactory<T> : IDesignTimeDbContextFactory<T>
        where T : BaseDbContext
    {
        public T CreateDbContext(string[] args)
        {
            return Create();
        }

        protected abstract T Create();
    }
}