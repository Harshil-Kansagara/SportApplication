using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
