using eMSP.DataModel;
using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class TimeSheetExtensions
    {
        public static tblMSPPayPeriod ConvertTotblMSPPayPeriod(this MSPPayPeriodViewModel data)
        {
            return new tblMSPPayPeriod()
            {
                ID = Convert.ToInt64(data.ID),
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp
            };
        }

        public static MSPPayPeriodViewModel ConvertToCandidateCreateModel(this tblMSPPayPeriod data)
        {
            return new MSPPayPeriodViewModel()
            {
                ID = Convert.ToInt64(data.ID),
                StartDate = data.StartDate,
                EndDate = data.EndDate,
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
