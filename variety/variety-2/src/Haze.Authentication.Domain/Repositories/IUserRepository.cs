using Haze.Authentication.Domain.Entities;
using Haze.Core.Domain.Repositories;

namespace Haze.Authentication.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByCredentials(string username, string password);

        bool UserExists(string username);
    }
}