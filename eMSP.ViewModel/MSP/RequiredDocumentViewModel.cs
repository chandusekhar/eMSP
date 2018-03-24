using eMSP.ViewModel.JobVacancies;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.MSP
{
   public partial class RequiredDocumentViewModel:BaseModel
    {
        
        public RequiredDocumentViewModel()
        {
            this.VacancyRequiredDocument = new HashSet<VacancyRequiredDocumentViewModel>();
        }
        public long ID { get; set; }
        public string RequiredDocumentName { get; set; }
        public string RequiredDocumentDescription { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<bool> IsMandatory { get; set; }                
        public virtual ICollection<VacancyRequiredDocumentViewModel> VacancyRequiredDocument { get; set; }
    }
}
