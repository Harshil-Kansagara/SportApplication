using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class LoginModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
