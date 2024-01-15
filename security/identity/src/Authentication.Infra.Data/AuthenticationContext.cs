using Authentication.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Authentication.Infra.Data
{
    public class AuthenticationContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options) { }
    }
}
