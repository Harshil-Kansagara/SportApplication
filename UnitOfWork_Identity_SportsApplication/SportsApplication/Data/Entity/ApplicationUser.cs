using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string RoleId { get; set; }
    }
}
