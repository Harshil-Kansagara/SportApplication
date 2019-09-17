using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class AthleteByTestModel
    {
        [Key]
        public int Id { get; set; }
        public int TestId { get; set; }
        public int AthleteId { get; set; }
        public int AthleteDistance { get; set; }
    }
}
