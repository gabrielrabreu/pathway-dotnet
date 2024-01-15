using System.Threading.Tasks;

namespace Haze.Core.Domain.Uow
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}