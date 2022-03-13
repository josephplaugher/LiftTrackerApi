using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace LiftTrackerApi.Data
{
    public class Users : IdentityUser
    {
        public int ed { get; set; }
        public string email { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string password { get; set; }
    }
}
