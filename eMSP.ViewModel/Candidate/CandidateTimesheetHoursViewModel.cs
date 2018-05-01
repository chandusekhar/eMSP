using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidateTimesheetHoursViewModel
    {
        public long ID { get; set; }
        public long TimesheetID { get; set; }
        public System.DateTime TimeDate { get; set; }
        public Nullable<decimal> HoursWorked { get; set; }
        public Nullable<decimal> BreakHours { get; set; }
    }
}
