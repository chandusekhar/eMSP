//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eMSP.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCandidateSubmissionAppointmentUserComment
    {
        public long ID { get; set; }
        public long AppointmentID { get; set; }
        public long CommentID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
    
        public virtual tblCandidateSubmissionAppointment tblCandidateSubmissionAppointment { get; set; }
        public virtual tblComment tblComment { get; set; }
    }
}
