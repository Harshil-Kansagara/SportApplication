using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class TestDetailModel
    {
        public int TestId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string TestType { get; set; }

        public List<AthleteByTestModel> AthleteList { get; set; }

        public List<AthleteListModel> AllAthleteLists { get; set; }
    }
}
