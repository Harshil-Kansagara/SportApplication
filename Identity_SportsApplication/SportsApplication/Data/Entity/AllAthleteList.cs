using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class AllAthleteList
    {
        [Key]
        public int id { get; set; }

        public string coachId { get; set; }
        [Required]
        public string athlete_name { get; set; }
    }
}
