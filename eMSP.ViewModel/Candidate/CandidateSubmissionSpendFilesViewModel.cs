using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidateSubmissionSpendFilesViewModel : BaseModel
    {
        public long ID { get; set; }
        public long SpendID { get; set; }
        public long FileID { get; set; }
        public virtual CandidateSubmissionSpendViewModel CandidateSubmissionSpend { get; set; }
        public virtual FileModel File { get; set; }
    }
}
