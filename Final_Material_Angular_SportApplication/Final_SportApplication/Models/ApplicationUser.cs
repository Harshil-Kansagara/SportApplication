using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string RoleId { get; set; }
    }
}
