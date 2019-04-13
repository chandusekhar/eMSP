using eMSP.ViewModel.MSP;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidateTimesheetViewModel : BaseModel
    {
        public CandidateTimesheetViewModel()
        {
            this.CandidateTimesheetHours = new HashSet<CandidateTimesheetHoursViewModel>();
            this.CandidateTimesheetCategoriesHours = new HashSet<CandidateTimesheetCategoriesHoursViewModel>();
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

    public class AllTimesheetViewModel
    {
        public AllTimesheetViewModel() { }
        public long ID { get; set; }
        public long PayPeriodID { get; set; }
        public long PlacementID { get; set; }
        public long StatusId { get; set; }
        public string Status { get; set; }
        //public CandidateCreateModel Candidate { get; set; }        
        public string CandidateFirstName { get; set; }
        public long CandidateId { get; set; }
        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public decimal TotalHousr { get; set; }
        public MSPPayPeriodViewModel PayPeriodDetails { get; set; }
    }

    public class TimesheetStateChangeViewModel
    {
        public TimesheetStateChangeViewModel()
        {   
        }

        public long ID { get; set; }
        public long StatusID { get; set; }
        public Nullable<DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}
