using Haze.Authentication.Domain.Enums;
using Haze.Core.Domain.Entities;

namespace Haze.Authentication.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }
    }
}