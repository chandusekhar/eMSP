using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.LocationBranch
{
    public class BranchCreateModel : LocationBranchModel
    {
        public BranchCreateModel()
        {

        }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string streetLine1 { get; set; }
        public string streetLine2 { get; set; }
        public string city { get; set; }
        public Nullable<int> stateId { get; set; }
        public Nullable<int> countryId { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public DateTime createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}
