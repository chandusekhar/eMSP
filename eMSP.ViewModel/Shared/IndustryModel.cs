using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Shared
{
    public class IndustryModel
    {
        public IndustryModel() { }
        public string industryName { get; set; }
        public string industryDescription { get; set; }
        public long id { get; set; }
    }
    
    public class IndustryCreateModel : IndustryModel
    {
        public IndustryCreateModel() { }
        public bool? isActive { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}
