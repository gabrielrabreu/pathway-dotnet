using Haze.Authentication.Domain.Entities;
using Haze.Authentication.Domain.Repositories;
using Haze.Authentication.Infra.Data.Context;
using Haze.Authentication.Web.PasswordHashing;
using Haze.Core.Infra.Data.Repository;
using System.Linq;

namespace Haze.Authentication.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AuthenticationDataDbContext authenticationDataDbContext)
            : base(authenticationDataDbContext) { }

        public User GetByCredentials(string username, string inputPassword)
        {
            return Query().Where(u => u.Username == username)
                          .AsEnumerable()
                          .Where(u => PasswordHashService.Verify(inputPassword, u.Password)).FirstOrDefault();
        }

        public bool UserExists(string username)
        {
            return Query().Any(x => x.Username == username);
        }
    }
}