using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.LocationBranch
{

    public class LocationBranchModel
    {
        public LocationBranchModel() { }
        public long id { get; set; }
        public long locationId { get; set; }
        public string locationName { get; set; }
        public long? branchId { get; set; }
        public string branchName { get; set; }
        public string companyType { get; set; }
        public string companyName { get; set; }
        public long companyId { get; set; }
    }

    //public class LocationBranchCommon : LocationCreateModel
    //{
    //    public LocationBranchCommon() { }
    //    public long locationID { get; set; }
    //    public Nullable<long> branchID { get; set; }
    //}
}
