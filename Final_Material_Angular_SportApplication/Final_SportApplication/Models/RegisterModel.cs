using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string RoleId { get; set; }
        public List<IdentityRole> roleViewList { get; set; }

        public RegisterModel()
        {
            roleViewList = new List<IdentityRole>();
        }
    }
}
