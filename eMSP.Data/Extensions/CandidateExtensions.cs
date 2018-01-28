using eMSP.DataModel;
using eMSP.ViewModel.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class CandidateExtensions
    {
        public static tblCandidate ConvertTotblCandidate(this CandidateModel data)
        {
            return new tblCandidate()
            {
                ID = Convert.ToInt64(data.id),
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateOfBirth = data.DateOfBirth,
                Email = data.Email,
                UniqueSocialID = data.UniqueSocialID,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now

            };
        }

        public static CandidateCreateModel ConvertToCandidateCreateModel(this tblCandidate data)
        {
            return new CandidateCreateModel()
            {
                Candidate =new CandidateModel()
                {
                    id = Convert.ToInt32(data.ID),
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    DateOfBirth = data.DateOfBirth,
                    Email = data.Email,
                    UniqueSocialID = data.UniqueSocialID,
                    isActive = data.IsActive,
                    isDeleted = data.IsDeleted,
                    createdUserID = data.CreatedUserID,
                    updatedUserID = data.UpdatedUserID,
                    createdTimestamp = data.CreatedTimestamp,
                    updatedTimestamp = data.UpdatedTimestamp
                },
                CandidateIndustries = data.tblCandidateIndustries != null ? data.tblCandidateIndustries.Where(a=>a.IsActive == true && a.IsDeleted == false).Select(a=>a.IndustryID.ToString()).ToList():null,
                CandidateSkills = data.tblCandidateSkills != null ? data.tblCandidateSkills.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a => a.SkillsID.ToString()).ToList() : null,
                CandidateIndustryNames = data.tblCandidateIndustries != null ? data.tblCandidateIndustries.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a => a.tblIndustry.Name).ToList() : null,
                CandidateSkillNames = data.tblCandidateSkills != null ? data.tblCandidateSkills.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a => a.tblIndustrySkill.Name).ToList() : null,
                CandidateContact = data.tblCandidateContacts != null ? data.tblCandidateContacts.Select(a => a.tblContact.ConvertToCandidateContactModel(Convert.ToBoolean(a.IsPrimary))).ToList() : null,
                CandidateFile = data.tblCandidateFiles != null ? data.tblCandidateFiles.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a=> a.tblFile.ConvertToCandidateFileModel(Convert.ToInt32(a.FileTypeID))).ToList() : null,
                 
            };

        }

        public static CandidateContactModel ConvertToCandidateContactModel(this tblContact data, bool isPrimary = false)
        {
            return new CandidateContactModel()
            {

                FirstName = data.FirstName,
                LastName = data.LastName,
                EmailAddress = data.EmailAddress,
                City = data.City,
                CountyID = data.CountyID.ToString(),
                Country = data.tblCountry != null ? data.tblCountry.Name : "",
                State = data.tblCountryState != null ? data.tblCountryState.Name : "",
                ID = Convert.ToInt32(data.ID),
                StateID = data.StateID.ToString(),
                MobileNumber = data.MobileNumber,
                StreetAddress = data.StreetAddress,
                ZipCode = data.ZipCode,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp,
                IsPrimary= isPrimary

            };
        }

        public static tblContact ConvertTotblContact(this CandidateContactModel data)
        {
            return new tblContact()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                EmailAddress = data.EmailAddress,
                City = data.City,
                CountyID = Convert.ToInt64(data.CountyID),
                ID = data.ID,
                StateID = Convert.ToInt64(data.StateID),
                MobileNumber = data.MobileNumber,
                StreetAddress = data.StreetAddress,
                ZipCode = data.ZipCode,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
                
                 
            };

        }

        public static FileModel ConvertToCandidateFileModel(this tblFile data, int fileTypeId = 0)
        {
            return new FileModel() {
                ID = Convert.ToInt32(data.ID),
                FileName = data.FileName,
                FilePath = data.FilePath,
                FileVersionNumber = data.FileVersionNumber,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp,
                FileTypeId = fileTypeId
            };

        }

        public static tblFile ConvertTotblFile(this FileModel data)
        {
            return new tblFile()
            {
                ID = data.ID,
                FileName = data.FileName,
                FilePath = data.FilePath,                
                FileVersionNumber = Convert.ToInt16(data.FileVersionNumber),
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };

        }

        public static tblCandidateSubmission ConverToTblCandidateSubmission(this CandidateSubmissionModel data)
        {
            return new tblCandidateSubmission()
            {
                ID = Convert.ToInt64(data.ID),
                VacancyID = data.VacancyId,
                CandidateID = data.CandidateId,
                StatusID = data.StatusId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now

            };
        }

        public static CandidateSubmissionModel ConvertToCandidateSubmissionModel(this tblCandidateSubmission data)
        {
            return new CandidateSubmissionModel()
            {
                ID = Convert.ToInt32(data.ID),
                VacancyId = Convert.ToInt32(data.VacancyID),
                CandidateId = Convert.ToInt32(data.CandidateID),
                StatusId = Convert.ToInt32(data.StatusID),
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = DateTime.Now,
                updatedTimestamp = DateTime.Now,
                CandidateStatus = data.tblCandidateStatu.ConvertToCandidateSubmissionModel()

            };
        }

        public static tblCandidateStatu ConvertTotblCandidateStatus(this CandidateStatusModel data)
        {
            return new tblCandidateStatu()
            {
                ID = Convert.ToInt64(data.ID),
                Name  = data.Name,
                Description = data.Description,               
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
                

            };
        }

        public static CandidateStatusModel ConvertToCandidateSubmissionModel(this tblCandidateStatu data)
        {
            return new CandidateStatusModel()
            {
                ID = Convert.ToInt32(data.ID),
                Name =  data.Name,
                Description = data.Description,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = DateTime.Now,
                updatedTimestamp = DateTime.Now 
                
                  

            };
        }
    }
}
