using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.JobVacancies
{
    

    public class VacancyCommentsCreateModel : BaseModel
    {
        public VacancyCommentsCreateModel() { }
        public long id { get; set; }
        public long vacancyId { get; set; }
        public long commentId { get; set; }       
    }
}
