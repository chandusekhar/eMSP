using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;

namespace eMSP.ViewModel.MSP
{
    public class MSPPayPeriodViewModel: BaseModel
    {
        public MSPPayPeriodViewModel()
        {
            this.CandidateSubmissionSpends = new HashSet<CandidateSubmissionSpendViewModel>();
            this.CandidateTimesheets = new HashSet<CandidateTimesheetViewModel>();
        }

        public long ID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        

        public virtual ICollection<CandidateSubmissionSpendViewModel> CandidateSubmissionSpends { get; set; }
        public virtual ICollection<CandidateTimesheetViewModel> CandidateTimesheets { get; set; }
    }
}
