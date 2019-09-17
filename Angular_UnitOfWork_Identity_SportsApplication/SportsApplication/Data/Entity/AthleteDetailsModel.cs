using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class AthleteDetailsModel
    {
        public List<AthleteByTest> athleteByTests { get; set; }
        public List<TestList> testLists { get; set; }
        public List<ApplicationUser> coach { get; set; }

        public AthleteDetailsModel()
        {
            athleteByTests = new List<AthleteByTest>();
        }
    }
}
