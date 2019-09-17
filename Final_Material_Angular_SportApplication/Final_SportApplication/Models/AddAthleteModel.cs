using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class AddAthleteModel
    {
        public int TestId { get; set; }
        public int AthleteId { get; set; }
        public int Distance { get; set; }
        public List<AthleteListModel> athleteList { get; set; }
    }
}
