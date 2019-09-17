using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Data.Entity
{
    public class TestList
    {
        [Key]
        public int id { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int participant_num { get; set; }
        public string test_type { get; set; }
    }
}
