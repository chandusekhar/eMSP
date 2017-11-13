using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Shared
{
    public class IndustrySkillsModel
    {
        public IndustrySkillsModel() { }
        public string skillName { get; set; }
        public long id { get; set; }
        public long industryId { get; set; }
    }

   

    public class IndustrySkillsCreateModel : IndustrySkillsModel
    {
        public IndustrySkillsCreateModel()
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
