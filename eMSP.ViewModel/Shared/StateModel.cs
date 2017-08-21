using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Shared
{
    public class StateModel
    {
        public StateModel() { }
        public string stateName { get; set; }
        public long id { get; set; }
    }

    public class StateSearchModel : StateModel
    {
        public StateSearchModel()
        {

        }
        public long countryId { get; set; }
        public string stateCode { get; set; }
    }

    public class StateCreateModel : StateSearchModel
    {
        public StateCreateModel()
        {

        }
        public bool? isActive { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}

