using eMSP.ViewModel.Shared;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidateSubmissionSpendViewModel : BaseModel
    {
        public CandidateSubmissionSpendViewModel()
        {
            this.CandidateSubmissionSpendFiles = new HashSet<CandidateSubmissionSpendFilesViewModel>();
            this.Files = new HashSet<FileModel>();
        }

        public long ID { get; set; }
        public long PayPeriodID { get; set; }
        public long SpendCategoryID { get; set; }
        public long PlacementID { get; set; }
        public long CurrentStatusID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public MSPPayPeriodViewModel MSPPayperiod { get; set; }
        public MSPSpendCategoryViewModel MSPSpendCategory { get; set; }
        public TimesheetStatusViewModel TimesheetStatus { get; set; }
        public CandidatePlacementViewModel CandidatePlacement { get; set; }
        public virtual ICollection<CandidateSubmissionSpendFilesViewModel> CandidateSubmissionSpendFiles { get; set; }

        public virtual ICollection<FileModel> Files { get; set; }
    }
}
