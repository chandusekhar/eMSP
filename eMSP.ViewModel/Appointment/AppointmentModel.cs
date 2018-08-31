using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Appointment
{
    public class AppointmentStatus : BaseModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class AppointmentType : BaseModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class CandidateSubmissionAppointment : BaseModel
    {
        public long id { get; set; }
        public long appintmentTypeID { get; set; }
        public long candidateSubmissionID { get; set; }
        public long appointmentStatusID { get; set; }
        public string name { get; set; }
        public string details { get; set; }
    }

    public class CandidateSubmissionAppointmentSlot : BaseModel
    {
        public long id { get; set; }
        public long appintmentID { get; set; }
        public System.DateTime startDate { get; set; }
        public System.DateTime endDate { get; set; }
        public bool isFinalised { get; set; }
    }

    public class CandidateSubmissionAppointmentUser : BaseModel
    {
        public long id { get; set; }
        public long appointmentID { get; set; }
        public string userID { get; set; }
    }

    public class CandidateSubmissionAppointmentUserComment : BaseModel
    {
        public long id { get; set; }
        public long userID { get; set; }
        public long commentID { get; set; }
    }

    public class AppointmentModel : BaseModel
    {
        public AppointmentStatus appointmentStatus { get; set; }
        public AppointmentType appointmentType { get; set; }
        public List<CandidateSubmissionAppointmentSlot> appointmentSlots { get; set; }
        public List<CandidateSubmissionAppointmentUser> appointmentUsers { get; set; }
    }
}
