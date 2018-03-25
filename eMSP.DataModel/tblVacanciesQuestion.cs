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
    
    public partial class tblVacanciesQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVacanciesQuestion()
        {
            this.tblCandidateSubmissionsQuestionsResponses = new HashSet<tblCandidateSubmissionsQuestionsRespons>();
        }
    
        public long ID { get; set; }
        public long VacancyID { get; set; }
        public long QuestionID { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDescription { get; set; }
        public Nullable<bool> IsMandatory { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }
        public string CreatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedTimestamp { get; set; }
        public string UpdatedUserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCandidateSubmissionsQuestionsRespons> tblCandidateSubmissionsQuestionsResponses { get; set; }
        public virtual tblMSPQuestion tblMSPQuestion { get; set; }
        public virtual tblVacancy tblVacancy { get; set; }
    }
}