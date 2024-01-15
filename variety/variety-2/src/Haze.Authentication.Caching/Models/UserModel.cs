using Haze.Authentication.Domain.Enums;
using Haze.Core.Caching.Models;

namespace Haze.Authentication.Caching.Models
{
    public class UserModel : Model
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }
    }
}