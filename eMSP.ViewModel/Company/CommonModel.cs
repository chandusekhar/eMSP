using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.MSP
{
    public class CompanySearchModel
    {
        public CompanySearchModel()
        {

        }

        public string companyBranch { get; set; }
        public string companyName { get; set; }
        public string companyLocation { get; set; }    
    }

    class CompanyCreateModel
    {
        public CompanyCreateModel()
        {

        }

        public string companyBranch { get; set; }
        public string companyName { get; set; }
        public string companyLocation { get; set; }  
    }
}
