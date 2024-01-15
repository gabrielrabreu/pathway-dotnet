using Haze.Authentication.Caching.Models;
using Haze.Core.Application.Interfaces;

namespace Haze.Authentication.Application.Interfaces
{
    public interface IUserAppService : IAppService<UserModel>
    {
        string Login(UserModel model);
    }
}