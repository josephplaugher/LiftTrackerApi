using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftTrackerApi.Data
{
    public class UserRoles : IdentityRole<Guid>
    {
        public UserRoles() : base()
        {
        }

        public UserRoles(string roleName)
            : base(roleName)
        {
        }
    }
}
