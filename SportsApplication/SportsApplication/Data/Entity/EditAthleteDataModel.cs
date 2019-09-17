using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class EditAthleteDataModel
    {
        public int TestId { get; set; }

        public int athleteId { get; set; }
        public int id { get; set; }

        public List<AllAthleteList> athleteList { get; set; }

        public int distance { get; set; }
    }
}
