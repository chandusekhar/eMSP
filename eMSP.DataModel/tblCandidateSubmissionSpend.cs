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
    
    public partial class tblCandidateSubmissionSpend
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCandidateSubmissionSpend()
        {
            this.tblCandidateSubmissionSpendFiles = new HashSet<tblCandidateSubmissionSpendFile>();
        }
    
        public long ID { get; set; }
        public long PayPeriodID { get; set; }
        public long SpendCategoryID { get; set; }
        public long PlacementID { get; set; }
        public long CurrentStatusID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
    
        public virtual tblCandidatePlacement tblCandidatePlacement { get; set; }
        public virtual tblMSPPayPeriod tblMSPPayPeriod { get; set; }
        public virtual tblMSPSpendCategory tblMSPSpendCategory { get; set; }
        public virtual tblTimesheetStatu tblTimesheetStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCandidateSubmissionSpendFile> tblCandidateSubmissionSpendFiles { get; set; }
    }
}