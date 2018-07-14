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
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp
            };
        }

        public static MSPPayPeriodViewModel ConvertToMSPPayPeriodViewModel(this tblMSPPayPeriod data)
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

        public static tblCandidateTimesheet ConvertTotblCandidateTimesheet(this CandidateTimesheetViewModel data)
        {
            return new tblCandidateTimesheet()
            {
                ID = Convert.ToInt64(data.ID),
                PayPeriodID = data.PayPeriodID,
                PlacementID = data.PlacementID,
                StatusID = data.StatusID,
                VersionNumber = data.VersionNumber,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp,
                tblCandidateTimesheetHours = data.CandidateTimesheetHours.Select(x => x?.ConvertTotblCandidateTimesheetHour()).ToList(),
                tblCandidateTimesheetCategoriesHours = data.CandidateTimesheetCategoriesHours.Select(x => x?.ConvertTotblCandidateTimesheetCategoriesHour()).ToList()
            };
        }

        public static CandidateTimesheetViewModel ConvertToCandidateTimesheetViewModel(this tblCandidateTimesheet data)
        {
            if(data == null)
            {
                return null;
            }
            else
            {
                return new CandidateTimesheetViewModel()
                {
                    ID = Convert.ToInt64(data.ID),
                    PayPeriodID = data.PayPeriodID,
                    PlacementID = data.PlacementID,
                    StatusID = data.StatusID,
                    VersionNumber = data.VersionNumber,
                    isActive = data.IsActive,
                    isDeleted = data.IsDeleted ?? false,
                    createdUserID = data.CreatedUserID,
                    updatedUserID = data.UpdatedUserID,
                    createdTimestamp = data.CreatedTimestamp,
                    updatedTimestamp = data.UpdatedTimestamp,
                    CandidateTimesheetHours = data.tblCandidateTimesheetHours.Select(x => x?.ConvertToCandidateTimesheetHoursViewModel()).ToList(),
                    CandidateTimesheetCategoriesHours = data.tblCandidateTimesheetCategoriesHours.Select(x => x?.ConvertToCandidateTimesheetCategoriesHoursViewModel()).ToList(),
                    CandidatePlacement = data.tblCandidatePlacement?.ConvertToCandidatePlacementViewModel(),
                    MSPPayPeriods = data.tblMSPPayPeriod?.ConvertToMSPPayPeriodViewModel(),
                    TimesheetStatus = data.tblTimesheetStatu?.ConvertToTimesheetStatusViewModel()
                };
            }
            
        }

        public static tblCandidateTimesheetHour ConvertTotblCandidateTimesheetHour(this CandidateTimesheetHoursViewModel data)
        {
            return new tblCandidateTimesheetHour()
            {
                ID = Convert.ToInt64(data.ID),
                TimesheetID = data.TimesheetID,
                TimeDate = data.TimeDate,
                HoursWorked = data.HoursWorked,
                BreakHours = data.BreakHours              
            };
        }

        public static CandidateTimesheetHoursViewModel ConvertToCandidateTimesheetHoursViewModel(this tblCandidateTimesheetHour data)
        {
            return new CandidateTimesheetHoursViewModel()
            {
                ID = Convert.ToInt64(data.ID),
                TimesheetID = data.TimesheetID,
                TimeDate = data.TimeDate,
                HoursWorked = data.HoursWorked,
                BreakHours = data.BreakHours
            };
        }

        public static tblCandidateTimesheetCategoriesHour ConvertTotblCandidateTimesheetCategoriesHour(this CandidateTimesheetCategoriesHoursViewModel data)
        {
            return new tblCandidateTimesheetCategoriesHour()
            {
                ID = Convert.ToInt64(data.ID),
                TimesheetID = data.TimesheetID,
                TimesheetCategoryID=data.TimesheetCategoryID,
                TimeDate = data.TimeDate,
                Hours = data.Hours
            };
        }

        public static CandidateTimesheetCategoriesHoursViewModel ConvertToCandidateTimesheetCategoriesHoursViewModel(this tblCandidateTimesheetCategoriesHour data)
        {
            return new CandidateTimesheetCategoriesHoursViewModel()
            {
                ID = Convert.ToInt64(data.ID),
                TimesheetID = data.TimesheetID,
                TimesheetCategoryID = data.TimesheetCategoryID,
                TimeDate = data.TimeDate,
                Hours = data.Hours
            };
        }

        public static tblTimesheetStatu ConvertTotblTimesheetStatus(this TimesheetStatusViewModel data)
        {
            return new tblTimesheetStatu()
            {
                ID = Convert.ToInt64(data.ID),
                Name = data.Name,
                Description = data.Description,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp
            };
        }

        public static TimesheetStatusViewModel ConvertToTimesheetStatusViewModel(this tblTimesheetStatu data)
        {
            return new TimesheetStatusViewModel()
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

        public static tblMSPTimeGroup ConvertTotblMSPTimeGroup(this MSPTimeGroupViewModel data)
        {
            return new tblMSPTimeGroup()
            {
                ID = Convert.ToInt64(data.ID),
                Name = data.Name,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp
            };
        }

        public static MSPTimeGroupViewModel ConvertToMSPTimeGroupViewModel(this tblMSPTimeGroup data)
        {
            return new MSPTimeGroupViewModel()
            {
                ID = Convert.ToInt64(data.ID),
                Name = data.Name,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted ?? false,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblMSPTimeGroupCategory ConvertTotblMSPTimeGroupCategory(this MSPTimeGroupCategoriesViewModel data)
        {
            return new tblMSPTimeGroupCategory()
            {
                ID = Convert.ToInt64(data.ID),
                GroupID=data.GroupID,
                CategoryID=data.CategoryID,
                WeeklyMarkup=data.WeeklyMarkup,
                DailyMaxHours=data.DailyMaxHours,
                WeeklyMaxHours=data.MonthlyMaxHours,
                MonthlyMaxHours=data.MonthlyMaxHours,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp
            };
        }

        public static MSPTimeGroupCategoriesViewModel ConvertToMSPTimeGroupViewModel(this tblMSPTimeGroupCategory data)
        {
            return new MSPTimeGroupCategoriesViewModel()
            {
                ID = Convert.ToInt64(data.ID),
                GroupID = data.GroupID,
                CategoryID = data.CategoryID,
                WeeklyMarkup = data.WeeklyMarkup,
                DailyMaxHours = data.DailyMaxHours,
                WeeklyMaxHours = data.MonthlyMaxHours,
                MonthlyMaxHours = data.MonthlyMaxHours,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted ?? false,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


        public static tblMSPTimeCategory ConvertTotblMSPTimeCategory(this MSPTimeCategoriesViewModel data)
        {
            return new tblMSPTimeCategory()
            {
                ID = Convert.ToInt64(data.ID),
                Name = data.Name,
                Code=data.Code,
                MSPID=data.MSPID,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp
            };
        }

        public static MSPTimeCategoriesViewModel ConvertToMSPTimeCategoriesViewModel(this tblMSPTimeCategory data)
        {
            return new MSPTimeCategoriesViewModel()
            {
                ID = Convert.ToInt64(data.ID),
                Name = data.Name,
                Code = data.Code,
                MSPID = data.MSPID,
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
