using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidateTimesheetCategoriesHoursViewModel
    {
        public long ID { get; set; }
        public long TimesheetID { get; set; }
        public long TimesheetCategoryID { get; set; }
        public System.DateTime TimeDate { get; set; }
        public decimal Hours { get; set; }

        public CandidateTimesheetViewModel CandidateTimesheet { get; set; }
        public MSPTimeGroupCategoriesViewModel MSPTimeGroupCategories { get; set; }
    }
}
