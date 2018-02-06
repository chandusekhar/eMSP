using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Shared
{  
    public class IndustryCreateModel : BaseModel
    {
        public IndustryCreateModel() { }
        public string industryName { get; set; }
        public string industryDescription { get; set; }
        public long id { get; set; }       
    }
}
