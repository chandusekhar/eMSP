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
        public static tblVacancy ConvertTotblVacancy(this VacancyModel data)
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
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }


        public static VacancyModel ConvertToVacancy(this tblVacancy data)
        {
            return new VacancyModel()
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

        public static VacancyCreateModel ConvertToVacancyCreateModel(this tblVacancy data)
        {
            return new VacancyCreateModel()
            {
                Vacancy = new VacancyModel()
                {
                    id = data.ID,
                    customerId = data.CustomerID,
                    customerName = data.tblCustomer != null ? data.tblCustomer.Name : "",
                    vacancyType = data.VacancyType,
                    vacancyTypeName = data.tblMSPVacancieType != null ? data.tblMSPVacancieType.Name : "",
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
                    createdTimestamp = data.CreatedTimestamp,
                    createdUserID = data.CreatedUserID,
                    updatedTimestamp = data.UpdatedTimestamp,
                    updatedUserID = data.UpdatedUserID,
                },
                VacancyFiles = data.tblVacancyFiles != null ? data.tblVacancyFiles.Select(a => a.ConvertToVacancyFile()).ToList() : null,
                VacancyComment = data.tblVacancyComments != null ? data.tblVacancyComments.Select(a => a.tblComment.ConvertToComment()).ToList() : null,
                VacancySkills = data.tblVacancieSkills != null ? data.tblVacancieSkills.Select(a => a.tblIndustrySkill.ConvertToIndustrySkill()).ToList() : null,
                VacancyLocations = data.tblVacancyLocations != null ? data.tblVacancyLocations.Select(a => a.tblCustomerLocationBranch.tblLocation.ConvertToLocation()).ToList() : null,
                VacancySuppliers = data.tblVacancySuppliers != null ? data.tblVacancySuppliers.Select(a => a.tblSupplier.ConvertTocompany()).ToList() : null
            };
        }


        public static tblVacancieSkill ConvertTotblVacancySkill(this VacancySkillsModel data)
        {
            return new tblVacancieSkill()
            {
                ID = Convert.ToInt64(data.id),
                SkillID = data.skillId,
                VacancyID = data.vacancyId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static VacancySkillsModel ConvertToVacancySkill(this tblVacancieSkill data)
        {
            return new VacancySkillsModel()
            {
                id = data.ID,
                vacancyId = data.VacancyID,
                skillId = data.SkillID,
                skill = data.tblIndustrySkill != null ? data.tblIndustrySkill.Name : "",
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
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
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

        public static tblVacancyLocation ConvertTotblVacancyLocation(this VacancyLocationModel data)
        {
            return new tblVacancyLocation()
            {
                ID = Convert.ToInt64(data.id),
                LocationID = data.locationId,
                VacancyID = data.vacancyId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static VacancyLocationModel ConvertToVacancyLocation(this tblVacancyLocation data)
        {
            return new VacancyLocationModel()
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

        public static tblVacancyFile ConvertTotblVacancyFile(this VacancyFileModel data)
        {
            return new tblVacancyFile()
            {
                ID = Convert.ToInt64(data.id),
                FilePath = data.filePath,
                FileName = data.fileName,
                VacancyID = data.vacancyId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static VacancyFileModel ConvertToVacancyFile(this tblVacancyFile data)
        {
            return new VacancyFileModel()
            {
                id = data.ID,
                vacancyId = data.VacancyID,
                filePath = data.FilePath,
                fileName = data.FileName,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


        public static tblVacancySupplier ConvertTotblVacancySupplier(this VacancySupplierModel data)
        {
            return new tblVacancySupplier()
            {
                ID = Convert.ToInt64(data.id),
                SupplierID = data.supplierId,
                IsReleased = data.isReleased,
                VacancyID = data.vacancyId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static VacancySupplierModel ConvertToVacancySupplier(this tblVacancySupplier data)
        {
            return new VacancySupplierModel()
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
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
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
