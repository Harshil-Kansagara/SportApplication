using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class TestListsModel
    {
        public List<int> participantCount { get; set; }

        public List<TestList> testLists { get; set; }

        public TestListsModel()
        {
            participantCount = new List<int>();
        }
    }
}
