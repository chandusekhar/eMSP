using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.ViewModel.Comments;
using eMSP.ViewModel.LocationBranch;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel.Shared;

namespace eMSP.ViewModel.JobVacancies
{
    public class VacancyModel : BaseModel
    {
        public VacancyModel() { }
        public long id { get; set; }
        public long customerId { get; set; }
        public string customerName { get; set; }
        public short vacancyType { get; set; }
        public string vacancyTypeName { get; set; }
        public System.DateTime startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<System.DateTime> submissionDueDate { get; set; }
        public string hiringManager { get; set; }
        public string reportingManager { get; set; }
        public string positionTitle { get; set; }
        public string vacancyDescription { get; set; }
        public decimal yearOfExperience { get; set; }
        public Nullable<bool> showCustomerDetailsToSupplier { get; set; }
        public decimal minPayRate { get; set; }
        public decimal maxPayRate { get; set; }
        public decimal targetPayRate { get; set; }
        public decimal payRateMarkUp { get; set; }
    }

    public class VacancyLocationModel : BaseModel
    {
        public VacancyLocationModel() { }
        public long id { get; set; }
        public long vacancyId { get; set; }
        public long locationId { get; set; }
        public string locationName { get; set; }
    }

    public class VacancyFileModel : BaseModel
    {
        public VacancyFileModel() { }
        public long id { get; set; }
        public long vacancyId { get; set; }
        public string filePath { get; set; }
        public string fileName { get; set; }
        public int fileVersionNumber { get; set; }
        public int fileTypeId { get; set; }
    }

    public class VacancySupplierModel : BaseModel
    {
        public VacancySupplierModel() { }
        public long id { get; set; }
        public long vacancyId { get; set; }
        public long supplierId { get; set; }
        public string supplierName { get; set; }
        public bool isReleased { get; set; }
    }

    public class VacancySkillsModel : BaseModel
    {
        public VacancySkillsModel() { }
        public long id { get; set; }
        public long vacancyId { get; set; }
        public long skillId { get; set; }
        public string skill { get; set; }
        //public long industryId { get; set; }
        //public string industry { get; set; }
    }

    public class VacancyCreateModel
    {
        public VacancyCreateModel() { }
        public VacancyModel Vacancy { get; set; }
        public List<LocationCreateModel> VacancyLocations { get; set; }
        public List<VacancyFileModel> VacancyFiles { get; set; }
        public List<CompanyCreateModel> VacancySuppliers { get; set; }
        public List<IndustrySkillsCreateModel> VacancySkills { get; set; }
        public List<CommentModel> VacancyComment { get; set; }
    }
}
