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
                CustomerID = data.customerID,
                StartDate = data.startDate,
                EndDate = data.endDate,
                SubmissionDueDate = data.submissionDueDate,
                HiringManager = data.hiringManager,
                ReportingManager = data.reportingManager,
                PositionTitle = data.positionTitle,
                VacancyDescription = data.vacancyDescription,
                YearOfExperience = data.yearOfExperience,
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
                customerID = data.CustomerID,
                startDate = data.StartDate,
                endDate = data.EndDate,
                submissionDueDate = data.SubmissionDueDate,
                hiringManager = data.HiringManager,
                reportingManager = data.ReportingManager,
                positionTitle = data.PositionTitle,
                vacancyDescription = data.VacancyDescription,
                yearOfExperience = data.YearOfExperience,
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


        public static tblVacancieSkill ConvertTotblVacancieSkill(this VacancySkillsCreateModel data)
        {
            return new tblVacancieSkill()
            {
                ID = Convert.ToInt64(data.id),
                SkillID=data.skillId,
                VacancyID=data.vacancyId,
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
                vacancyId=data.VacancyID,
                skillId=data.SkillID,                
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


        public static tblVacancySupplier ConvertTotblVacancyFile(this VacancySuppliersCreateModel data)
        {
            return new tblVacancySupplier()
            {
                ID = Convert.ToInt64(data.id),
                SupplierID = data.supplierId,
                IsReleased=data.isReleased,
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
                isReleased=data.IsReleased,
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
