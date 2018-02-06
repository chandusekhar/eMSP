using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Shared
{
    public class StateCreateModel : BaseModel
    {
        public StateCreateModel() { }
        public string stateName { get; set; }
        public string stateCode { get; set; }
        public long id { get; set; }
        public long countryId { get; set; }
    }
}

