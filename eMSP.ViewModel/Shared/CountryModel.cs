using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Shared
{
    public class CountryModel
    {
        public CountryModel() { }
        public string countryName { get; set; }
        public long id { get; set; }
    }
    public class CountrySearchModel : CountryModel
    {
        public CountrySearchModel() { }

        public string countryCode { get; set; }

    }
    public class CountryCreateModel : CountrySearchModel
    {
        public CountryCreateModel() { }
        public bool? isActive { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}

