using eMSP.DataModel;
using eMSP.ViewModel.JobVacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class VacanciesExtensions
    {
        public static tblVacancy ConvertTotblVacancy(this VacancyCreateModel data)
        {
            return new tblVacancy()
            {
                ID = Convert.ToInt64(data.id),
                VacancyType = data.vacancyType,
                CustomerID = data.customerId,
                StartDate = data.startDate,
                EndDate = data.endDate,
                SubmissionDueDate = data.submissionDueDate,
                HiringManager = data.hiringManager,
                ReportingManager = data.reportingManager,
                PositionTitle = data.positionTitle,
                VacancyDescription = data.vacancyDescription,
                YearOfExperience = data.yearOfExperience.ToString(),
                ShowCustomerDetailsToSupplier = data.showCustomerDetailsToSupplier,
                MinPayRate = data.minPayRate,
                MaxPayRate = data.maxPayRate,
                TargetPayRate = data.targetPayRate,
                PayRateMarkUp = data.payRateMarkUp,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }


        public static VacancyCreateModel ConvertToVacancy(this tblVacancy data)
        {
            return new VacancyCreateModel()
            {
                id = data.ID,
                vacancyType = data.VacancyType,
                customerId = data.CustomerID,
                customerName = data.tblCustomer.Name,
                vacancyTypeName = data.tblMSPVacancieType.Name,
                startDate = data.StartDate,
                endDate = data.EndDate,
                submissionDueDate = data.SubmissionDueDate,
                hiringManager = data.HiringManager,
                reportingManager = data.ReportingManager,
                positionTitle = data.PositionTitle,
                vacancyDescription = data.VacancyDescription,
                yearOfExperience = Convert.ToDecimal(data.YearOfExperience),
                showCustomerDetailsToSupplier = data.ShowCustomerDetailsToSupplier,
                minPayRate = data.MinPayRate,
                maxPayRate = data.MaxPayRate,
                targetPayRate = data.TargetPayRate,
                payRateMarkUp = data.PayRateMarkUp,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


        public static tblVacancieSkill ConvertTotblVacancySkill(this VacancySkillsCreateModel data)
        {
            return new tblVacancieSkill()
            {
                ID = Convert.ToInt64(data.id),
                SkillID = data.skillId,
                IndustryID = data.industryId,
                VacancyID = data.vacancyId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static VacancySkillsCreateModel ConvertToVacancySkill(this tblVacancieSkill data)
        {
            return new VacancySkillsCreateModel()
            {
                id = data.ID,
                vacancyId = data.VacancyID,
                skillId = data.SkillID,
                skill = data.tblIndustrySkill != null ? data.tblIndustrySkill.Name : "",
                industryId = data.IndustryID,
                industry = data.tblIndustry != null ? data.tblIndustry.Name : "",
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


        public static tblVacancyComment ConvertTotblVacancyComment(this VacancyCommentsCreateModel data)
        {
            return new tblVacancyComment()
            {
                ID = Convert.ToInt64(data.id),
                CommentID = data.commentId,
                VacancyID = data.vacancyId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static VacancyCommentsCreateModel ConvertToVacancyComment(this tblVacancyComment data)
        {
            return new VacancyCommentsCreateModel()
            {
                id = data.ID,
                vacancyId = data.VacancyID,
                commentId = data.CommentID,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblVacancyLocation ConvertTotblVacancyLocation(this VacancyLocationsCreateModel data)
        {
            return new tblVacancyLocation()
            {
                ID = Convert.ToInt64(data.id),
                LocationID = data.locationId,
                VacancyID = data.vacancyId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static VacancyLocationsCreateModel ConvertToVacancyLocation(this tblVacancyLocation data)
        {
            return new VacancyLocationsCreateModel()
            {
                id = data.ID,
                vacancyId = data.VacancyID,
                locationId = data.LocationID,
                locationName = data.tblCustomerLocationBranch != null ? data.tblCustomerLocationBranch.tblLocation.LocationName : "",
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblVacancyFile ConvertTotblVacancyFile(this VacancyFilesCreateModel data)
        {
            return new tblVacancyFile()
            {
                ID = Convert.ToInt64(data.id),
                FilePath = data.filePath,
                VacancyID = data.vacancyId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static VacancyFilesCreateModel ConvertToVacancyFile(this tblVacancyFile data)
        {
            return new VacancyFilesCreateModel()
            {
                id = data.ID,
                vacancyId = data.VacancyID,
                filePath = data.FilePath,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


        public static tblVacancySupplier ConvertTotblVacancySupplier(this VacancySuppliersCreateModel data)
        {
            return new tblVacancySupplier()
            {
                ID = Convert.ToInt64(data.id),
                SupplierID = data.supplierId,
                IsReleased = data.isReleased,
                VacancyID = data.vacancyId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static VacancySuppliersCreateModel ConvertToVacancySupplier(this tblVacancySupplier data)
        {
            return new VacancySuppliersCreateModel()
            {
                id = data.ID,
                vacancyId = data.VacancyID,
                supplierId = data.SupplierID,
                supplierName = data.tblSupplier != null ? data.tblSupplier.Name : "",
                isReleased = data.IsReleased,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblMSPVacancieType ConvertTotblMSPVacancieType(this MSPVacancieTypeCreateModel data)
        {
            return new tblMSPVacancieType()
            {
                ID = Convert.ToInt16(data.id),
                MSPID = data.mspId,
                Name = data.name,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static MSPVacancieTypeCreateModel ConvertToMSPVacancieType(this tblMSPVacancieType data)
        {
            return new MSPVacancieTypeCreateModel()
            {
                id = data.ID,
                name = data.Name,
                mspId = data.MSPID,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }
    }
}
