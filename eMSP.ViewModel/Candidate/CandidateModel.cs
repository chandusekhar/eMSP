using eMSP.ViewModel.JobVacancies;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Candidate
{
    public class CandidateModel : BaseModel
    {
        public int id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string UniqueSocialID { get; set; }

        public CandidateModel() { }
    }

    public class CandidateContactModel : BaseModel
    {
        public CandidateContactModel() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string CountyID { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int ID { get; set; }
        public string StateID { get; set; }
        public string MobileNumber { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class FileModel : BaseModel
    {
        public FileModel() { }

        public int ID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int FileVersionNumber { get; set; }
        public int FileTypeId { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

    public class CandidateCreateModel
    {
        public CandidateCreateModel() { }
        public int SupplierId { get; set; }
        public CandidateModel Candidate { get; set; }
        public List<CandidateContactModel> CandidateContact { get; set; }
        public List<FileModel> CandidateFile { get; set; }
        public List<string> CandidateIndustries { get; set; }
        public List<string> CandidateSkills { get; set; }
        public List<string> CandidateIndustryNames { get; set; }
        public List<string> CandidateSkillNames { get; set; }
    }

    public class CandidateStatusModel : BaseModel
    {
        public CandidateStatusModel() { }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CandidateSubmissionModel : BaseModel
    {
        public CandidateSubmissionModel() { }
        public int ID { get; set; }
        public int CandidateId { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public int VacancyId { get; set; }
        public string StatusId { get; set; }
        public decimal BillRate { get; set; }
        public decimal PayRate { get; set; }
        public CandidateStatusModel CandidateStatus { get; set; }        
    }

    public class CandidateSubmissionCreateModel
    {
        public CandidateSubmissionCreateModel() { }
        public CandidateSubmissionModel CandidateSubmission { get; set; }
        public CandidateCreateModel Candidate { get; set; }
        public List<VacancyQuestionViewModel> Questions { get; set; }
        public List<VacancyRequiredDocumentViewModel> RequiredDocument { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsCustomerEdited { get; set; }
    }

    public partial class CandidateSubmissionDocumentResponseModel : BaseModel
    {
        public CandidateSubmissionDocumentResponseModel() { }
        public long id { get; set; }
        public long candidateSubmissionId { get; set; }
        public long vacancyRequiredDocumentId { get; set; }
        public long candidateFileId { get; set; }
        public Nullable<long> commentId { get; set; }
    }

    public partial class CandidateSubmissionsQuestionsResponseModel : BaseModel
    {
        public CandidateSubmissionsQuestionsResponseModel() { }
        public long id { get; set; }
        public long submissionId { get; set; }
        public long vacancyQuestionId { get; set; }
        public string responses { get; set; }
    }

    public partial class SuplierCandidatePlacementModel : BaseModel
    {
        public SuplierCandidatePlacementModel() { }
        public long CandidateId { get; set; }
        public long SupplierId { get; set; }
        public long PlacementId { get; set; }
        public string CandidateName { get; set; }
    }
}
