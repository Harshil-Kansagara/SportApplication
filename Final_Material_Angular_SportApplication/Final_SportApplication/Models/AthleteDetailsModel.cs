using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class AthleteDetailsModel
    {
        public List<AthleteByTestModel> athleteByTests { get; set; }
        public List<TestListModel> testLists { get; set; }
        public List<ApplicationUser> coach { get; set; }

        public AthleteDetailsModel()
        {
            athleteByTests = new List<AthleteByTestModel>();
        }
    }
}
