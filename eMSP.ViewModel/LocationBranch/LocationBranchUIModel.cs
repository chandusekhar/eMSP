using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.LocationBranch
{
    public partial class LocationBranchUIModel : BaseModel
    {
        public LocationBranchUIModel() { }
        public string ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
