using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.ViewModel.Candidate;

namespace eMSP.ViewModel.MSP
{
    public class MSPTimeGroupViewModel: BaseModel
    {
        public MSPTimeGroupViewModel()
        {
            this.CandidatePlacements = new HashSet<CandidatePlacementViewModel>();
        }

        public long ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CandidatePlacementViewModel> CandidatePlacements { get; set; }
    }
}
