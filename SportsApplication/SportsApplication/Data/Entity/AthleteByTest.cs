using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class AthleteByTest
    {
        [Key]
        public int id { get; set; }
        public int test_id { get; set; }

        public int athlete_id { get; set; }
        public int athlete_distance { get; set;}
    }
}
