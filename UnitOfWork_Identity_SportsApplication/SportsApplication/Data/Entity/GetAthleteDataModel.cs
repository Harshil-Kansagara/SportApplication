using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class GetAthleteDataModel
    {
        public int TestId { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string test_type { get; set; }
        
        public List<AthleteByTest> AthleteList { get; set; }

        public List<AllAthleteList> allAthleteLists { get; set; }
    }
}
