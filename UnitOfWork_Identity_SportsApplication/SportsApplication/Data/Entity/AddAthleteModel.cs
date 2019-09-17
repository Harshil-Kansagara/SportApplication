using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class AddAthleteModel
    {
        public int testId { get; set; }

        [Required(ErrorMessage = "Athlete Name is Required")]
        public int athlete_id { get; set; }

        [Required]
        public int distance { get; set; }
        public List<AllAthleteList> athleteList { get; set; }
    }
}
