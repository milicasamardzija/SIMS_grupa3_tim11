using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Note
    {
        public String description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Boolean IsSetReminder { get; set; } = false;

        public Note()
        {
        }

        public Note(string descriptionOfNote, DateTime startDate, DateTime endDate, DateTime startPeriodOfTime, DateTime endPeriodOfTime)
        {
            description = descriptionOfNote;
            StartDate = startDate;
            EndDate = endDate;

        }
    }
}

