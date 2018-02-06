using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.JobVacancies
{    

    public class MSPVacancieTypeCreateModel: BaseModel
    {
        public MSPVacancieTypeCreateModel() { }
        public short id { get; set; }        
        public long mspId { get; set; }
        public string name { get; set; }        
    }
}
