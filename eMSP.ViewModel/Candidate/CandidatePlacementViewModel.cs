using eMSP.ViewModel.MSP;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidatePlacementViewModel : BaseModel
    {
        public CandidatePlacementViewModel()
        {
        }

        public long ID { get; set; }
        public long SubmissionID { get; set; }
        public long TimeGroupID { get; set; }
        public CandidateSubmissionModel CandidateSubmission { get; set; }
        public MSPTimeGroupViewModel MSPTimeGroup { get; set; }
        public CandidateSubmissionSpendViewModel CandidateSubmissionSpend { get; set; }
        public CandidateTimesheetViewModel CandidateTimesheet { get; set; }
    }

    public class CreateCandidatePlacementViewModel
    {
        public long placementId { get; set; }
        public long jobId { get; set; }
        public string jobTitle { get; set; }
        public DateTime? jobStart { get; set; }
        public DateTime jobEnd { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public decimal? payRate { get; set; }
        public decimal? billRate { get; set; }
        public long SubmissionID { get; set; }
        public long timeGroup { get; set; }
        public string password { get; set; }
        public string userId { get; set; }
        public bool formIsActive { get; set; }

    }
}
