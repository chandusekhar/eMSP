using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidatePlacementViewModel: BaseModel
    {
        public CandidatePlacementViewModel()
        {
        }

        public long ID { get; set; }
        public long SubmissionID { get; set; }
        public long TimeGroupID { get; set; }
        
    }
}
