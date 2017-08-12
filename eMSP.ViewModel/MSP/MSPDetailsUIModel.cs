using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.MSP
{
   public partial class MSPDetailsUIModel
    {
        public MSPDetailsUIModel()
        {

        }

        public string ID { get; set; }
        public string CompanyName { get; set; }
        public string WebSite { get; set; }        
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<long> StateID { get; set; }
        public string StateName { get; set; }
        public Nullable<long> CountryID { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
    }
}
