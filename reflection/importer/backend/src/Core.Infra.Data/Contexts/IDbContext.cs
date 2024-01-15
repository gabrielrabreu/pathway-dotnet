using Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Infra.Data.Contexts
{
    public interface IDbContext : IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;
    }
}
