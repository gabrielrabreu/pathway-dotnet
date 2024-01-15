using Microsoft.AspNetCore.Identity;
using System;

namespace Authentication.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid> { }
}
