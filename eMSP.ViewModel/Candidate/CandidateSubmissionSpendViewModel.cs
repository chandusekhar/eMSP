using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidateSubmissionSpendViewModel
    {
        public CandidateSubmissionSpendViewModel()
        {
            this.CandidateSubmissionSpendFiles = new HashSet<CandidateSubmissionSpendFilesViewModel>();
        }

        public long ID { get; set; }
        public long PayPeriodID { get; set; }
        public long SpendCategoryID { get; set; }
        public long PlacementID { get; set; }
        public long CurrentStatusID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
        public virtual ICollection<CandidateSubmissionSpendFilesViewModel> CandidateSubmissionSpendFiles { get; set; }
    }
}
