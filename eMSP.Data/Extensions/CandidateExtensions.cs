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
                CandidateIndustries = data.tblCandidateIndustries != null ? data.tblCandidateIndustries.Select(a=>Convert.ToInt32(a.ID)).ToList():null,
                CandidateSkills = data.tblCandidateSkills != null ? data.tblCandidateSkills.Select(a => Convert.ToInt32(a.ID)).ToList() : null,
                CandidateIndustryNames = data.tblCandidateIndustries != null ? data.tblCandidateIndustries.Select(a => a.tblIndustry.Name).ToList() : null,
                CandidateSkillNames = data.tblCandidateSkills != null ? data.tblCandidateSkills.Select(a => a.tblIndustrySkill.Name).ToList() : null,
                CandidateContact = data.tblCandidateContacts != null ? data.tblCandidateContacts.Select(a => a.tblContact.ConvertToCandidateContactModel(Convert.ToBoolean(a.IsPrimary))).ToList() : null,
                CandidateFile = data.tblCandidateFiles != null ? data.tblCandidateFiles.Select(a=> a.tblFile.ConvertToCandidateFileModel()).ToList() : null,
                 
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
                CountyID = Convert.ToInt32(data.CountyID),
                Country = data.tblCountry != null ? data.tblCountry.Name : "",
                State = data.tblCountryState != null ? data.tblCountryState.Name : "",
                ID = Convert.ToInt32(data.ID),
                StateID = Convert.ToInt32(data.StateID),
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
                CountyID = data.CountyID,
                ID = data.ID,
                StateID = data.StateID,
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


    }
}
