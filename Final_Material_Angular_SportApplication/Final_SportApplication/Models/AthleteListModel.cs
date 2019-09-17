using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class AthleteListModel
    {
        [Key]
        public int Id { get; set; }
        public string CoachId { get; set; }
        public string AthleteName { get; set; }
    }
}
