using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Shared
{        
    public class CountryCreateModel : BaseModel
    {
        public CountryCreateModel() { }
        public string countryName { get; set; }
        public string countryCode { get; set; }
        public long id { get; set; }        
    }
}

