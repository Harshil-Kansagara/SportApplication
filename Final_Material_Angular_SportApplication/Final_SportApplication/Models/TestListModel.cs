using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class TestListModel
    {
        [Key]
        public int Id { get; set; }
        public string CoachId { get; set; }
        public DateTime Date { get; set; }
        public int ParticipantNumber { get; set; }
        public string TestType { get; set; }
    }
}
