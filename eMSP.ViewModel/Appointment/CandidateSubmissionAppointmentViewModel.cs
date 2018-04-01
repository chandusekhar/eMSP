using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Appointment
{
  public partial class CandidateSubmissionAppointmentViewModel:BaseModel
    {
        public CandidateSubmissionAppointmentViewModel()
        {
            this.Slots = new HashSet<CandidateSubmissionAppointmentSlotViewModel>();
            this.UserComments = new HashSet<CandidateSubmissionAppointmentUserCommentViewModel>();
            this.Users = new HashSet<CandidateSubmissionAppointmentUserViewModel>();
        }

        public long ID { get; set; }
        public long AppintmentTypeID { get; set; }
        public long CandidateSubmissionID { get; set; }
        public long AppointmentStatusID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public virtual AppointmentStatusViewModel Status { get; set; }
        public virtual AppointmentTypeViewModel Type { get; set; }
        //public virtual tblCandidateSubmission tblCandidateSubmission { get; set; }
       
        public virtual ICollection<CandidateSubmissionAppointmentSlotViewModel> Slots { get; set; }

        public virtual ICollection<CandidateSubmissionAppointmentUserCommentViewModel> UserComments { get; set; }

        public virtual ICollection<CandidateSubmissionAppointmentUserViewModel> Users { get; set; }
    }
}
