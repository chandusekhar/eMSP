using eMSP.ViewModel.JobVacancies;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel
{
  public partial class QuestionViewModel:BaseModel
    {
        public QuestionViewModel()
        {
            this.VacancyQuestion = new HashSet<VacancyQuestionViewModel>();
        }

        public long ID { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDescription { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<bool> IsMandatory { get; set; }
                
        public virtual ICollection<VacancyQuestionViewModel> VacancyQuestion { get; set; }
    }
}
