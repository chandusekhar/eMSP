using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.JobVacancies
{
  public partial class VacancyRequiredDocumentViewModel:BaseModel
    {
        
        public VacancyRequiredDocumentViewModel()
        {
            this.CandidateSubmissionDocumentResponse = new HashSet<CandidateSubmissionDocumentResponseViewModel>();
        }

        public long ID { get; set; }
        public long VacancyID { get; set; }
        public long RequiredDocumentID { get; set; }
        public string RequiredDocumentName { get; set; }
        public string RequiredDocumentDescription { get; set; }
        public Nullable<bool> IsMandatory { get; set; }
                
        public virtual ICollection<CandidateSubmissionDocumentResponseViewModel> CandidateSubmissionDocumentResponse { get; set; }
        public virtual RequiredDocumentViewModel RequiredDocument { get; set; }
        public virtual VacancyModel Vacancy { get; set; }
    }
}
