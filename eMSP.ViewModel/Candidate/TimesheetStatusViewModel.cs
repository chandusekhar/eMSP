using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class TimesheetStatusViewModel : BaseModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CandidateSubmissionSpendViewModel> CandidateSubmissionSpend { get; set; }
        public virtual ICollection<CandidateTimesheetViewModel> CandidateTimesheet { get; set; }
    }
}
