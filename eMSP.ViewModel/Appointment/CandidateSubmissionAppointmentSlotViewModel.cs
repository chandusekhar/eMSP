using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Appointment
{
  public partial class CandidateSubmissionAppointmentSlotViewModel:BaseModel
    {
        public long ID { get; set; }
        public long AppintmentID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool IsFinalised { get; set; }

        public virtual CandidateSubmissionAppointmentViewModel Appointment { get; set; }
    }
}
}
