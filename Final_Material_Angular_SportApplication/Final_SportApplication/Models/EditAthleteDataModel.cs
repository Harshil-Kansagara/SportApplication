using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_SportApplication.Models
{
    public class EditAthleteDataModel
    {
        public int TestId { get; set; }

        public int AthleteId { get; set; }
        public int Id { get; set; }

        public List<AthleteListModel> AthleteList { get; set; }

        public int Distance { get; set; }
    }
}
