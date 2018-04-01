using eMSP.ViewModel.Comments;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Appointment
{
  public partial class CandidateSubmissionAppointmentUserCommentViewModel:BaseModel
    {
        public long ID { get; set; }
        public long AppointmentID { get; set; }
        public long CommentID { get; set; }

        public virtual CandidateSubmissionAppointmentViewModel Appointment { get; set; }
        public virtual CommentModel Comment { get; set; }
    }
}
