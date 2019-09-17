using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class AddAthleteModel
    {
        public int testId { get; set; }
        public int athlete_id { get; set; }
        public int distance { get; set; }
        public List<AllAthleteList> athleteList { get; set; }
    }
}
