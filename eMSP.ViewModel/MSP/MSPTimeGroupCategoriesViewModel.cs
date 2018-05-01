using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.MSP
{
    public class MSPTimeGroupCategoriesViewModel: BaseModel
    {
        public MSPTimeGroupCategoriesViewModel()
        {
            this.CandidateTimesheetCategoriesHours = new HashSet<CandidateTimesheetCategoriesHoursViewModel>();
        }

        public long ID { get; set; }
        public long GroupID { get; set; }
        public long CategoryID { get; set; }
        public decimal WeeklyMarkup { get; set; }
        public int DailyMaxHours { get; set; }
        public int WeeklyMaxHours { get; set; }
        public int MonthlyMaxHours { get; set; }
        

        public virtual ICollection<CandidateTimesheetCategoriesHoursViewModel> CandidateTimesheetCategoriesHours { get; set; }
    }
}
