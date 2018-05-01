using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidateTimesheetViewModel
    {
        public CandidateTimesheetViewModel()
        {
            this.CandidateTimesheetCategoriesHours = new HashSet<CandidateTimesheetHoursViewModel>();
        }

        public long ID { get; set; }
        public long PayPeriodID { get; set; }
        public long PlacementID { get; set; }
        public long StatusID { get; set; }
        public short VersionNumber { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
        public virtual ICollection<CandidateTimesheetHoursViewModel> CandidateTimesheetCategoriesHours { get; set; }
    }
}
