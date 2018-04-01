using eMSP.ViewModel.Shared;
using eMSP.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Appointment
{
  public partial class CandidateSubmissionAppointmentUserViewModel:BaseModel
    {
        public long ID { get; set; }
        public long AppointmentID { get; set; }
        public string UserID { get; set; }

        public virtual CandidateSubmissionAppointmentViewModel Appointment { get; set; }
        public virtual UserCreateModel User { get; set; }
    }
}
