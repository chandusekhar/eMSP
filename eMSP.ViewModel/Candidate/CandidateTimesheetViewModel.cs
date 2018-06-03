using eMSP.ViewModel.MSP;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidateTimesheetViewModel: BaseModel
    {
        public CandidateTimesheetViewModel()
        {
            this.CandidateTimesheetHours = new HashSet<CandidateTimesheetHoursViewModel>();
            this.CandidateTimesheetCategoriesHours=new HashSet<CandidateTimesheetCategoriesHoursViewModel>();
        }

        public long ID { get; set; }
        public long PayPeriodID { get; set; }
        public long PlacementID { get; set; }
        public long StatusID { get; set; }
        public short VersionNumber { get; set; }
        
        public virtual ICollection<CandidateTimesheetHoursViewModel> CandidateTimesheetHours { get; set; }
        public virtual ICollection<CandidateTimesheetCategoriesHoursViewModel> CandidateTimesheetCategoriesHours { get; set; }
        public virtual CandidatePlacementViewModel CandidatePlacement { get; set; }
        public MSPPayPeriodViewModel MSPPayPeriods { get; set; }
        public TimesheetStatusViewModel TimesheetStatus { get; set; }
    }
}
