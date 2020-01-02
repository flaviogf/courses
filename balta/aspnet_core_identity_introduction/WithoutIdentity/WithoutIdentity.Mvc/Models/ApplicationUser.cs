using Microsoft.AspNetCore.Identity;
using System;

namespace WithoutIdentity.Mvc.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {
    }
}
