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
    
    public partial class tblVacancy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVacancy()
        {
            this.tblCandidateSubmissions = new HashSet<tblCandidateSubmission>();
            this.tblVacancieSkills = new HashSet<tblVacancieSkill>();
            this.tblVacanciesQuestions = new HashSet<tblVacanciesQuestion>();
            this.tblVacanciesRequiredDocuments = new HashSet<tblVacanciesRequiredDocument>();
            this.tblVacancyComments = new HashSet<tblVacancyComment>();
            this.tblVacancyFiles = new HashSet<tblVacancyFile>();
            this.tblVacancyLocations = new HashSet<tblVacancyLocation>();
            this.tblVacancySuppliers = new HashSet<tblVacancySupplier>();
        }
    
        public long ID { get; set; }
        public short VacancyType { get; set; }
        public long CustomerID { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> SubmissionDueDate { get; set; }
        public string HiringManager { get; set; }
        public string ReportingManager { get; set; }
        public string PositionTitle { get; set; }
        public string VacancyDescription { get; set; }
        public string YearOfExperience { get; set; }
        public Nullable<bool> ShowCustomerDetailsToSupplier { get; set; }
        public decimal MinPayRate { get; set; }
        public decimal MaxPayRate { get; set; }
        public decimal TargetPayRate { get; set; }
        public decimal PayRateMarkUp { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
        public Nullable<long> JobStatusID { get; set; }
        public short NoOfPositions { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCandidateSubmission> tblCandidateSubmissions { get; set; }
        public virtual tblCustomer tblCustomer { get; set; }
        public virtual tblJobVacanciesStatu tblJobVacanciesStatu { get; set; }
        public virtual tblMSPVacancieType tblMSPVacancieType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacancieSkill> tblVacancieSkills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacanciesQuestion> tblVacanciesQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacanciesRequiredDocument> tblVacanciesRequiredDocuments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacancyComment> tblVacancyComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacancyFile> tblVacancyFiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacancyLocation> tblVacancyLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacancySupplier> tblVacancySuppliers { get; set; }
    }
}
