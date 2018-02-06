using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Shared
{
    public class IndustrySkillsCreateModel : BaseModel
    {
        public IndustrySkillsCreateModel() { }
        public string skillName { get; set; }
        public long id { get; set; }
        public long industryId { get; set; }
    }
}
