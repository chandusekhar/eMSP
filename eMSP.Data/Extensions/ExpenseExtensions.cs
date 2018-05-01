using eMSP.DataModel;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class ExpenseExtensions
    {
        public static tblCandidateSubmissionSpend ConvertTotblCandidateSubmissionSpend(this CandidateSubmissionSpendViewModel data)
        {
            return new tblCandidateSubmissionSpend()
            {
                ID = Convert.ToInt64(data.ID),
                PayPeriodID = data.PayPeriodID,
                SpendCategoryID = data.SpendCategoryID,
                PlacementID = data.PlacementID,
                CurrentStatusID = data.CurrentStatusID,
                Name = data.Name,
                Description = data.Description,
                Amount = data.Amount,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp,
                tblCandidateSubmissionSpendFiles = data?.CandidateSubmissionSpendFiles?
                                                        .Select(x => x.ConvertTotblCandidateSubmissionSpendFile())
                                                        .ToList()
            };
        }

        public static CandidateSubmissionSpendViewModel ConvertToCandidateSubmissionSpendViewModel(this tblCandidateSubmissionSpend data)
        {
            return new CandidateSubmissionSpendViewModel()
            {
                ID = Convert.ToInt64(data.ID),
                PayPeriodID = data.PayPeriodID,
                SpendCategoryID = data.SpendCategoryID,
                PlacementID = data.PlacementID,
                CurrentStatusID = data.CurrentStatusID,
                Name = data.Name,
                Description = data.Description,
                Amount = data.Amount,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted ?? false,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp,
                CandidateSubmissionSpendFiles = data?.tblCandidateSubmissionSpendFiles?
                                                        .Select(x => x.ConvertToCandidateSubmissionSpendFilesViewModel())
                                                        .ToList()
            };
        }

        public static tblCandidateSubmissionSpendFile ConvertTotblCandidateSubmissionSpendFile(this CandidateSubmissionSpendFilesViewModel data)
        {
            return new tblCandidateSubmissionSpendFile()
            {
                ID = Convert.ToInt64(data.ID),
                SpendID=data.SpendID,
                FileID=data.FileID,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp
            };
        }

        public static CandidateSubmissionSpendFilesViewModel ConvertToCandidateSubmissionSpendFilesViewModel(this tblCandidateSubmissionSpendFile data)
        {
            return new CandidateSubmissionSpendFilesViewModel()
            {
                ID = Convert.ToInt64(data.ID),
                SpendID = data.SpendID,
                FileID = data.FileID,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted ?? false,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblMSPSpendCategory ConvertTotblMSPSpendCategory(this MSPSpendCategoryViewModel data)
        {
            return new tblMSPSpendCategory()
            {
                ID = Convert.ToInt64(data.ID),
                Name=data.Name,
                Description=data.Description,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp
            };
        }

        public static MSPSpendCategoryViewModel ConvertToMSPSpendCategoryViewModel(this tblMSPSpendCategory data)
        {
            return new MSPSpendCategoryViewModel()
            {
                ID = Convert.ToInt64(data.ID),
                Name = data.Name,
                Description = data.Description,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted ?? false,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


    }
}
