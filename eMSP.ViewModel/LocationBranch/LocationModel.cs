using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.LocationBranch
{
    public class LocationCreateModel : LocationBranchModel
    {
        public LocationCreateModel() { }
        public string streetLine1 { get; set; }
        public string streetLine2 { get; set; }
        public string city { get; set; }
        public string stateId { get; set; }
        public string stateName { get; set; }
        public string countryId { get; set; }
        public string countryName { get; set; }
    }
}
