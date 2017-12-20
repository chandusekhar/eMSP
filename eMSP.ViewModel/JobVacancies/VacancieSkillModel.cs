using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.JobVacancies
{
    public class VacancieSkillModel
    {
        public VacancieSkillModel() { }
        public long id { get; set; }
        public long vacancyId { get; set; }
    }
    public class VacancySkillsCreateModel : VacancieSkillModel
    {
        public VacancySkillsCreateModel() { }
        public long skillId { get; set; }
        public string skill { get; set; }
        public long industryId { get; set; }
        public string industry { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public System.DateTime createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<System.DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}
