using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.JobVacancies
{
    public class MSPVacancieType
    {
        public MSPVacancieType() { }
        public short id { get; set; }        
        public long mspId { get; set; }
    }

    public class MSPVacancieTypeCreateModel: MSPVacancieType
    {
        public MSPVacancieTypeCreateModel() { }
        public string name { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public System.DateTime createdTimestamp { get; set; }
        public string createdUserID { get; set; }
        public Nullable<System.DateTime> updatedTimestamp { get; set; }
        public string updatedUserID { get; set; }
    }
}
