using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.MSP
{
    public class MSPSpendCategoryViewModel: BaseModel
    {
        public MSPSpendCategoryViewModel()
        {
            this.CandidateSubmissionSpends = new HashSet<CandidateSubmissionSpendViewModel>();
        }

        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        

        public virtual ICollection<CandidateSubmissionSpendViewModel> CandidateSubmissionSpends { get; set; }
    }
}
