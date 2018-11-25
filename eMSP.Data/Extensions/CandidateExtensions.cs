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
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now

            };
        }

        public static CandidateCreateModel ConvertToCandidateCreateModel(this tblCandidate data)
        {
            return new CandidateCreateModel()
            {
                Candidate = new CandidateModel()
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
                CandidateIndustries = data.tblCandidateIndustries != null ? data.tblCandidateIndustries.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a => a.IndustryID.ToString()).ToList() : null,
                CandidateSkills = data.tblCandidateSkills != null ? data.tblCandidateSkills.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a => a.SkillsID.ToString()).ToList() : null,
                CandidateIndustryNames = data.tblCandidateIndustries != null ? data.tblCandidateIndustries.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a => a.tblIndustry.Name).ToList() : null,
                CandidateSkillNames = data.tblCandidateSkills != null ? data.tblCandidateSkills.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a => a.tblIndustrySkill.Name).ToList() : null,
                CandidateContact = data.tblCandidateContacts != null ? data.tblCandidateContacts.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a => a.tblContact.ConvertToCandidateContactModel(Convert.ToBoolean(a.IsPrimary))).ToList() : null,
                CandidateFile = data.tblCandidateFiles != null ? data.tblCandidateFiles.Where(a => a.IsActive == true && a.IsDeleted == false).Select(a => a.tblFile.ConvertToCandidateFileModel(Convert.ToInt32(a.FileTypeID))).ToList() : null,

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
                IsPrimary = isPrimary

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
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now


            };

        }

        public static FileModel ConvertToCandidateFileModel(this tblFile data, int fileTypeId = 0)
        {
            return new FileModel()
            {
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
            if (data != null)
            {
                return new tblFile()
                {
                    ID = data.ID,
                    FileName = data.FileName,
                    FilePath = data.FilePath,
                    FileVersionNumber = Convert.ToInt16(data.FileVersionNumber),
                    IsActive = data.isActive,
                    IsDeleted = data.isDeleted ?? false,
                    CreatedUserID = data.createdUserID,
                    UpdatedUserID = data.updatedUserID,
                    CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                    UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
                };
            }
            else
            {
                return new tblFile();
            }
        }

        public static tblCandidateSubmission ConverToTblCandidateSubmission(this CandidateSubmissionModel data)
        {
            return new tblCandidateSubmission()
            {
                ID = Convert.ToInt64(data.ID),
                VacancyID = data.VacancyId,
                CandidateID = data.CandidateId,
                BillRate = data.BillRate,
                StatusID = Convert.ToInt32(data.StatusId),
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static CandidateSubmissionModel ConvertToCandidateSubmissionModel(this tblCandidateSubmission data)
        {
            return new CandidateSubmissionModel()
            {
                ID = Convert.ToInt32(data.ID),
                VacancyId = Convert.ToInt32(data.VacancyID),
                CandidateId = Convert.ToInt32(data.CandidateID),
                CandidateFirstName = data.tblCandidate.FirstName,
                CandidateLastName = data.tblCandidate.LastName,
                StatusId = data.StatusID.ToString(),
                BillRate = data.BillRate,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp,
                CandidateStatus = data.tblCandidateStatu?.ConvertToCandidateStatusModel()
            };
        }

        public static tblCandidateStatu ConvertTotblCandidateStatus(this CandidateStatusModel data)
        {
            return new tblCandidateStatu()
            {
                ID = Convert.ToInt64(data.ID),
                Name = data.Name,
                Description = data.Description,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now


            };
        }

        public static CandidateStatusModel ConvertToCandidateStatusModel(this tblCandidateStatu data)
        {
            return new CandidateStatusModel()
            {
                ID = Convert.ToInt32(data.ID),
                Name = data.Name,
                Description = data.Description,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


        public static tblCandidateSubmissionDocumentRespons ConvertTotblCandidateSubmissionsQuestionsResponses(this CandidateSubmissionDocumentResponseModel data)
        {
            return new tblCandidateSubmissionDocumentRespons()
            {
                ID = Convert.ToInt64(data.id),
                CandidateSubmissionID = data.candidateSubmissionId,
                CandidateFileID = data.candidateFileId,
                VacancyRequiredDocumentID = data.vacancyRequiredDocumentId,
                CommentID = data.commentId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static CandidateSubmissionDocumentResponseModel ConvertToCandidateSubmissionDocumentResponseModel(this tblCandidateSubmissionDocumentRespons data)
        {
            return new CandidateSubmissionDocumentResponseModel()
            {
                id = Convert.ToInt32(data.ID),
                candidateSubmissionId = data.CandidateSubmissionID,
                candidateFileId = data.CandidateFileID,
                vacancyRequiredDocumentId = data.VacancyRequiredDocumentID,
                commentId = data.CommentID,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblCandidateSubmissionsQuestionsRespons ConvertTotblCandidateSubmissionsQuestionsRespons(this CandidateSubmissionsQuestionsResponseModel data)
        {
            return new tblCandidateSubmissionsQuestionsRespons()
            {
                ID = Convert.ToInt64(data.id),
                SubmissionID = data.submissionId,
                VacancyQuestionID = data.vacancyQuestionId,
                Responses = data.responses,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static CandidateSubmissionsQuestionsResponseModel ConvertToCandidateSubmissionsQuestionsResponseModel(this tblCandidateSubmissionsQuestionsRespons data)
        {
            return new CandidateSubmissionsQuestionsResponseModel()
            {
                id = Convert.ToInt32(data.ID),
                submissionId = data.SubmissionID,
                vacancyQuestionId = data.VacancyQuestionID,
                responses = data.Responses,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblCandidatePlacement ConvertTotblCandidatePlacement(this CandidatePlacementViewModel data)
        {
            return new tblCandidatePlacement()
            {
                ID = Convert.ToInt64(data.ID),
                SubmissionID = data.SubmissionID,
                TimeGroupID = data.TimeGroupID,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static CandidatePlacementViewModel ConvertToCandidatePlacementViewModel(this tblCandidatePlacement data)
        {
            return new CandidatePlacementViewModel()
            {
                ID = Convert.ToInt32(data.ID),
                SubmissionID = data.SubmissionID,
                TimeGroupID = data.TimeGroupID,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp,
                CandidateSubmission = data.tblCandidateSubmission.ConvertToCandidateSubmissionModel()                
            };
        }
    }
}
