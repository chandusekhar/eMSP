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
        public string stateId { get; set; }
        public string stateName { get; set; }
        public string countryId { get; set; }
        public string countryName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public DateTime createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}
