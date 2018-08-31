using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.MSP
{
    public class MSPTimeCategoriesViewModel: BaseModel
    {   
        public long ID { get; set; }
        public long MSPID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual MSPDetailsUIModel MSPDetail { get; set; }
    }
}
