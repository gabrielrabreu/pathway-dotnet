using Haze.Authentication.Domain.Enums;
using System.Collections.Generic;

namespace Haze.Authentication.Domain.Common
{
    public static class AuthorizationRoles
    {
        public static string NormalAuthorizationRoles()
        {
            return string.Join(",", new List<UserRoles>() { UserRoles.Normal, UserRoles.Admin });
        }

        public static string AdminAuthorizationRoles()
        {
            return string.Join(",", new List<UserRoles>() { UserRoles.Admin });
        }
    }
}