using Haze.Core.Domain.Uow;
using Microsoft.EntityFrameworkCore;

namespace Haze.Core.Infra.Data.Context
{
    public interface IDbContext : IUnitOfWork
    {
        string Tenant { get; }

        DbSet<T> Set<T>() where T : class;
    }
}