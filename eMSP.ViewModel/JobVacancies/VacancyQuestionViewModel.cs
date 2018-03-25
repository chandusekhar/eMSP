using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.JobVacancies
{
    public partial class VacancyQuestionViewModel : BaseModel
    {

        public VacancyQuestionViewModel()
        {
            this.CandidateSubmissionsQuestionsResponse = new HashSet<CandidateSubmissionsQuestionsResponseViewModel>();
        }

        public long ID { get; set; }
        public long VacancyID { get; set; }
        public long QuestionID { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDescription { get; set; }
        public Nullable<bool> IsMandatory { get; set; }
        public Nullable<bool> IsSelected { get; set; }

        public virtual ICollection<CandidateSubmissionsQuestionsResponseViewModel> CandidateSubmissionsQuestionsResponse { get; set; }
        public virtual QuestionViewModel Question { get; set; }
        public virtual VacancyModel Vacancy { get; set; }
    }
}
