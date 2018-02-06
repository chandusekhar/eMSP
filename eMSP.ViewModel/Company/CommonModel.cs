using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.MSP
{

    public class CompanyModel
    {
        public CompanyModel() { }
        public string companyType { get; set; }
        public string companyName { get; set; }
        public string id { get; set; }

        
    }
    public class CompanySearchModel : CompanyModel
    {
        public CompanySearchModel()
        {

        }

        public string companyBranch { get; set; }
        public string companyLocation { get; set; }    
    }

    public class CompanyCreateModel : CompanyModel
    {
        public CompanyCreateModel()
        {

        }
  
        public string companyWebsite { get; set; }
        public string companyEmail { get; set; }
        public string companyPhoneNumber { get; set; }
        public string companyAddress { get; set; }
        public string companyCity { get; set; }
        public string StateID { get; set; }
        public string companyState { get; set; }
        public string CountryID { get; set; }
        public string companyCountry { get; set; }
        public Nullable< DateTime> createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}
